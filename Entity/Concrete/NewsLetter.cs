using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class NewsLetter : BaseEntity, IEntity
    {
        public string Mail { get; set; }
    }
}
