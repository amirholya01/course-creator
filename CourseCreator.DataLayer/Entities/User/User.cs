using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.DataLayer.Entities.User
{
    public class User
    {
        public User()
        {
            
        }


        [Key]
        public long UserId { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [StringLength(20, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Username { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [StringLength(30, ErrorMessage = "The {0} can not be more than {1} characters.")]
        [EmailAddress(ErrorMessage = "The {0} is not valid.")]
        public string Email { get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [StringLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string Password { get; set; }



        [Display(Name = "Active Code")]
        [StringLength(100, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string ActiveCode { get; set; }





        [Display(Name = "Status")]
        public bool IsAvtive { get; set; }

        [Display(Name = "User Avatar")]
        [StringLength(50, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string UserAvator { get; set; }

        [Display(Name = "Date of Registration")]
        public DateTime RegisterDate { get; set; }


        #region Relations
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}
