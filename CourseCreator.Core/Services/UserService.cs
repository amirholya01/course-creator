using CourseCreator.Core.Convertors;
using CourseCreator.Core.DTOs;
using CourseCreator.Core.Security;
using CourseCreator.Core.Services.Interfaces;
using CourseCreator.Core.Utils;
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

        public bool ActiveAccount(string activeCode)
        {
            var user = _contex.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
            if (user == null || user.IsAvtive)
                return false;
            user.IsAvtive = true;
            user.ActiveCode = Util.GenerateUniqueCode();
            _contex.SaveChanges();
            return true;
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

        public User LoginUser(LoginViewModel login)
        {
            string hashPassword = HashString.EncodeString(login.Password);
            string email = FixedValidFields.ValidEmail(login.Email);

            return _contex.Users.SingleOrDefault(u => u.Email == email && u.Password == hashPassword);
        }
    }
}
