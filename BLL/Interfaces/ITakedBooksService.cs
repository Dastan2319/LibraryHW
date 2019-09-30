using BLL.DTO;
using DLL;
using DLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITakedBooksService
    {
        void MakeTakedBooks(TakedBooksDTO orderDto);
        TakedBooksDTO GetTakedBooks(int? id);
        IEnumerable<TakedBooksDTO> GetTakedBooks();
        void SaveUpdate(TakedBooks orderDto);
        void Dispose();
    }
}
