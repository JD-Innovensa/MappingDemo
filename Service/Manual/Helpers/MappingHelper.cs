using Mapping.Data.Models;
using Mapping.Dto;
using System.Linq;

namespace MappingDemo.Service.Manual.Helpers
{
    public static class MappingHelper
    {
        public static AuthorDto MapAuthorAuthorDto(Author author)
        {
            return author != null ? new AuthorDto
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
                StarRating = author.StarRating,
                Books = author.Books?.Select(x => MapBookBookDto(x))
            } : null;
        }

        public static Author MapAuthorDtoAuthor(AuthorDto authorDto)
        {
            return authorDto != null ? new Author
            {
                AuthorId = authorDto.AuthorId,
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
            } : null;
        }

        public static BookWithAuthorDto MapBookAnotherBookDto(Book book)
        {
            return book != null ? new BookWithAuthorDto
            {
                AuthorId = book.AuthorId,
                BookId = book.BookId,
                Title = book.Title,
                AuthorStarRating = book.Author.StarRating,
                AuthorFullName = book.Author?.FirstName + " " + book.Author?.LastName
            } : null;
        }

        public static BookDto MapBookBookDto(Book book)
        {
            return book != null ? new BookDto
            {
                AuthorId = book.AuthorId,
                BookId = book.BookId,
                Title = book.Title,
                Year = book.Year
            } : null;
        }
    }
}