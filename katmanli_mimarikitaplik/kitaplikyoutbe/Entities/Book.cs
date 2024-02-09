using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kitaplikyoutbe.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ISBN { get; set; }

        public int categoryId { get; set; }

        public category category { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }




    }
}
