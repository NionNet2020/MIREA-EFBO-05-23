using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Связь с книгами
        public ICollection<Book> Books { get; set; }
    }
}
