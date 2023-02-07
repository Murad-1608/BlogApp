using Entity.Concrete;

namespace UI.Models.ViewModels
{
    public class BlogAndCommentViewModel
    {
        public Blog Blog { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
