using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EmployeeViewModel
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