using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AFK.Models
{
    public class UserCategory
    {

        public string Id { get; set; }
        public int categoryId { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }



    }
}
