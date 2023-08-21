using CourseCreator.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.DataLayer.Context
{
    public class CourseCreatorContext : DbContext
    {
        public CourseCreatorContext(DbContextOptions<CourseCreatorContext> options):base(options)
        {
            
        }

        #region User
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion
    }
}
