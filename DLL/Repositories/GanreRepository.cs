using DLL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Repositories;

namespace DLL.Repositories
{
    public class GanreRepository : IRepository<Ganre>
    {
        private Model1 db;

        public GanreRepository(Model1 db)
        {
            this.db = db;
        }
        public void Create(Ganre item)
        {
            db.Ganre.Add(item);
        }

        public void Delete(int id)
        {
            Ganre Ganre = db.Ganre.Find(id);
            if (Ganre != null)
                db.Ganre.Remove(Ganre);
        }

        public Ganre Get(int? id)
        {
            return db.Ganre.Find(id);
        }

        public IEnumerable<Ganre> GetAll()
        {
            return db.Ganre;
        }

        public void Update(Ganre item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
