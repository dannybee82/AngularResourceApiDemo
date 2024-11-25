using ExampleBooksRepository.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksRepository
{
    public class MainDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }


        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add some default data to database.

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Name = "White Seal Publishing"
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Penguin Publishing Inc."
                },
                new Publisher
                {
                    Id = 3,
                    Name = "Artic Publishing"
                }
            );


            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "Saskia",
                    MiddleName = "des",
                    LastName = "Esseintes",
                    DayOfBirth = DateTime.Parse("1988-03-21")
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Matilda",
                    MiddleName = "du",
                    LastName = "Mal",
                    DayOfBirth = DateTime.Parse("1987-09-30")
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Juliette",
                    MiddleName = "",
                    LastName = "Wolpertinger",
                    DayOfBirth = DateTime.Parse("1989-06-12")
                }
            );


            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Programming basics",
                    Description = "learning the basics of programming.",
                    ISBN = "1234567890",
                    AuthorId = 1,
                    PublisherId = 1,
                    DateCreated = DateTime.Parse("2024-06-08 09:00:00")
                },
                new Book
                {
                    Id = 2,
                    Title = "Docker Essentials",
                    Description = "Learning the essentials of Docker and Docker-Compose.",
                    ISBN = "1234567891",
                    AuthorId = 2,
                    PublisherId = 2,
                    DateCreated = DateTime.Parse("2024-06-08 09:00:00")
                }
                ,
                new Book
                {
                    Id = 3,
                    Title = "Old School PHP",
                    Description = "For all of those with nostalgic feelings.",
                    ISBN = "1234567893",
                    AuthorId = 3,
                    PublisherId = 3,
                    DateCreated = DateTime.Parse("2024-06-08 09:00:00")
                }
            );

        }

    }

}