using Mapping.Dto;

namespace MappingDemo.Service
{
    public interface IBookService
    {
        public AuthorDto AddAuthor(AuthorDto authorDto);

        public AuthorDto GetAuthor(int id);

        public AuthorDto GetAuthorWithBooks(int id);

        public BookWithAuthorDto GetBookWithAuthor(int id);
    }
}