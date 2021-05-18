using System.Collections.Generic;

namespace Mapping.Dto
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }

        // Not initialising to check the behaviour of the mapping libraries
        public IEnumerable<BookDto> Books { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double StarRating { get; set; }
    }
}