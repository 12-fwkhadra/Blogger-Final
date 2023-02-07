using System;
using System.Collections.Generic;

namespace AFK.Models
{
    public class ReplyModel
    {


        public string AnswerText { get; set; }
        public string AnswerDetails { get; set; }
        public DateTime AnswerTime()
        {
            var currentDate = new DateTime();
            return currentDate.Date;
        }
        public int questionId{get;set;}

    }
}
