using Ispit.Books.Models.Dbo;

namespace Ispit.Books.Services.Interfaces
{
    public interface IAdministracijaService
    {
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(int bookId);
        Task<List<Book>> GetBooks();
        Task UpdateBookAsync(Book updatedBook);

        Task<Book> GetBook(int id);
    }
}