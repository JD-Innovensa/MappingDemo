using Mapping.Dto;

namespace MappingDemo.Service
{
    public interface IBookService
    {
        public AuthorDto GetAuthor(int id);
        public AuthorDto GetAuthorWithBooks(int id);

        public AuthorDto AddAuthor(AuthorDto authorDto);
    }
}
