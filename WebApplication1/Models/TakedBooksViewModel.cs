using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TakedBooksViewModel
    {
        public int id { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public int? Books_Id { get; set; }
    }
}