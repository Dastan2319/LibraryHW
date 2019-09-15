namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TakedBooks
    {
        public int id { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public int? Books_Id { get; set; }

        public virtual Books Books { get; set; }

        public virtual Users Users { get; set; }
    }
}
