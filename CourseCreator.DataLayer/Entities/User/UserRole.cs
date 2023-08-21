using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.DataLayer.Entities.User
{
    public class UserRole
    {

        public UserRole()
        {
            
        }

        [Key]
        public long UR_Id { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }

        #region Relations 
        public virtual User User { get; set; }
        public virtual Role Role { get; set;}
        #endregion
    }
}
