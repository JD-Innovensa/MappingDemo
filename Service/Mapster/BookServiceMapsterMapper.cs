using Mapping.Data;
using Mapping.Data.Models;
using Mapping.Dto;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MappingDemo.Service.Mapster
{
    public class BookServiceMapsterMapper : IBookService
    {
        public BookServiceMapsterMapper()
        {
            // Added config here for simplicity
            TypeAdapterConfig<Book, BookWithAuthorDto>.NewConfig()
                .Map(dest => dest.AuthorFullName, src => string.Format("{0} {1}", src.Author.FirstName, src.Author.LastName));
        }

        public AuthorDto AddAuthor(AuthorDto authorDto)
        {
            if (authorDto == null)
            {
                return null;
            }

            // MapsterMapper
            var author = authorDto.Adapt<Author>();

            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            context.Authors.Add(author);

            context.SaveChanges();

            // MapsterMapper - overwrite changes in original dto
            author.Adapt(authorDto);

            return authorDto;
        }

        public AuthorDto GetAuthor(int id)
        {
            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            var author = context.Authors.Find(id);

            // MapsterMapper
            var authorDto = author.Adapt<AuthorDto>();

            return authorDto;
        }

        public AuthorDto GetAuthorWithBooks(int id)
        {
            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            // MapsterMapper Projection
            var authorDto = context.Authors
                .Include(x => x.Books)
                .ProjectToType<AuthorDto>()
                .First(x => x.AuthorId == id);

            return authorDto;
        }

        public BookWithAuthorDto GetBookWithAuthor(int id)
        {
            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            var book = context.Books
                .Include(x => x.Author)
                .First(x => x.AuthorId == id);

            // MapsterMapper
            var anotherBookDto = book.Adapt<BookWithAuthorDto>();

            return anotherBookDto;
        }
    }
}