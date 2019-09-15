using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TakedBooksController : Controller
    {
        public ActionResult Index()
        {
            List<TakedBooks> TakedBooks;
            using (Model1 db = new Model1())
            {
                TakedBooks = db.TakedBooks.ToList();

            }
            return View(TakedBooks);
        }

        public ActionResult EditOrCreate(int? id)
        {
            TakedBooks TakedBooks = new TakedBooks();
            if (id != null)
            {
                using (Model1 db = new Model1())
                {
                    TakedBooks = db.TakedBooks.Where(a => a.id == id).FirstOrDefault();
                }
            }
            return View(TakedBooks);

        }

        [HttpPost]
        public ActionResult EditOrCreate(TakedBooks TakedBooks)
        {
            using (Model1 db = new Model1())
            {
             

                if (TakedBooks.id != 0)
                {
                    var TakedBooksTemp = db.TakedBooks.Where(a => a.id == TakedBooks.id).FirstOrDefault();
                    TakedBooksTemp.BookId = TakedBooks.BookId;
                    TakedBooksTemp.UserId = TakedBooks.UserId;
                }
                else
                {
                    TakedBooks.Books = db.Books.Where(x => x.Id == TakedBooks.Books_Id).FirstOrDefault();
                    TakedBooks.Users = db.Users.Where(x => x.Id == TakedBooks.UserId).FirstOrDefault();
                    db.TakedBooks.Add(TakedBooks);
                }
                db.SaveChanges();
            }
            return RedirectToActionPermanent("Index", "TakedBooks");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var TakedBooks = db.TakedBooks.Where(a => a.id == id).FirstOrDefault();
                db.TakedBooks.Remove(TakedBooks);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "TakedBooks");
        }
    }
}