using Core.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete
{
    public class Comment : BaseEntity, IEntity
    {
        public Comment()
        {
            CreateDate = DateTime.Now;
        }
        public int BlogId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }

        //Relationships
        public  Blog Blog { get; set; }
    }
}
