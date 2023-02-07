using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            this.commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            commentDal.Add(comment);
        }

        public List<Comment> GetByBlogId(int blogId)
        {
            return commentDal.GetCommentsWithUser(blogId);
        }
    }
}
