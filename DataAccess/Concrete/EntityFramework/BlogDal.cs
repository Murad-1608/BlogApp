using Core.DataAccess.MsSql;
using Core.Entity.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class BlogDal : EfRepositoryBase<Blog, AppDbContext>, IBlogDal
    {
        public List<Blog> GetListWithCategory(System.Linq.Expressions.Expression<Func<Blog, bool>> filter = null)
        {
            using (AppDbContext context = new())
            {
                return filter == null ? context.Blogs.Where(x => x.Status == true).Include(x => x.Category).ToList() :
                                        context.Blogs.Where(filter).Include(x => x.Category).ToList();
            }
        }
     
    }
}
