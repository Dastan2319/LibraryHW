using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DLL;
using DLL.Entity;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class TakedBooksService : ITakedBooksService
    {
        IUnitOfWork db { get; set; }

        public TakedBooksService(IUnitOfWork uow)
        {
            db = uow;
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public void MakeTakedBooks(TakedBooksDTO orderDto)
        {
            TakedBooks takedBooks = new TakedBooks
            {
                BookId = orderDto.BookId,
                UserId = orderDto.UserId,
            };
            db.TakedBooks.Create(takedBooks);
            db.Save();
        }

        public TakedBooksDTO GetTakedBooks(int? id)
        {
            if (id != null)
            {
                var takedBooks = db.TakedBooks.Get(id);
                return new TakedBooksDTO { UserId= takedBooks.UserId,Books_Id= takedBooks.Books_Id };
            }
            else
            {
                return new TakedBooksDTO();
            }
        }

        public IEnumerable<TakedBooksDTO> GetTakedBooks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TakedBooks, TakedBooksDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TakedBooks>, List<TakedBooksDTO>>(db.TakedBooks.GetAll());
        }

        public void SaveUpdate(TakedBooks orderDto)
        {
            TakedBooks takedBooks = new TakedBooks
            {
                UserId= orderDto.UserId,
                BookId= orderDto.BookId,
            };
            db.TakedBooks.Update(takedBooks);
            db.Save();
        }
    }
}
