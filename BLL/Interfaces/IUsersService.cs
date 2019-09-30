using BLL.DTO;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsersService
    {
        void MakeUsers(UsersDTO orderDto);
        UsersDTO GetUsers(int? id);
        IEnumerable<UsersDTO> GetUsers();
        void SaveUpdate(Users orderDto);
        void Dispose();
    }
}
