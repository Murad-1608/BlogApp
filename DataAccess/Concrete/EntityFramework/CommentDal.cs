using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CommentDal : EfRepositoryBase<Comment, AppDbContext>, ICommentDal
    {
    }
}
