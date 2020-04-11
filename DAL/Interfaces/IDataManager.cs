using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDataManager : IDisposable
    {
        IRepository<Department> Departments { get; }
        IRepository<Employee> Employees { get; }
        IRepository<EmployeeToProject> EmployeeToProjects { get; }
        IRepository<Position> Positions { get; }
        IRepository<Project> Projects { get; }
        void Save();
    }
}
