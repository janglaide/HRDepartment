using DAL;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeToProjectRepository : IRepository<EmployeeToProject>
    {
        private HRContext hRContext;
        public EmployeeToProjectRepository(HRContext hR)
        {
            hRContext = hR;
        }

        public void Create(EmployeeToProject item)
        {
            hRContext.EmployeeToProjects.Add(item);
        }

        public void Delete(int id)
        {
            var x = hRContext.EmployeeToProjects.Find(id);
            if (x != null)
                hRContext.EmployeeToProjects.Remove(x);
        }

        public IEnumerable<EmployeeToProject> Find(Func<EmployeeToProject, bool> predicate)
        {
            return hRContext.EmployeeToProjects.Where(predicate).ToList();
        }

        public EmployeeToProject FindOne(Func<EmployeeToProject, bool> predicate)
        {
            return hRContext.EmployeeToProjects.Where(predicate).FirstOrDefault();
        }

        public EmployeeToProject Get(int id)
        {
            return hRContext.EmployeeToProjects.Find(id);
        }

        public IEnumerable<EmployeeToProject> GetAll()
        {
            return hRContext.EmployeeToProjects;
        }

        public void Update(EmployeeToProject item)
        {
            hRContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
