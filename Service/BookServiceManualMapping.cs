using Mapping.Data;
using Mapping.Dto;
using MappingDemo.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingDemo.Service
{
    public class BookServiceManualMapping: IBookService
    {
        public AuthorDto AddAuthor(AuthorDto authorDto)
        {
            if (authorDto == null)
            {
                return null;
            }

            var author = MappingHelper.MapAuthorDtoAuthor(authorDto);

            using var context = new BooksDbContext();

            context.Database.EnsureCreated();

            context.Authors.Add(author);

            context.SaveChanges();

            return MappingHelper.MapAuthorAuthorDto(author);
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
