using LibraryApiPrueba.Models;

namespace LibraryApiPrueba.DTOs
{
    public class BookWithAuthorsDto
    {
        public Book Book { get; set; }
        public List<Author> Authors { get; set; } = new();
    }

}
