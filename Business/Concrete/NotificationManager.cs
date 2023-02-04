using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            this.notificationDal = notificationDal;
        }

        public List<Notification> GetAll()
        {
            return notificationDal.GetAll();
        }
    }
}
