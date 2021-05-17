using Mapping.Data;
using Mapping.Dto;
using MappingDemo.Service.Manual.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MappingDemo.Service.Manual
{
    public class BookServiceManualMapping: IBookService
    {
        public AuthorDto AddAuthor(AuthorDto authorDto)
        {
            if (authorDto == null)
            {
                return null;
            }

            // Manual map
            var author = MappingHelper.MapAuthorDtoAuthor(authorDto);

            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            context.Authors.Add(author);

            context.SaveChanges();

            // Manual map
            return MappingHelper.MapAuthorAuthorDto(author);
        }

        public BookWithAuthorDto GetBookWithAuthor(int id)
        {
            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            var book = context.Books
                .Include(x => x.Author)
                .First(x => x.AuthorId == id);

            // Manual map
            var anotherBookDto = MappingHelper.MapBookAnotherBookDto(book);

            return anotherBookDto;
        }

        public AuthorDto GetAuthor(int id)
        {
            using var context = new BooksDbContext();
            
            context.Database.EnsureCreated();

            var author = context.Authors.Find(id);

            // Manual map
            var authorDto = MappingHelper.MapAuthorAuthorDto(author);

            return authorDto;
        }

        public AuthorDto GetAuthorWithBooks(int id)
        {
            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            var author = context.Authors
                .Include(x => x.Books)
                .First(x => x.AuthorId == id);

            // Manual map
            var authorDto = MappingHelper.MapAuthorAuthorDto(author);

            return authorDto;
        }

    }
}
