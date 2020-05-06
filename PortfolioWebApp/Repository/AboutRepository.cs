using PortfolioWebApp.Contracts;
using PortfolioWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Repository
{
    public class AboutRepository : IAboutRepository
    {
        private readonly ApplicationDbContext db;

        public AboutRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool Create(About entity)
        {
            db.AboutOwner.Add(entity);
            return Save();
        }

        public bool Delete(About entity)
        {
            db.AboutOwner.Remove(entity);
            return Save();
        }

        public About FindById(int id)
        {
            var aboutOwner = db.AboutOwner.Find(id);
            return aboutOwner;
        }

        public bool isExists(int id)
        {
            var existAboutOwner = db.AboutOwner.Any(x => x.Id == id);
            return existAboutOwner;
        }

        public ICollection<About> ListAll()
        {
            var aboutOwner = db.AboutOwner.ToList();
            return aboutOwner;
        }

        public bool Save()
        {
            var changes = db.SaveChanges();
            return changes > 0;
        }

        public bool Update(About entity)
        {
            db.AboutOwner.Update(entity);
            return Save();
        }
    }
}
