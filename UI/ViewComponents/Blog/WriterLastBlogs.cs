using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Blog
{
    public class WriterLastBlogs : ViewComponent
    {
        private readonly IBlogService blogService;
        public WriterLastBlogs(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke(int writerId)
        {
            var blogs = blogService.GetBlogListByWriter(writerId).TakeLast(3).ToList();

            return View(blogs);
        }
    }
}
