using Mapping.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mapping.Data
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
                             
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Books.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Author>().ToTable("Authors");


            modelBuilder.Entity<Author>().HasData(new Author { AuthorId = 1, FirstName = "Ian", LastName = "Flemming" });
            modelBuilder.Entity<Author>().HasData(new Author { AuthorId = 2, FirstName = "John", LastName = "le Carré" });

            modelBuilder.Entity<Book>().HasData(new Book { BookId = 1, Title = "Casino Royale", Year = 1953, AuthorId = 1 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 2, Title = "Live and Let Die", Year = 1954, AuthorId = 1 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 3, Title = "Moonraker", Year = 1955, AuthorId = 1 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 4, Title = "Diamonds Are Forever", Year = 1956, AuthorId = 1 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 5, Title = "From Russia, with Love", Year = 1957, AuthorId = 1 });            
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 6, Title = "Dr. No", Year = 1958, AuthorId = 1 });

            modelBuilder.Entity<Book>().HasData(new Book { BookId = 7, Title = "Call for the Dead", Year = 1961, AuthorId = 2 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 8, Title = "A Murder of Quality", Year = 1962, AuthorId = 2 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 9, Title = "The Spy Who Came In from the Cold", Year = 1963, AuthorId = 2 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 10, Title = "The Looking Glass War", Year = 1965, AuthorId = 2 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 11, Title = "Tinker Tailor Soldier Spy", Year = 1974, AuthorId = 2 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 12, Title = "The Honourable Schoolboy", Year = 1977, AuthorId = 2 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 13, Title = "Smiley's People", Year = 1979, AuthorId = 2 });
        }

    }
}
