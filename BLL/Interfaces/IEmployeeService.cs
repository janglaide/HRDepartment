using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetEmployees();
        IEnumerable<EmployeeDTO> GetEmployeesByDepartmentId(int id);
        EmployeeDTO GetBestEmployee(int posId);
        void AddEmployee(EmployeeDTO employee);
        void DeleteEmployee(int id);
        void Dispose();
    }
}
