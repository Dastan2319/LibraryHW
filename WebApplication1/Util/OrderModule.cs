using BLL.Interfaces;
using BLL.Service;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Util
{
    public class OrderModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthorService>().To<AuthorService>();
            Bind<IBookService>().To<BookService>();
            Bind<IUsersService>().To<UsersService>();
            Bind<ITakedBooksService>().To<TakedBooksService>();
        }
    }
}