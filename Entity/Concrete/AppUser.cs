using Microsoft.AspNetCore.Identity;

namespace Entity.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string Image { get; set; }

        //public virtual ICollection<Message> Sender { get; set; }
        //public virtual ICollection<Message> Reveiver { get; set; }
    }
}
