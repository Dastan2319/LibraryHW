using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Repositories
{
    public class BookRepository : IRepository<Books>
    {
        private Model1 db;

        public BookRepository(Model1 db)
        {
            this.db = db;
        }


        public void Create(Books item)
        {
            db.Books.Add(item);
        }

        public void Delete(int id)
        {
            Books book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }

        public Books Get(int? id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Books> GetAll()
        {
            return db.Books;
        }

        public void Update(Books item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}