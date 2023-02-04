using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class GetComments : ViewComponent
    {
        private readonly ICommentService commentService;
        public GetComments(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IViewComponentResult Invoke(int blogId)
        {
            var values = commentService.GetByBlogId(blogId);

            return View(values);
        }
    }
}
