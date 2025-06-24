using LibraryApiPrueba.DTOs;
using LibraryApiPrueba.Models;

namespace LibraryApiPrueba.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
        private const string AuthorUrl = "https://fakerestapi.azurewebsites.net/api/v1/Authors";
        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Book>>(baseUrl);
            return result ?? new List<Book>();
        }

        public async Task<BookWithAuthorsDto?> GetByIdWithAuthorsAsync(int id)
        {
            var book = await _httpClient.GetFromJsonAsync<Book>($"{baseUrl}/{id}");
            if (book == null) return null;

            var authors = await _httpClient.GetFromJsonAsync<List<Author>>(AuthorUrl);
            var relatedAuthors = authors?.Where(a => a.IdBook == id).ToList() ?? new List<Author>();

            return new BookWithAuthorsDto
            {
                Book = book,
                Authors = relatedAuthors
            };
        }


        public async Task<Book> CreateAsync(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync(baseUrl, book);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Book>() ?? throw new Exception("Invalid response");
        }

        public async Task UpdateAsync(int id, Book book)
        {
            var response = await _httpClient.PutAsJsonAsync($"{baseUrl}/{id}", book);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
