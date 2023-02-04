using Core.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete
{
    public class Blog : BaseEntity, IEntity
    {
        public Blog()
        {
            CreateDate = DateTime.Now;
        }
        public int AppUserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int Seen { get; set; }
        public DateTime CreateDate { get; set; }


        //Relationships
        public Category Category { get; set; }
        public AppUser AppUser { get; set; }
        public List<Blog> Blogs { get; set; }

    }
}
