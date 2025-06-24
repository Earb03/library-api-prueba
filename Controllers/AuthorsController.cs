using LibraryApiPrueba.Models;
using LibraryApiPrueba.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApiPrueba.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAll()
    {
        var authors = await _authorService.GetAllAsync();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> GetById(int id)
    {
        var author = await _authorService.GetByIdAsync(id);
        if (author == null) return NotFound();
        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<Author>> Create(Author author)
    {
        var created = await _authorService.CreateAsync(author);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Author author)
    {
        if (id != author.Id)
            return BadRequest("ID mismatch");

        await _authorService.UpdateAsync(id, author);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _authorService.DeleteAsync(id);
        return NoContent();
    }
}
