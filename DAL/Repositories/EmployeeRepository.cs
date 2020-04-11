using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private HRContext hRContext;
        public EmployeeRepository(HRContext hR)
        {
            hRContext = hR;
        }

        public void Create(Employee item)
        {
            hRContext.Employees.Add(item);
        }

        public void Delete(int id)
        {
            var x = hRContext.Employees.Find(id);
            if (x != null)
                hRContext.Employees.Remove(x);
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            return hRContext.Employees.Where(predicate).ToList();
        }

        public Employee FindOne(Func<Employee, bool> predicate)
        {
            return hRContext.Employees.Where(predicate).FirstOrDefault();
        }

        public Employee Get(int id)
        {
            return hRContext.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return hRContext.Employees;
        }

        public void Update(Employee item)
        {
            hRContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
