using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
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
    public class TakedBooksController : Controller
    {
        ITakedBooksService takedBooksService;

        public TakedBooksController(ITakedBooksService serv)
        {
            takedBooksService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<TakedBooksDTO> takedBookDtos = takedBooksService.GetTakedBooks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TakedBooksDTO, TakedBooksViewModel>()).CreateMapper();
            var takedBooks = mapper.Map<IEnumerable<TakedBooksDTO>, List<TakedBooksViewModel>>(takedBookDtos);
            return View(takedBooks);
        }

        public ActionResult EditOrCreate(int? id)
        {
            TakedBooksDTO takedBooks = new TakedBooksDTO();

            if (id != null)
            {
                takedBooks = takedBooksService.GetTakedBooks(id);
            }
            return View(takedBooks);

        }

        [HttpPost]
        public ActionResult EditOrCreate(TakedBooks takedBooks)
        {

            if (takedBooks.id != 0)
            {
                var tempTakedBooks = takedBooksService.GetTakedBooks(takedBooks.id);
                tempTakedBooks.BookId = takedBooks.BookId;
                tempTakedBooks.UserId = takedBooks.UserId;
                takedBooksService.SaveUpdate(takedBooks);

            }
            else
            {
                var takedBookDto = new TakedBooksDTO { BookId= takedBooks .BookId,UserId= takedBooks.UserId};
                takedBooksService.MakeTakedBooks(takedBookDto);
            }

            return RedirectToActionPermanent("Index", "TakedBooks");
        }

        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index", "TakedBooks");
        }
    }
}