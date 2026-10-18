using Microsoft.EntityFrameworkCore;
using Peter_Darius_Lab2.Models;

namespace Peter_Darius_Lab2.Data
{
    public class Peter_Darius_Lab2Context : DbContext
    {
        public Peter_Darius_Lab2Context (DbContextOptions<Peter_Darius_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Peter_Darius_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Peter_Darius_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Peter_Darius_Lab2.Models.Author> Author { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // daca stergem o editura / un autor, cartile raman, doar FK-ul devine NULL
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
