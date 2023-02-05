using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public void Add(Message message)
        {
            messageDal.Add(message);
        }

        public void Delete(int id)
        {
            var value = messageDal.Get(x => x.Id == id);

            messageDal.Delete(value);
        }

        public List<Message> GetReceiverMessage(int id)
        {
            return messageDal.GetWithReceiver(id);
        }
        public List<Message> GetSenderMessage(int id)
        {
            return messageDal.GetWithSender(id);
        }

        public Message ViewMessage(int id)
        {
            return messageDal.Get(x => x.Id == id);
        }
    }
}
