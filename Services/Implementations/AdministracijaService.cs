using AutoMapper;
using Ispit.Books.Data;
using Ispit.Books.Models.Dbo;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ispit.Books.Services.Interfaces;


namespace Ispit.Books.Services.Implementations
{
    public class AdministracijaService : IAdministracijaService
    {


        private ApplicationDbContext db;



        public AdministracijaService(ApplicationDbContext db)
        {

            this.db = db;

        }

        public async Task<List<Book>> GetBooks()
        {
            return await db.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await db.Books.FirstOrDefaultAsync(y => y.Id == id);
        }

        public async Task AddBookAsync(Book book)
        {
            db.Books.Add(book);
            await db.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book updatedBook)
        {
            db.Books.Update(updatedBook);
            await db.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var bookToDelete = await db.Books.FindAsync(bookId);
            if (bookToDelete != null)
            {
                db.Books.Remove(bookToDelete);
                await db.SaveChangesAsync();
            }
        }

    }
}

