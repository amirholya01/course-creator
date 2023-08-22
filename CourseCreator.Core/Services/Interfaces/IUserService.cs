using CourseCreator.Core.DTOs;
using CourseCreator.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUsernameExist(string username);
        bool IsEmailExist(string email);
        long AddUser(User user);
        User LoginUser(LoginViewModel login);
    }
}
