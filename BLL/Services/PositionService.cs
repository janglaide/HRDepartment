using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PositionService : IPositionService
    {
        private IDataManager db;
        public PositionService(IDataManager dataManager)
        {
            db = dataManager;
        }
        public IEnumerable<PositionDTO> GetPositions()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Position, PositionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Position>, List<PositionDTO>>(db.Positions.GetAll());
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<PositionDTO> GetTop5Positions()
        //{
        //    var mapper = new MapperConfiguration(x => x.CreateMap<Position, PositionDTO>()).CreateMapper();
        //    var mapped = mapper.Map<IEnumerable<Position>, List<PositionDTO>>(db.Positions.GetAll());

        //    List<double> res = new List<double>();
        //    for(var i = 0; i < mapped.Count(); i++)
        //    {
        //        var tmp = mapped[i].Salary / mapped[i].Hours;
        //        res.Add(tmp);
        //    }
        //    res.Sort();
        //    var a = res[0];
        //    var b = res[1];
            
        //    for(var i = 0; i < 5; i++)
        //    {

        //    }
        //}
    }
}
