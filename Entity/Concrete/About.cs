using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class About : BaseEntity, IEntity
    {
        public string Details { get; set; }
        public string Image { get; set; }
        public string MapLocation { get; set; }
    }
}
