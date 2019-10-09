using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Service;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        IUsersService usersService;

        public UsersController(IUsersService serv)
        {
            usersService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<UsersDTO> usersDtos = usersService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UsersDTO, UsersViewModel>()).CreateMapper();
            var user = mapper.Map<IEnumerable<UsersDTO>, List<UsersViewModel>>(usersDtos);
            return View(user);
        }

        public ActionResult EditOrCreate(int? id)
        {
            UsersDTO user = new UsersDTO();

            if (id != null)
            {
                user = usersService.GetUsers(id);
            }
            return View(user);

        }

        [HttpPost]
        public ActionResult EditOrCreate(Users Users)
        {

            if (Users.Id != 0)
            {
                usersService.SaveUpdate(Users);
            }
            else
            {
                var usersDto = new UsersDTO { FIO=Users.FIO };
                usersService.MakeUsers(usersDto);
            }

            return RedirectToActionPermanent("Index", "Users");
        }

        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index", "Users");
        }
    }
}
