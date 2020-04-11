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
    public class PositionRepository : IRepository<Position>
    {
        private HRContext hRContext;
        public PositionRepository(HRContext hR)
        {
            hRContext = hR;
        }

        public void Create(Position item)
        {
            hRContext.Positions.Add(item);
        }

        public void Delete(int id)
        {
            var x = hRContext.Positions.Find(id);
            if (x != null)
                hRContext.Positions.Remove(x);
        }

        public IEnumerable<Position> Find(Func<Position, bool> predicate)
        {
            return hRContext.Positions.Where(predicate).ToList();
        }

        public Position FindOne(Func<Position, bool> predicate)
        {
            return hRContext.Positions.Where(predicate).FirstOrDefault();
        }

        public Position Get(int id)
        {
            return hRContext.Positions.Find(id);
        }

        public IEnumerable<Position> GetAll()
        {
            return hRContext.Positions;
        }

        public void Update(Position item)
        {
            hRContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
