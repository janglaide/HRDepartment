using DAL;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataManager : IDataManager
    {
        private HRContext context;
        private DepartmentRepository departmentRepository;
        private EmployeeRepository employeeRepository;
        private EmployeeToProjectRepository employeeToProject;
        private PositionRepository positionRepository;
        private ProjectRepository projectRepository;
        private bool disposed = false;


        public DataManager(string connection)
        {
            context = new HRContext(connection);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public IRepository<Department> Departments
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(context);
                return departmentRepository;
            }
        }
        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(context);
                return employeeRepository;
            }
        }
        public IRepository<EmployeeToProject> EmployeeToProjects
        {
            get
            {
                if (employeeToProject == null)
                    employeeToProject = new EmployeeToProjectRepository(context);
                return employeeToProject;
            }
        }
        public IRepository<Position> Positions
        {
            get
            {
                if (positionRepository == null)
                    positionRepository = new PositionRepository(context);
                return positionRepository;
            }
        }
        public IRepository<Project> Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(context);
                return projectRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
