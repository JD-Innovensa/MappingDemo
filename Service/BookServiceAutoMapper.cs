using AutoMapper;
using Mapping.Data;
using Mapping.Data.Models;
using Mapping.Dto;
using MappingDemo.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingDemo.Service
{
    public class BookServiceAutoMapper : IBookService
    {
        static MapperConfiguration Config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<BookMappingProfile>();
        });

        private Mapper mapper;

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

            var author = context.Authors
                .Include(x => x.Books)
                .First(x => x.AuthorId == id);

            // Automapper
            var authorDto = mapper.Map<AuthorDto>(author);

            return authorDto;
        }
    }
}
