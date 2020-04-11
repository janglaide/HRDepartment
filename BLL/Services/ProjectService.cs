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
    public class ProjectService : IProjectService
    {
        private IDataManager db;
        public ProjectService(IDataManager dataManager)
        {
            db = dataManager;
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<ProjectDTO> GetProjects()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Project, ProjectDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(db.Projects.GetAll());
        }
        public IEnumerable<ProjectDTO> GetProjectsByEmployee(int id)
        {
            var mapperP = new MapperConfiguration(x => x.CreateMap<Project, ProjectDTO>()).CreateMapper();
            var mappedP = mapperP.Map<IEnumerable<Project>, List<ProjectDTO>>(db.Projects.GetAll());

            var mapperEP = new MapperConfiguration(x => x.CreateMap<EmployeeToProject, EmployeeToProjectDTO>()).CreateMapper();
            var mappedEP = mapperEP.Map<IEnumerable<EmployeeToProject>, List<EmployeeToProjectDTO>>(db.EmployeeToProjects.GetAll());

            var mapperE = new MapperConfiguration(x => x.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            var mappedE = mapperE.Map<IEnumerable<Employee>, List<EmployeeDTO>>(db.Employees.GetAll());

            var res = from p in mappedP
                      join ep in mappedEP on p.ProjectId equals ep.ProjectId
                      join e in mappedE on ep.EmployeeId equals e.EmployeeId
                      where p.ProjectId == ep.ProjectId && ep.EmployeeId == e.EmployeeId && e.EmployeeId == id
                      select p;
            return res;
            
        }
    }
}
