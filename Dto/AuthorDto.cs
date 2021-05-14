using System.Collections.Generic;

namespace Mapping.Dto
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<BookDto> Books { get; set; }
    }
}
