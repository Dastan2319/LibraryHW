using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Repositories
{
    public class UsersRepository:IRepository<Users>
    {
        private Model1 db;

        public UsersRepository(Model1 db)
        {
            this.db = db;
        }
        public void Create(Users item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            Users Users = db.Users.Find(id);
            if (Users != null)
                db.Users.Remove(Users);
        }

        public Users Get(int? id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<Users> GetAll()
        {
            return db.Users;
        }

        public void Update(Users item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}