using BLL.DTO;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthorService
    {
        void MakeAuthor(AuthorsDTO orderDto);
        AuthorsDTO GetAuthor(int? id);
        IEnumerable<AuthorsDTO> GetAuthor();
        void SaveUpdate(Authors orderDto);
        void Dispose();
    }
}
