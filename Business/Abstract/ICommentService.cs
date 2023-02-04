using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetByBlogId(int blogId);
        void Add(Comment comment);
    }

}
