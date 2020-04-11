using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class FullEmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PaymentNum { get; set; }
        public int Experience { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
    }
}