using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Message : BaseEntity, IEntity
    {
        public Message()
        {
            CreateDate = DateTime.Now; 
        }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string? File { get; set; }
        public DateTime CreateDate { get; set; }

        public AppUser Sender { get; set; }
        public AppUser Receiver { get; set; }

    }
}
