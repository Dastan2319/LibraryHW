using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class TakedBooksController : Controller
    {
        UnitOfWork unitOfWork;

        public TakedBooksController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            IEnumerable<TakedBooks> TakedBooks = unitOfWork.TakedBooks.GetAll();
            return View(TakedBooks);
        }

        public ActionResult EditOrCreate(int? id)
        {
            TakedBooks TakedBooks = new TakedBooks();
            if (id != null)
            {
                TakedBooks = unitOfWork.TakedBooks.Get(id);

            }
            return View(TakedBooks);

        }

        [HttpPost]
        public ActionResult EditOrCreate(TakedBooks TakedBooks)
        {

            if (TakedBooks.id != 0)
            {
                unitOfWork.TakedBooks.Update(TakedBooks);
                unitOfWork.Save();
            }
            else
            {
                unitOfWork.TakedBooks.Create(TakedBooks);
                unitOfWork.Save();
            }

            return RedirectToActionPermanent("Index", "TakedBooks");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.TakedBooks.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index", "TakedBooks");
        }
    }
}