using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class AboutDal : EfRepositoryBase<About, AppDbContext>, IAboutDal
    {
    }
}
