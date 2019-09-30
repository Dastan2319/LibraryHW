using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DLL.Entity;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class GanreService : IGanreService
    {
        IUnitOfWork db { get; set; }

        public GanreService(IUnitOfWork uow)
        {
            db = uow;
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<GanreDTO> GetBook()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ganre, GanreDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ganre>, List<GanreDTO>>(db.Ganre.GetAll());
        }

        public GanreDTO GetGanre(int? id)
        {
            if (id != null)
            {
                var Ganre = db.Ganre.Get(id);
                return new GanreDTO {FirstName=Ganre.FirstName};
            }
            else
            {
                return new GanreDTO();
            }
        }

        public void MakeBook(GanreDTO orderDto)
        {
            Ganre ganre = new Ganre
            {
                FirstName = orderDto.FirstName,
            };
            db.Ganre.Create(ganre);
            db.Save();
        }

        public void SaveUpdate(Ganre orderDto)
        {
            Ganre ganre = new Ganre
            {
                FirstName = orderDto.FirstName
            };
            db.Ganre.Update(ganre);
            db.Save();
        }
    }
}
