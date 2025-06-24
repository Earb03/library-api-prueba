namespace LibraryApiPrueba.Models
{
    public class Author
    {
        public int Id { get; set; }
        public int IdBook { get; set; }  // Relación con Book
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
