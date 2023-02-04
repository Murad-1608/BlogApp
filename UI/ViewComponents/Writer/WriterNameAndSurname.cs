using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Writer
{
    public class WriterNameAndSurname : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        public WriterNameAndSurname(UserManager<AppUser> userManager)
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
