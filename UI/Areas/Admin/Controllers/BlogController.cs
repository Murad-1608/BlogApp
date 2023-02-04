using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Bloqlar";

            var blogs = blogService.GetAll();

            return View(blogs);
        }
    }
}
