using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.DTOs
{
    public class RegisterViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [StringLength(20, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Username { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [StringLength(30, ErrorMessage = "The {0} can not be more than {1} characters.")]
        [EmailAddress(ErrorMessage = "The {0} is not valid.")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [StringLength(20, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [StringLength(20, ErrorMessage = "The {0} can not be more than {1} characters.")]
        [Compare("Password", ErrorMessage = "The password entered is not correct.")]
        public string ConfirmPassword { get; set; }
    }
}
