using BLL.DTO;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBookService
    {
        void MakeBook(BookDTO orderDto);
        BookDTO GetBook(int? id);
        IEnumerable<BookDTO> GetBook();
        void SaveUpdate(Books orderDto);
        void Dispose();
    }
}
