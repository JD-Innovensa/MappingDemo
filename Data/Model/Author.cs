using System.Collections.Generic;

namespace Mapping.Data.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Book> Books { get; set; }


    }
}
