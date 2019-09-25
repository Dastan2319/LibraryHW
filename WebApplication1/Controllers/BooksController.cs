using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        UnitOfWork unitOfWork;

        public BooksController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            IEnumerable<Books> books = unitOfWork.Books.GetAll();
            return View(books);
        }

        public ActionResult EditOrCreate(int? id)
        {
            Books books = new Books();
            if (id != null)
            {
                books = unitOfWork.Books.Get(id);

            }
            return View(books);

        }

        [HttpPost]
        public ActionResult EditOrCreate(Books Books)
        {

            if (Books.Id != 0)
            {
                unitOfWork.Books.Update(Books);
                unitOfWork.Save();
            }
            else
            {
                unitOfWork.Books.Create(Books);
                unitOfWork.Save();
            }
            return RedirectToActionPermanent("Index", "Books");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Books.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index", "Books");
        }
    }
}