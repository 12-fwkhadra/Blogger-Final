using System;
using System.ComponentModel.DataAnnotations;

namespace AFK.Models
{
    public class Answer
    {
        [Key]
        public int answerId { get; set; }
        [Required(ErrorMessage = "Please enter a question")]
        public string AnswerText { get; set; }
        public string AnswerDetails { get; set; }
        public DateTime AnswerTime { get; set; }

        public int questionId { get; set; }//fk
        public string UserId { get; set; }//fk
        public Question question { get; set; }

        public User user { get; set; }




    }
}
