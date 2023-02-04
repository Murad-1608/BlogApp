using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
