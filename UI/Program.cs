using Mapping.Dto;
using MappingDemo.Service;
using MappingDemo.Service.Agilemapper;
using MappingDemo.Service.Automapper;
using MappingDemo.Service.Manual;
using MappingDemo.Service.Mapster;
using System;
using System.Collections.Generic;

namespace MappingDemo
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Mapping demo");

            List<IBookService> services = new()
            {
                new BookServiceManualMapping(),
                new BookServiceAutoMapper(),
                new BookServiceAgileMapper(),
                new BookServiceMapsterMapper()
            };

            foreach (IBookService service in services)
            {
                Console.WriteLine($"Running for type {service.GetType().Name}");

                var authorDto = service.GetAuthor(1);

                Console.WriteLine("1. Get First Author Without Books:");

                WriteAuthor(authorDto);

                Console.WriteLine("2. Get Second Author With Books:");

                var authorWithBooks = service.GetAuthorWithBooks(2);

                WriteAuthor(authorWithBooks);

                Console.WriteLine("3. Add new author without books:");

                var newAuthor = new AuthorDto
                {
                    FirstName = "Ben",
                    LastName = "Macintyre"
                };

                var author = service.AddAuthor(newAuthor);

                WriteAuthor(author);

                Console.WriteLine("4. Get book with author info:");

                var anotherbook = service.GetBookWithAuthor(2);

                WriteAnotherBook(anotherbook);

                Console.WriteLine("-----------------------");
            }
        }

        private static void WriteAnotherBook(BookWithAuthorDto anotherBookDto)
        {
            Console.WriteLine($"Book Id: {anotherBookDto.BookId}, Title: {anotherBookDto.Title}, Year (byte!): {anotherBookDto.Year}, Author Fullname: {anotherBookDto.AuthorFullName}, Author Rating: {anotherBookDto.AuthorStarRating}");
        }

        private static void WriteAuthor(AuthorDto authorDto)
        {
            Console.WriteLine($"AuthorId : {authorDto.AuthorId}, FirstName: {authorDto.FirstName}, Last Name: {authorDto.LastName}, Books: {(authorDto.Books != null ? "" : "NULL")}");

            if (authorDto.Books != null)
            {
                foreach (BookDto bookDto in authorDto.Books)
                {
                    WriteBook(bookDto);
                }
            }
        }

        private static void WriteBook(BookDto bookDto)
        {
            Console.WriteLine($"{bookDto.BookId}, {bookDto.Title}, {bookDto.Year}");
        }
    }
}