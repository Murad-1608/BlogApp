using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1()
        {
            return View();
        }
    }
}
