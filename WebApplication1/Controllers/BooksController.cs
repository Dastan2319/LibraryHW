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
    public class BooksController : Controller
    {
        IBookService bookService;

        public BooksController(IBookService serv)
        {
            bookService = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<BookDTO> bookDtos = bookService.GetBook();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var book = mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(bookDtos);
            return View(book);
        }

        public ActionResult EditOrCreate(int? id)
        {
            BookDTO book = new BookDTO();

            if (id != null)
            {
                book = bookService.GetBook(id);             
            }
            return View(book);

        }

        [HttpPost]
        public ActionResult EditOrCreate(Books Books)
        {

            if (Books.Id != 0)
            {
                bookService.SaveUpdate(Books);
            }
            else
            {
                var booksDto = new BookDTO { Title=Books.Title,Images=Books.Images,Pages=Books.Pages,Price=Books.Price };
                bookService.MakeBook(booksDto);
            }
            return RedirectToActionPermanent("Index", "Books");
        }

        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index", "Books");
        }
    }
}