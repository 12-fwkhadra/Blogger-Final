using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AFK.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        public string categoryName { get; set; }

        public ICollection<Question> questions { get; set; }

        public List<UserCategory> userCategories { get; set; }



    }
}
