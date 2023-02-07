using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Writer
{
    public class WriterNameAndSurname : BaseViewComponent
    {
        public WriterNameAndSurname(UserManager<AppUser> userManager) : base(userManager)
        {
        }

        public override IViewComponentResult Invoke()
        {
            AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            return View(user);
        }
    }
}
