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
    public class EmployeeService : IEmployeeService
    {
        private IDataManager db;
        public EmployeeService(IDataManager dataManager)
        {
            db = dataManager;
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            Employee newEmpl = new Employee
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Surname = employee.Surname,
                Experience = employee.Experience,
                PaymentNum = employee.PaymentNum,
                DepartmentId = employee.DepartmentId,
                PositionId = employee.PositionId
            };
            db.Employees.Create(newEmpl);
            db.Save();
        }

        public void DeleteEmployee(int id)
        {
            db.Employees.Delete(id);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public EmployeeDTO GetBestEmployee(int posId)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            var mapped = mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(db.Employees.Find(x => x.PositionId == posId));

            var mapperP = new MapperConfiguration(x => x.CreateMap<Project, ProjectDTO>()).CreateMapper();
            var mappedP = mapperP.Map<IEnumerable<Project>, List<ProjectDTO>>(db.Projects.GetAll());

            var mapperEP = new MapperConfiguration(x => x.CreateMap<EmployeeToProject, EmployeeToProjectDTO>()).CreateMapper();
            var mappedEP = mapperEP.Map<IEnumerable<EmployeeToProject>, List<EmployeeToProjectDTO>>(db.EmployeeToProjects.GetAll());

            List<ProjectDTO> costs = new List<ProjectDTO>();
            List<int> ids = new List<int>();
            for (var i = 0; i < mapped.Count(); i++)
            {
                var res = (from p in mappedP
                          join ep in mappedEP on p.ProjectId equals ep.ProjectId
                          join e in mapped on ep.EmployeeId equals e.EmployeeId
                          where p.ProjectId == ep.ProjectId && ep.EmployeeId == e.EmployeeId && e.EmployeeId == mapped[i].EmployeeId
                          select p).ToList();
                costs.AddRange(res);
                var count = res.Count();
                for(var x = 0; x < count; x++)
                    ids.Add(mapped[i].EmployeeId);
            }

            var a = ids.Count();

            List<double> sums = new List<double>();
            var f = 0;

            while (f < a)
            {
                double sum = 0;
                var j = ids[f];
                while (f < a && ids[f] == j)
                {
                    sum += costs[f].Cost;
                    f++;
                }
                sums.Add(sum);
            }

            var experiences = (from x in mapped
                              select x.Experience).ToList();
            double max = 0;
            int BestId = 0;
            for(var i = 0; i < sums.Count(); i++)
            {
                var tmp = sums[i] / experiences[i];
                if(tmp > max)
                {
                    max = tmp;
                    BestId = mapped[i].EmployeeId;
                }      
            }
            return mapper.Map<Employee, EmployeeDTO>(db.Employees.Get(BestId));
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(db.Employees.GetAll());
        }

        public IEnumerable<EmployeeDTO> GetEmployeesByDepartmentId(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(db.Employees.Find(x => x.DepartmentId == id));
        }
    }
}
