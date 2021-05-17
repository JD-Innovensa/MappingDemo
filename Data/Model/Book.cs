namespace Mapping.Data.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public int Year { get; set; }

        public Author Author { get; set; }
        

    }
}
