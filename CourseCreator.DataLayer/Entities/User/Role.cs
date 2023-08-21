using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.DataLayer.Entities.User
{
    public class Role
    {

        public Role()
        {
            
        }

        [Key]
        public long RoleId { get; set; }

        [Display(Name = "Role Title")]
        [Required(ErrorMessage = "The {0} must not be empty.")]
        [MaxLength(20, ErrorMessage = "The {0} can not be more than {1} characters.")]
        public string RoleTitle { get; set; }





        #region Relations
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }

}
