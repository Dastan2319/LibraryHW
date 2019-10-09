using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int? Pages { get; set; }
        public string Ganre { get; set; }
        public int? Price { get; set; }
        public string Images { get; set; }
    }
}