using CourseCreator.Core.Services.Interfaces;
using CourseCreator.DataLayer.Context;
using CourseCreator.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Services
{
   
    public class UserService : IUserService
    {
        private readonly CourseCreatorContext _contex;
        public UserService(CourseCreatorContext context)
        {
            _contex = context;
        }

        public long AddUser(User user)
        {
            _contex.Users.Add(user);
            _contex.SaveChanges();
            return user.UserId;
        }

        public bool IsEmailExist(string email)
        {
            return _contex.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameExist(string username)
        {
            return _contex.Users.Any(u => u.Username == username);
        }
    }
}
