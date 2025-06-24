using LibraryApiPrueba.DTOs;
using LibraryApiPrueba.Models;
using LibraryApiPrueba.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApiPrueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookWithAuthorsDto>> GetById(int id)
        {
            var result = await _bookService.GetByIdWithAuthorsAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            var created = await _bookService.CreateAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (id != book.Id) return BadRequest("ID mismatch.");
            await _bookService.UpdateAsync(id, book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
