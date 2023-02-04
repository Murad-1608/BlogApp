using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Writer : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }

    }
}
