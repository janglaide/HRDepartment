using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDTO> GetDepartments();
        DepartmentDTO GetDepartmentById(int id);
        void AddDepartment(DepartmentDTO item);
        void Dispose();
    }
}
