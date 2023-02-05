using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=BlogAppIdentityData1; Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>()
                .HasOne(x => x.Sender)
                .WithMany(y => y.Sender)
                .HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Message>()
                .HasOne(x => x.Receiver)
                .WithMany(y => y.Reveiver)
                .HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //builder.Entity<Comment>()
            //    .HasOne(x => x.Blog)
            //    .WithMany(y => y.Comments)
            //    .HasForeignKey(x => x.BlogId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(builder);
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
