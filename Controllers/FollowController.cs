using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AFK.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AFK.Controllers
{
    [Authorize]
    public class FollowController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly DatabaseContext _context;
        public FollowController(DatabaseContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Topics()
        {
            var categories = await _context.categories.Include(c => c.userCategories).ThenInclude(u => u.User).ToListAsync();

            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToTopic(FollowViewModel followViewModel)
        {
            var category = await _context.categories.Include(p => p.userCategories).FirstOrDefaultAsync(x => x.categoryId == followViewModel.Id);
            if (category != null)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                // First we need to check if the user adding this topic has already follow it or not
                var userAlreadyExist = category.userCategories.Find(x => x.Id == userId);
                if (userAlreadyExist != null) 
                {
                    // in this case we need to remove the user 
                    _context.userCategories.Remove(userAlreadyExist);
                } else
                { 
                 // in this case we need to add this user to this specific category
                _context.userCategories.Add(new UserCategory
                {
                    Id = userId,
                    categoryId = followViewModel.Id
                });
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Topics");
        }
    }
}