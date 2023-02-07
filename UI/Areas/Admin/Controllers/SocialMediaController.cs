using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService socialMediaService;
        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            this.socialMediaService = socialMediaService;
        }

        public IActionResult Update()
        {
            var value = socialMediaService.Get();

            return View(value);

        }

        [HttpPost]
        public IActionResult Update(SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                socialMediaService.Update(socialMedia);

                return RedirectToAction("Index","Blog");
            }
            return View(socialMedia);
        }
    }
}
