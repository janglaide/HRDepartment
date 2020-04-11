using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PositionViewModel
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int Salary { get; set; }
    }
}