namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            TakedBooks = new HashSet<TakedBooks>();
        }

        public int Id { get; set; }

        public int AuthorId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public int? Pages { get; set; }

        public int? Price { get; set; }

        public virtual Authors Authors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TakedBooks> TakedBooks { get; set; }
    }
}
