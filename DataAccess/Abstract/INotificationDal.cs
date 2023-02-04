using Core.DataAccess;
using Core.Entity.Abstract;
using Entity.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface INotificationDal : IRepositoryBase<Notification>
    {
    }
}
