using System;
using System.Collections.Generic;

namespace AFK.Models
{
    public class AskModel
    {


        public string QuestionText { get; set; }
        public string QuestionDetails { get; set; }
        public DateTime QuestionTime { get; set; } = new DateTime();
        public List<Category> categLists { get; set; }

        public int categoryId { get; set; }
    }
}
