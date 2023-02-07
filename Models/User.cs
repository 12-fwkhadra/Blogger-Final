using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace AFK.Models
{
    public class User : IdentityUser
    {



        public ICollection<Question> questions { get; set; }
        public ICollection<Answer> answers { get; set; }
        public ICollection<UserCategory> userCategories { get; set; }




    }
}
