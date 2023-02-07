using System.ComponentModel.DataAnnotations;

namespace AFK.Models

{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a username")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(255)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(255)]
        public string ConfirmPassword { get; set; }
    }
}