using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AFK.Models
{
    public class Question
    {
        [Key]
        public int questionId { get; set; }
        [Required(ErrorMessage = "Please enter a question")]
        public string QuestionText { get; set; }
        public string QuestionDetails { get; set; }
        public DateTime QuestionTime { get; set; }


        [Required(ErrorMessage = "please select a category")]
        public int categoryId { get; set; }
        public Category category { get; set; }

        public string UserId { get; set; }
        public User user { get; set; }
        public ICollection<Answer> answers { get; set; }



    }
}
