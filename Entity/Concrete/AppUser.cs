using Microsoft.AspNetCore.Identity;

namespace Entity.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string Image { get; set; }

        public ICollection<Message> Sender { get; set; }
        public ICollection<Message> Reveiver { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
