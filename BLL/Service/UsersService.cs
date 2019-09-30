using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DLL;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class UsersService : IUsersService
    {
        IUnitOfWork db { get; set; }

        public UsersService(IUnitOfWork uow)
        {
            db = uow;
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public UsersDTO GetUsers(int? id)
        {
            if (id != null)
            {
                var users = db.Users.Get(id);
                return new UsersDTO { FIO= users.FIO };
            }
            else
            {
                return new UsersDTO();
            }
        }

        public IEnumerable<UsersDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Users, UsersDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UsersDTO>>(db.Users.GetAll());
        }

        public void MakeUsers(UsersDTO orderDto)
        {
            Users user = new Users
            {
                FIO = orderDto.FIO
            };
            db.Users.Create(user);
            db.Save();
        }

        public void SaveUpdate(Users orderDto)
        {
            Users users = new Users
            {
                FIO = orderDto.FIO
            };
            db.Users.Update(users);
            db.Save();
        }
    }
}
