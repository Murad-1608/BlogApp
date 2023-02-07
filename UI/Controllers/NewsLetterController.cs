using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class NewsLetterController : BaseController
    {
        private readonly INewsLetterService newsletterService;
        public NewsLetterController(INewsLetterService newsletterService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager, signInManager)
        {
            this.newsletterService = newsletterService;
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [Authorize]
        public IActionResult Subscribe()
        {
            NewsLetter newsLetter = new NewsLetter()
            {
                Mail = userManager.FindByNameAsync(User.Identity.Name).Result.Email,
                Status = true
            };
            newsletterService.Add(newsLetter);

            return Ok();

        }
    }
}
