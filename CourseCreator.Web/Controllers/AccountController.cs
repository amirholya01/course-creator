using CourseCreator.Core.Convertors;
using CourseCreator.Core.DTOs;
using CourseCreator.Core.Services.Interfaces;
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

        [Route("Register")]
        public async Task<IActionResult> Register()
        {
            await Task.Delay(0);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }


            if(_userService.IsEmailExist(FixedValidFields.ValidEmail(register.Email)))
            {
                ModelState.AddModelError("Email", "The emial is not valid.");
                return View(register);
            }


            if(_userService.IsUsernameExist(register.Username))
            {
                ModelState.AddModelError("Username", "The username is not valid.");
                return View(register);
            }

            //TODO: Register User
            


            return View(register);
        }
    }
}
