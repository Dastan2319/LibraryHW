using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            List<Users> Users;
            using (Model1 db = new Model1())
            {
                Users = db.Users.ToList();

            }
            return View(Users);
        }

        public ActionResult EditOrCreate(int? id)
        {
            Users Users = new Users();
            if (id != null)
            {
                using (Model1 db = new Model1())
                {
                    Users = db.Users.Where(a => a.Id == id).FirstOrDefault();
                }
            }
            return View(Users);

        }

        [HttpPost]
        public ActionResult EditOrCreate(Users Users)
        {
            using (Model1 db = new Model1())
            {
                if (Users.Id != 0)
                {
                    var UsersTemp = db.Users.Where(a => a.Id == Users.Id).FirstOrDefault();
                    UsersTemp.FIO = Users.FIO;
                }
                else
                {
                    db.Users.Add(Users);
                }
                db.SaveChanges();
            }
            return RedirectToActionPermanent("Index", "Users");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var Users = db.Users.Where(a => a.Id == id).FirstOrDefault();
                db.Users.Remove(Users);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Users");
        }
    }
}
