using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private Model1 db = new Model1();
        private BookRepository bookRepository;
        private UsersRepository usersRepository;
        private AuthorsRepository authorsRepository;
        private TakedBooksRepository takedBooksRepository;

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public UsersRepository Users
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new UsersRepository(db);
                return usersRepository;
            }
        }
        public AuthorsRepository Authors
        {
            get
            {
                if (authorsRepository == null)
                    authorsRepository = new AuthorsRepository(db);
                return authorsRepository;
            }
        }
        public TakedBooksRepository TakedBooks
        {
            get
            {
                if (takedBooksRepository == null)
                    takedBooksRepository = new TakedBooksRepository(db);
                return takedBooksRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}