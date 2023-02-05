using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class MessageDal : EfRepositoryBase<Message, AppDbContext>, IMessageDal
    {
        public List<Message> GetWithReceiver(int id)
        {
            using (AppDbContext context = new())
            {
                return context.Messages.Where(x => x.Status == true && x.ReceiverId == id).Include(x => x.Sender).ToList();
            }
        }

        public List<Message> GetWithSender(int id)
        {
            using (AppDbContext context = new())
            {
                return context.Messages.Where(x => x.Status == true && x.SenderId == id).Include(x => x.Receiver).ToList();
            }
        }
    }
}
