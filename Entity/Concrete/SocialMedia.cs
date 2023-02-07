using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class SocialMedia : BaseEntity, IEntity
    {
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Pinterest { get; set; }
    }
}
