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
    public class EmployeeToProjectService : IEmployeeToProjectService
    {
        private IDataManager db;
        public EmployeeToProjectService(IDataManager dataManager)
        {
            db = dataManager;
        }

        public void DeleteEmployeeToProjects(int emplId)
        {
            var all = db.EmployeeToProjects.GetAll();
            var res = (from x in all
                      where x.EmployeeId == emplId
                      select x.Id).ToList();
            for(var i = 0; i < res.Count(); i++)
            {
                db.EmployeeToProjects.Delete(res[i]);
                db.Save();
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<EmployeeToProjectDTO> GetEmployeeToProjects()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<EmployeeToProject, EmployeeToProjectDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<EmployeeToProject>, List<EmployeeToProjectDTO>>(db.EmployeeToProjects.GetAll());
        }
    }
}
