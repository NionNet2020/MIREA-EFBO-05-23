using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Country { get; set; }

        // Связь с книгами
        public ICollection<Book> Books { get; set; }
    }
}
