using Microsoft.AspNetCore.Mvc;

namespace CourseCreator.Web.Controllers
{
    public class AccountController : Controller
    {
        [Route("Register")]
        public async Task<IActionResult> Register()
        {
            await Task.Delay(500);
            return View();
        }
    }
}
