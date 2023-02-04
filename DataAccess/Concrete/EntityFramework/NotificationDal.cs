using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class NotificationDal : EfRepositoryBase<Notification, AppDbContext>, INotificationDal
    {
    }
}
