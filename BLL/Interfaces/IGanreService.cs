using BLL.DTO;
using DLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGanreService
    {
        void MakeBook(GanreDTO orderDto);
        GanreDTO GetGanre(int? id);
        IEnumerable<GanreDTO> GetBook();
        void SaveUpdate(Ganre orderDto);
        void Dispose();
    }
}
