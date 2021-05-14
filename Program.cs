using AutoMapper;
using Mapping.Dto;
using MappingDemo.Service;
using System;

namespace MappingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mapping demo");

           // ManualMapping();

            Automapper();

        }

        static void ManualMapping()
        {
            var service = new BookServiceManualMapping();

            var authorDto = service.GetAuthor(1);

            var authorWithBooks = service.GetAuthorWithBooks(2);

            var newAuthor = new AuthorDto
            {
                FirstName = "Ben",
                LastName = "Macintyre"
            };

            var author = service.AddAuthor(newAuthor);
        }

        static void Automapper()
        {
            var service = new BookServiceAutoMapper();

            var authorDto = service.GetAuthor(1);

            var authorWithBooks = service.GetAuthorWithBooks(2);

            var newAuthor = new AuthorDto
            {
                FirstName = "Ben",
                LastName = "Macintyre"
            };

            var author = service.AddAuthor(newAuthor);
        }
    }
}
