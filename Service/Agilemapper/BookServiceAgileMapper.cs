﻿using AgileObjects.AgileMapper;
using Mapping.Data;
using Mapping.Data.Models;
using Mapping.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MappingDemo.Service.Agilemapper
{
    public class BookServiceAgileMapper : IBookService
    {
        public BookServiceAgileMapper()
        {
            // Added config here for simplicity
            Mapper.WhenMapping
            .From<Book>()
            .To<BookWithAuthorDto>()
            .Map(ctx => string.Format("{0} {1}", ctx.Source.Author.FirstName, ctx.Source.Author.LastName))
            .To(dto => dto.AuthorFullName);
        }

        public AuthorDto AddAuthor(AuthorDto authorDto)
        {
            if (authorDto == null)
            {
                return null;
            }

            // AgileMapper
            var author = Mapper.Map(authorDto).ToANew<Author>();

            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            context.Authors.Add(author);

            context.SaveChanges();

            // AgileMapper - overwrite changes in original dto
            return Mapper.Map(author).Over(authorDto);
        }

        public AuthorDto GetAuthor(int id)
        {
            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            var author = context.Authors.Find(id);

            // AgileMapper
            var authorDto = Mapper.Map(author).ToANew<AuthorDto>();

            return authorDto;
        }

        public AuthorDto GetAuthorWithBooks(int id)
        {
            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            // AgileMapper Projection
            var authorDto = context.Authors
                .Include(x => x.Books)
                .Project().To<AuthorDto>()
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

            // AgileMapper
            var anotherBookDto = Mapper.Map(book).ToANew<BookWithAuthorDto>();

            return anotherBookDto;
        }
    }
}