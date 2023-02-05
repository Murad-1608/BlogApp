using Core.DataAccess;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IMessageDal : IRepositoryBase<Message>
    {
        List<Message> GetWithReceiver(int id);
        List<Message> GetWithSender(int id);
    }
}
