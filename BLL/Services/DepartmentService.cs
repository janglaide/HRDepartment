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
    public class DepartmentService : IDepartmentService
    {
        private IDataManager db;
        public DepartmentService(IDataManager dataManager)
        {
            db = dataManager;
        }

        public IEnumerable<DepartmentDTO> GetDepartments()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Department, DepartmentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Department>, List<DepartmentDTO>>(db.Departments.GetAll());
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public DepartmentDTO GetDepartmentById(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Department, DepartmentDTO>()).CreateMapper();
            return mapper.Map<Department, DepartmentDTO>(db.Departments.FindOne(x => x.DepartmentId == id));
        }

        public void AddDepartment(DepartmentDTO item)
        {
            var newDep = new Department
            {
                DepartmentId = item.DepartmentId,
                Name = item.Name,
                Description = item.Description
            };
            db.Departments.Create(newDep);
            db.Save();
        }
    }
}
