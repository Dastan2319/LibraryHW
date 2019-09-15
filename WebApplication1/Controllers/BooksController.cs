using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            List<Books> Books;
            using (Model1 db = new Model1())
            {
                Books = db.Books.ToList();

            }
            return View(Books);
        }

        public ActionResult EditOrCreate(int? id)
        {
            Books Books = new Books();
            if (id != null)
            {
                using (Model1 db = new Model1())
                {
                    Books = db.Books.Where(a => a.Id == id).FirstOrDefault();
                }
            }
            return View(Books);

        }

        [HttpPost]
        public ActionResult EditOrCreate(Books Books)
        {
            using (Model1 db = new Model1())
            {
                if (Books.Id != 0)
                {
                    var BooksTemp = db.Books.Where(a => a.Id == Books.Id).FirstOrDefault();
                    BooksTemp.Title = Books.Title;
                    BooksTemp.Price = Books.Price;
                    BooksTemp.Pages = Books.Pages;
                    BooksTemp.AuthorId = Books.AuthorId;

                }
                else
                {
                    Books.Authors = db.Authors.Where(x => x.Id == Books.AuthorId).FirstOrDefault();
                    db.Books.Add(Books);
                }
                db.SaveChanges();
            }
            return RedirectToActionPermanent("Index", "Books");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var Books = db.Books.Where(a => a.Id == id).FirstOrDefault();
                db.Books.Remove(Books);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Books");
        }
    }
}