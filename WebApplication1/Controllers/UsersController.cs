using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        UnitOfWork unitOfWork;

        public UsersController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            IEnumerable<Users> Users = unitOfWork.Users.GetAll();
            return View(Users);
        }

        public ActionResult EditOrCreate(int? id)
        {
            Users Users = new Users();
            if (id != null)
            {
                Users = unitOfWork.Users.Get(id);

            }
            return View(Users);

        }

        [HttpPost]
        public ActionResult EditOrCreate(Users Users)
        {

            if (Users.Id != 0)
            {
                unitOfWork.Users.Update(Users);
                unitOfWork.Save();
            }
            else
            {
                unitOfWork.Users.Create(Users);
                unitOfWork.Save();
            }

            return RedirectToActionPermanent("Index", "Users");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Users.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index", "Users");
        }
    }
}
