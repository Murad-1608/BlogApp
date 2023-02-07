using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public abstract class BaseViewComponent : ViewComponent
    {
        public readonly UserManager<AppUser> userManager;
        public AppUser appUser => userManager.FindByNameAsync(User.Identity.Name).Result;

        public BaseViewComponent(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public abstract IViewComponentResult Invoke();
        
    }
}
