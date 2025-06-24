using LibraryApiPrueba.Models;
using System.Net.Http.Json;

namespace LibraryApiPrueba.Services;

public class AuthorService : IAuthorService
{
    private readonly HttpClient _httpClient;
    private const string baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Authors";

    public AuthorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Author>>(baseUrl);
        return result ?? new List<Author>();
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Author>($"{baseUrl}/{id}");
    }

    public async Task<Author> CreateAsync(Author author)
    {
        var response = await _httpClient.PostAsJsonAsync(baseUrl, author);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Author>() ?? throw new Exception("Invalid response");
    }

    public async Task UpdateAsync(int id, Author author)
    {
        var response = await _httpClient.PutAsJsonAsync($"{baseUrl}/{id}", author);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
