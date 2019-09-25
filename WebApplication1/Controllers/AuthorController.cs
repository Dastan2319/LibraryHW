using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class AuthorController : Controller
    {
        UnitOfWork unitOfWork;

        public AuthorController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            IEnumerable<Authors> authors=unitOfWork.Authors.GetAll();
            return View(authors);
        }
      
        public ActionResult EditOrCreate(int? id)
        {
            Authors author = new Authors();
            if (id != null)
            {
                  author = unitOfWork.Authors.Get(id);
                
            }
            return View(author);

        }

        [HttpPost]
        public ActionResult EditOrCreate(Authors author)
        {
            
                if (author.Id != 0)
                {
                    unitOfWork.Authors.Update(author);
                    unitOfWork.Save();
                }
                else
                {
                    unitOfWork.Authors.Create(author);
                    unitOfWork.Save();
                }
            
            return RedirectToActionPermanent("Index", "Author");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Authors.Delete(id);
            unitOfWork.Save();           
            return RedirectToAction("Index", "Author");
        }
    }
}