using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Blog
{
    public class LastestBlog : ViewComponent
    {
        private readonly IBlogService blogService;
        public LastestBlog(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var blog = blogService.LastestBlog();
            return View(blog);
        }
    }
}
