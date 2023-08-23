using CourseCreator.Core.Convertors;
using CourseCreator.Core.DTOs;
using CourseCreator.Core.Security;
using CourseCreator.Core.Services.Interfaces;
using CourseCreator.Core.Utils;
using CourseCreator.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace CourseCreator.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #region Register
        [Route("Register")]
        public async Task<IActionResult> Register()
        {
            await Task.Delay(0);
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }


            if (_userService.IsEmailExist(FixedValidFields.ValidEmail(register.Email)))
            {
                ModelState.AddModelError("Email", "The emial is not valid.");
                return View(register);
            }


            if (_userService.IsUsernameExist(register.Username))
            {
                ModelState.AddModelError("Username", "The username is not valid.");
                return View(register);
            }

            User user = new User()
            {
                ActiveCode = Util.GenerateUniqueCode(),
                Email = FixedValidFields.ValidEmail(register.Email),
                IsAvtive = false,
                Password = HashString.EncodeString(register.Password),
                RegisterDate = DateTime.Now,
                UserAvator = "default.png",
                Username = register.Username,
            };

            _userService.AddUser(user);

            //TODO: Activating link - must send an email
            return View("successRegister", user);
        }
        #endregion

        #region Login
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }


        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if(!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _userService.LoginUser(login);
            if(user != null)
            {
                if (user.IsAvtive)
                {
                    //TODO: Login User
                    //ViewBag.IsSuccess = true;
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("Email", "Your acount is not active.");

                }
                ModelState.AddModelError("Email", "A user with the entered profile was not found.");
            }
            return View(login);
        }
        #endregion
    }
}
