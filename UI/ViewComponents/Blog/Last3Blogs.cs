using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Blog
{
    public class Last3Blogs : ViewComponent
    {
        private readonly IBlogService blogService;
        public Last3Blogs(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var blog = blogService.Last3Blogs();
            return View(blog);
        }
    }
}
