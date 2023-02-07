using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;
        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        public IActionResult Update()
        {
            var value = aboutService.GetLastAbout();
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(About about)
        {
            if (ModelState.IsValid)
            {
                aboutService.Update(about);
            }
            return View(about);
        }
    }
}
