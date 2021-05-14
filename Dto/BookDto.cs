using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mapping.Dto
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public int Year { get; set; }

    }
}
