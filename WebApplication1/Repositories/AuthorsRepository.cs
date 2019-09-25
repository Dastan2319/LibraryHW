using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Repositories
{
    public class AuthorsRepository : IRepository<Authors>
    {
        private Model1 db;

        public AuthorsRepository(Model1 db)
        {
            this.db = db;
        }
        public void Create(Authors item)
        {
            db.Authors.Add(item);
        }

        public void Delete(int id)
        {
            Authors Authors = db.Authors.Find(id);
            if (Authors != null)
                db.Authors.Remove(Authors);
        }

        public Authors Get(int? id)
        {
            return db.Authors.Find(id);
        }

        public IEnumerable<Authors> GetAll()
        {
            return db.Authors;
        }

        public void Update(Authors item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}