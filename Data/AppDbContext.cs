using Microsoft.EntityFrameworkCore;
using my_book.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                 .HasOne(b => b.Book)
                 .WithMany(a => a.Book_Authors)
                 .HasForeignKey(f => f.BookId);

            modelBuilder.Entity<Book_Author>()
                 .HasOne(b => b.Author)
                 .WithMany(a => a.Book_Authors)
                 .HasForeignKey(f => f.AuthorId);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }


    }
}
