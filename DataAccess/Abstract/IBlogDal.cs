using Core.DataAccess;
using Core.Entity.Abstract;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IRepositoryBase<Blog>
    {
        List<Blog> GetListWithCategory(System.Linq.Expressions.Expression<Func<Blog, bool>> filter = null);
    }
}
