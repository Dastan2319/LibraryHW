namespace DLL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DLL.Entity;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
        
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<TakedBooks> TakedBooks { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Ganre> Ganre { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Authors>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Authors)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Books>()
                .HasMany(e => e.TakedBooks)
                .WithOptional(e => e.Books)
                .HasForeignKey(e => e.Books_Id);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.TakedBooks)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId);
        }
    }
}
