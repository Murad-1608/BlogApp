using Business.Abstract;
using Business.Helper;
using Business.ValidationRules;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager, signInManager)
        {
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            bool photoValidation = model.Image.ContentType == "image/jpeg";

            if (photoValidation)
            {

                if (ModelState.IsValid)
                {
                    AppUser user = new AppUser();
                    user.UserName = model.UserName;
                    user.FullName = model.FullName;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Image = SystemIOOperations.AddPhoto(model.Image, "User");
                    IdentityResult result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
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
            else
            {
                ModelState.AddModelError(nameof(model.Image), "Şəkili düzgün formatda seçin");
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser userName = await userManager.FindByNameAsync(model.UserName);
                AppUser userEmail = await userManager.FindByEmailAsync(model.UserName);

                AppUser user = userName ?? userEmail;

                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Blogs", "Writer");
                    }
                }
            }

            ModelState.AddModelError(nameof(model.Password), "İstifadəçi adı və parol yanlışdır");
            return View(model);
        }

        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
