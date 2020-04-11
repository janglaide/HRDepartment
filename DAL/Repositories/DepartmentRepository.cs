using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private HRContext hRContext;
        public DepartmentRepository(HRContext hR)
        {
            hRContext = hR;
        }

        public void Create(Department item)
        {
            hRContext.Departments.Add(item);
        }

        public void Delete(int id)
        {
            var x = hRContext.Departments.Find(id);
            if (x != null)
                hRContext.Departments.Remove(x);
        }

        public IEnumerable<Department> Find(Func<Department, bool> predicate)
        {
            return hRContext.Departments.Where(predicate).ToList();
        }

        public Department FindOne(Func<Department, bool> predicate)
        {
            return hRContext.Departments.Where(predicate).FirstOrDefault();
        }

        public Department Get(int id)
        {
            return hRContext.Departments.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return hRContext.Departments;
        }

        public void Update(Department item)
        {
            hRContext.Entry(item).State = EntityState.Modified;
        }
    }
}
