using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CommentDal : EfRepositoryBase<Comment, AppDbContext>, ICommentDal
    {
        public List<Comment> GetCommentsWithUser(int id)
        {
            using AppDbContext context = new();

            return context.Comments.Where(x => x.BlogId == id).Include(x => x.AppUser).ToList();
        }
    }
}
