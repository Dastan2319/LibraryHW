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
    public class AuthorService : IAuthorService
    {
        IUnitOfWork db { get; set; }

        public AuthorService(IUnitOfWork uow)
        {
            db = uow;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public AuthorsDTO GetAuthor(int? id)
        {
            if (id != null)
            {
                var author = db.Authors.Get(id);
                return new AuthorsDTO { FirstName = author.FirstName, LastName = author.LastName };
            }
            else
            {
                return new AuthorsDTO();
            }
           
        }

        public IEnumerable<AuthorsDTO> GetAuthor()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Authors, AuthorsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Authors>, List<AuthorsDTO>>(db.Authors.GetAll());
        }

        public void MakeAuthor(AuthorsDTO authorDto)
        {
            Authors author = new Authors
            {
                FirstName= authorDto.FirstName,
                LastName= authorDto.LastName,
            };
            db.Authors.Create(author);
            db.Save();
        }

        public void SaveUpdate(Authors orderDto)
        {
            Authors author = new Authors
            {
                FirstName = orderDto.FirstName,
                LastName = orderDto.LastName,
            };
            db.Authors.Update(author);
            db.Save();
        }
    }
}
