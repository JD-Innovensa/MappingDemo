using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mapping.Data;
using Mapping.Data.Models;
using Mapping.Dto;
using MappingDemo.Service.Automapper.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MappingDemo.Service.Automapper
{
    public class BookServiceAutoMapper : IBookService
    {
        private static readonly MapperConfiguration Config = new(cfg =>
           {
               cfg.AddProfile<BookMappingProfile>();
           });

        private readonly Mapper mapper;

        public BookServiceAutoMapper()
        {
            mapper = new Mapper(Config);
        }

        public AuthorDto AddAuthor(AuthorDto authorDto)
        {
            if (authorDto == null)
            {
                return null;
            }

            // Automapper
            var author = mapper.Map<Author>(authorDto);

            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            context.Authors.Add(author);

            context.SaveChanges();

            // Automapper
            return mapper.Map<AuthorDto>(author);
        }

        public AuthorDto GetAuthor(int id)
        {
            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            var author = context.Authors.Find(id);

            // Automapper
            var authorDto = mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public AuthorDto GetAuthorWithBooks(int id)
        {
            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            // Automapper Projection
            var authorDto = context.Authors
                .Include(x => x.Books)
                .ProjectTo<AuthorDto>(Config)
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

            // Automapper
            var anotherBookDto = mapper.Map<BookWithAuthorDto>(book);

            return anotherBookDto;
        }
    }
}