using Core.DataAccess;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IRepositoryBase<Comment>
    {
        List<Comment> GetCommentsWithUser(int id);
    }
}
