using AFK.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AFK.Controllers
{
    [Authorize]
    public class FeedPageController : Controller
    {
        UserManager<User> userManager;
        DatabaseContext context;
        public FeedPageController(DatabaseContext context1, UserManager<User> userManager)
        {
            this.userManager = userManager;
            context = context1;
        }
        public IActionResult Index()
        {
            return View("FeedPage");
        }

        public IActionResult Following()
        {
            return View();
        }

        public IActionResult Bookmarks()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ask()
        {
            var askModel = new AskModel();
            List<Category> categories = context.categories.ToList();
            askModel.categLists = categories;
            return View(askModel);
        }
        [HttpPost]
        public IActionResult Ask(AskModel newQues)
        {
            Question question = new Question();

            question.QuestionText = newQues.QuestionText;
            question.QuestionDetails = newQues.QuestionDetails;
            question.categoryId = newQues.categoryId;
            question.UserId = userManager.GetUserId(HttpContext.User);
            question.QuestionTime = newQues.QuestionTime;


            context.questions.Add(question);

            context.SaveChanges();
            return RedirectToAction("FeedPage");
        }
        [HttpGet]
        public IActionResult FeedPage()
        {
            var FeedModel = new FeedModel();
            string logUSER = userManager.GetUserId(HttpContext.User);

            List<Question> questions = context.questions.Include(a => a.category).ThenInclude(d => d.userCategories).OrderBy(b => b.QuestionTime).ToList();
            List<Question> questions1 = new List<Question>();
            foreach (var question in questions)
            {
                var userQuestions = question.category.userCategories.Where(f => f.Id == logUSER);
                if (userQuestions.Count() > 0)
                {
                    questions1.Add(question);
                }
            }

            FeedModel.questions = questions1;

            // List<Category> categories = context.categories.ToList();
            // FeedModel.categories = categories;

            return View(FeedModel);
        }

        public IActionResult Profile()
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Answers(int id)
        {
            var answerModel = new AnswerModel();
            answerModel.question = context.questions.Find(id);
            List<Answer> answers = await context.answers.Include(q => q.question).Where(a => a.questionId == id).OrderBy(d => d.AnswerTime).ToListAsync();
            answerModel.answers = answers;
            return View(answerModel);
        }


        [HttpGet]
        public IActionResult Reply(int id)
        {
           

            return View();
        }
        [HttpPost]
        public IActionResult Reply(ReplyModel replyModel, int id)
        {
            Answer answer = new Answer();

            answer.AnswerText = replyModel.AnswerText;
            answer.AnswerDetails = replyModel.AnswerDetails;
            answer.UserId = userManager.GetUserId(HttpContext.User);
            answer.questionId = id;

            context.answers.Add(answer);

            context.SaveChanges();
            return RedirectToAction("FeedPage");
        }

        public IActionResult Save()
        {
            // add to the database
            //fix the return to keep on the same page 
            return View("Reply");
        }
        public IActionResult MyQuestions()
        {
             var FeedModel = new FeedModel();
            string logUSER = userManager.GetUserId(HttpContext.User);

            List<Question> questions = context.questions.Where(c=>c.UserId == logUSER).OrderBy(b => b.QuestionTime).ToList();
         
           
            FeedModel.questions = questions;

            // List<Category> categories = context.categories.ToList();
            // FeedModel.categories = categories;

            return View(FeedModel);
            
        }

    }
}