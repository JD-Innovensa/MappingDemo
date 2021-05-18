using System;
using System.Collections.Generic;

namespace Mapping.Data.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public IEnumerable<Book> Books { get; set; }

        // This is supplemental and not used in DTO to see if the sql is efficient when selecting
        public DateTime? DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // Fictitious rating
        public double StarRating { get; set; }
    }
}