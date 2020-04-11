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
    public class ProjectRepository : IRepository<Project>
    {
        private HRContext hRContext;
        public ProjectRepository(HRContext hR)
        {
            hRContext = hR;
        }

        public void Create(Project item)
        {
            hRContext.Projects.Add(item);
        }

        public void Delete(int id)
        {
            var x = hRContext.Projects.Find(id);
            if (x != null)
                hRContext.Projects.Remove(x);
        }

        public IEnumerable<Project> Find(Func<Project, bool> predicate)
        {
            return hRContext.Projects.Where(predicate).ToList();
        }

        public Project FindOne(Func<Project, bool> predicate)
        {
            return hRContext.Projects.Where(predicate).FirstOrDefault();
        }

        public Project Get(int id)
        {
            return hRContext.Projects.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return hRContext.Projects;
        }

        public void Update(Project item)
        {
            hRContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
