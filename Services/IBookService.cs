using LibraryApiPrueba.DTOs;
using LibraryApiPrueba.Models;

namespace LibraryApiPrueba.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<BookWithAuthorsDto?> GetByIdWithAuthorsAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task UpdateAsync(int id, Book book);
        Task DeleteAsync(int id);
    }
}
