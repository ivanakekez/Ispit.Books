using Ispit.Books.Models.Dbo;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Ispit.Books.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Publisher> Addresss { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>().HasData(
                    new Author
                    {
                        Id = 1,
                        FirstName= "Test1",
                        LastName= "Test1",
                        
                    },
                    new Author
                    {
                        Id = 2,
                        FirstName = "Test2",
                        LastName = "Test2",

                    },
                    new Author
                    {
                        Id = 3,
                        FirstName = "Test3",
                        LastName = "Test3"

                    },
                    new Author
                    {
                        Id = 4,
                        FirstName = "Test4",
                        LastName = "Test4",

                    },
                    new Author
                    {
                        Id = 5,
                        FirstName = "Test5",
                        LastName = "Test5",

                    }
            );



            modelBuilder.Entity<Publisher>().HasData(
                    new Publisher
                    {
                        Id = 1,
                        Name="Publisher1"

                    },
                    new Publisher
                    {
                        Id = 2,
                        Name = "Publisher1"

                    }
                );


            modelBuilder.Entity<Book>().HasData(
                   new Book
                   {
                       Id = 1,
                       Name = "Prva knjiga"

                   },
                   new Publisher
                   {
                       Id = 2,
                       Name = "Druga knjiga"

                   }
               );






            modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany()
             .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.ApplicationUser)
                .WithMany()
                .HasForeignKey(b => b.ApplicationUserId);





            base.OnModelCreating(modelBuilder);
        }


    }
}
