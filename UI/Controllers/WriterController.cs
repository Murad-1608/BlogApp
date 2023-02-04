using Business.Abstract;
using Business.Helper;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        private readonly IBlogService blogService;
        public UserManager<AppUser> userManager;
        public SignInManager<AppUser> signInManager;
        public WriterController(IBlogService blogService, UserManager<AppUser> userManager = null, SignInManager<AppUser> signInManager = null)
        {
            this.blogService = blogService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Blogs()
        {
            var writer = userManager.FindByNameAsync(User.Identity.Name).Result;

            var blogs = blogService.GetListWithCategoryByWriter(writer.Id);

            return View(blogs);
        }

        public IActionResult Update()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;


            UserModel model = new UserModel()
            {
                Email = user.Email,
                FullName = user.FullName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByNameAsync(User.Identity.Name).Result;
                if (model.Image == null)
                {
                }
                else if (model.Image.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError(nameof(model.Image), "Şəkil formatını düzgün seçin");
                    return View(model);
                }
                else if (model.Image.ContentType == "image/jpeg")
                {
                    SystemIOOperations.DeletePhoto("User", user.Image);

                    user.Image = SystemIOOperations.AddPhoto(model.Image, "User");
                }
                user.Email = model.Email;
                user.FullName = model.FullName;
                user.PhoneNumber = model.PhoneNumber;

                IdentityResult result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await signInManager.SignOutAsync();
                    ViewBag.Success = "true";
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel viewModel)
        {
            AppUser user = userManager.FindByNameAsync(User.Identity.Name).Result;

            if (ModelState.IsValid)
            {
                bool check = userManager.CheckPasswordAsync(user, viewModel.Password).Result;

                if (check)
                {
                    IdentityResult result = userManager.ChangePasswordAsync(user, viewModel.Password, viewModel.NewPassword).Result;

                    if (result.Succeeded)
                    {
                        await signInManager.SignOutAsync();
                        return RedirectToAction("Login", "Auth");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(viewModel.Password), "Mövcud parol yanlışdır");
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }
    }

}
