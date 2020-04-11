using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PaymentNum { get; set; }
        public int Experience { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
    }
}
