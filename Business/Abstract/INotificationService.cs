using Entity.Concrete;

namespace Business.Abstract
{
    public interface INotificationService
    {
        List<Notification> GetAll();
    }
}
