using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PositionDTO
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int Salary { get; set; }
    }
}
