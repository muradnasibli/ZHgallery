using Microsoft.EntityFrameworkCore;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortfolioWebApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Category entity)
        {
            _db.Categories.Add(entity);
            return Save();
        }

        public bool Delete(Category entity)
        {
            _db.Categories.Remove(entity);
            return Save();
        }

        public Category FindById(int id)
        {
            var category =  _db.Categories.Find(id);
            return category;
        }

        public bool isExists(int id)
        {
            var existCategory = _db.Categories.Any(x => x.Id == id);
            return existCategory;
        }

        public ICollection<Category> ListAll()
        {
            var categories = _db.Categories.ToList();
            return categories;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Category entity)
        {
            _db.Categories.Update(entity);
            return Save();
        }
    }
}
