using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;
        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var about = aboutService.GetLastAbout();

            return View(about);
        }
    }
}
