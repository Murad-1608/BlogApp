using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Writer
{
    public class WriterDetailLeftNavbar : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        public WriterDetailLeftNavbar(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            return View(user);
        }
    }
}
