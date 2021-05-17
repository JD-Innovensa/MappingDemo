namespace Mapping.Dto
{
    public class BookWithAuthorDto
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        // This is wrong type the source type is int
        public byte Year { get; set; }

        // Flattening
        public double AuthorStarRating { get; set; }

        // Use config to map
        public string AuthorFullName { get; set; }

    }
}
