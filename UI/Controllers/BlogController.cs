using Business.Abstract;
using Business.Helper;
using Business.ValidationRules;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogService blogService;
        private readonly ICommentService commentService;
        private readonly ICategoryService categoryService;
        public BlogController(IBlogService blogService, ICommentService commentService,
            UserManager<AppUser> userManager, ICategoryService categoryService, SignInManager<AppUser> signInManager) : base(userManager, signInManager)
        {
            this.blogService = blogService;
            this.commentService = commentService;
            this.categoryService = categoryService;
        }


        public IActionResult Index()
        {
            var blogs = blogService.GetListWithCategory();

            return View(blogs);
        }

        public IActionResult BlogDetails(int id)
        {
            TempData["Id"] = id;

            var blog = blogService.GetById(id);

            blog.Seen++;
            var numberOfComment = commentService.GetByBlogId(blog.Id).Count;
            ViewData["NumberOfComment"] = numberOfComment;

            blogService.Update(blog);

            return View(blog);
        }

        [HttpPost, Authorize]
        public IActionResult AddComment(Comment comment)
        {
            if (User.Identity.IsAuthenticated)
            {
                comment.UserName = appuser.FullName;
                comment.UserImage = appuser.Image;
                comment.Status = true;
                comment.BlogId = Convert.ToInt32(TempData["Id"]);
                commentService.Add(comment);
                int id = comment.BlogId;

                return Ok();
            }

            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var blog = blogService.GetById(id);


            blogService.Delete(blog);

            return RedirectToAction("Blogs", "Writer");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Bloq əlavə et";

            List<SelectListItem> categories = (from i in categoryService.GetAll().ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();

            BlogViewModel viewmodel = new BlogViewModel()
            {
                Categories = categories
            };

            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Add(BlogViewModel viewModel)
        {
            ViewBag.Title = "Bloq əlavə et";

            if (viewModel.BlogModel.Image == null)
            {
                ModelState.AddModelError(nameof(viewModel.BlogModel.Image), "Xahiş olunur şəkil seçin");
            }
            else if (viewModel.BlogModel.Image.ContentType == "image/jpeg")
            {
                var writer = userManager.FindByNameAsync(User.Identity.Name).Result;

                Blog blog = new Blog();

                if (ModelState.IsValid)
                {
                    blog.AppUserId = writer.Id;
                    blog.Title = viewModel.BlogModel.Title;
                    blog.CategoryId = viewModel.BlogModel.CategoryId;
                    blog.Content = viewModel.BlogModel.Content;
                    blog.Image = SystemIOOperations.AddPhoto(viewModel.BlogModel.Image, "Blog");
                    blog.Status = true;
                    blog.Seen = 0;
                    blogService.Add(blog);
                    return RedirectToAction("Blogs", "Writer");
                }
            }
            else
            {
                ModelState.AddModelError(nameof(viewModel.BlogModel.Image), "Xahiş olunur şəkil formatını jpeg seçin");
            }

            List<SelectListItem> categories = (from i in categoryService.GetAll().ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();

            viewModel.Categories = categories;
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Title = "Bloq yenilə";

            try
            {
                var blog = blogService.GetById(id);
                UpdateViewModel viewModel = new UpdateViewModel()
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Content = blog.Content,
                    Image = blog.Image,
                    CategoryId = blog.CategoryId,
                    Seen = blog.Seen,
                };
                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Writer","Blogs");
            }


        }

        [HttpPost]
        public IActionResult Update(UpdateViewModel viewModel)
        {
            ViewBag.Title = "Bloq yenilə";

            if (ModelState.IsValid)
            {
                Blog blog = new Blog();
                blog.Id = viewModel.Id;
                blog.AppUserId = appuser.Id;
                blog.Title = viewModel.Title;
                blog.CategoryId = viewModel.CategoryId;
                blog.Content = viewModel.Content;
                blog.Image = viewModel.Image;
                blog.Seen = viewModel.Seen;
                blog.Status = true;
                blogService.Update(blog);
                return RedirectToAction("Blogs", "Writer");
            }
            return View(viewModel);
        }
    }
}

