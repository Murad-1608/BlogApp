using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Notification : BaseEntity, IEntity
    {
        public int AppUserId { get; set; }
        public string Type { get; set; }
        public string TypeSymbol { get; set; }
        public string Details { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
