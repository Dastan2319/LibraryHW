using DLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Repositories
{
    public class TakedBooksRepository:IRepository<TakedBooks>
    {
        private Model1 db;

        public TakedBooksRepository(Model1 db)
        {
            this.db = db;
        }
        public void Create(TakedBooks item)
        {
            db.TakedBooks.Add(item);
        }

        public void Delete(int id)
        {
            TakedBooks TakedBooks = db.TakedBooks.Find(id);
            if (TakedBooks != null)
                db.TakedBooks.Remove(TakedBooks);
        }

        public TakedBooks Get(int? id)
        {
            return db.TakedBooks.Find(id);
        }

        public IEnumerable<TakedBooks> GetAll()
        {
            return db.TakedBooks;
        }

        public void Update(TakedBooks item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}