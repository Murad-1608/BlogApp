using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.UserLayout
{
    public class SocialMediaFooter : BaseViewComponent
    {
        private readonly ISocialMediaService socialMediaService;
        public SocialMediaFooter(ISocialMediaService socialMediaService, UserManager<AppUser> userManager) : base(userManager)
        {
            this.socialMediaService = socialMediaService;
        }

        public override IViewComponentResult Invoke()
        {
            var value = socialMediaService.Get();

            return View(value);
        }
    }
}
