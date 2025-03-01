using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=9Vasa78sho65");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DataContext()
        {

            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);

            
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); 

           
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .HasMaxLength(200)
                .IsRequired();  

          
            modelBuilder.Entity<Book>()
                .Property(b => b.ISBN)
                .HasColumnName("ISBN_Number");
        }
    }
}
