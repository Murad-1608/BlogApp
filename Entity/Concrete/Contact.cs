using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Contact : BaseEntity, IEntity
    {
        public Contact()
        {
            CreateDate= DateTime.Now;
        }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
