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
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _db;
        public PostRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Post entity)
        {
            _db.Posts.Add(entity);
            return Save();
        }

        public bool Delete(Post entity)
        {
            _db.Posts.Remove(entity);
            return Save();
        }

        public Post FindById(int id)
        {
            var post = _db.Posts.Find(id);
            return post;
        }

        public IQueryable<Post> ShowDetails(int id)
        {
            var post = _db.Posts.Include(x => x.Category).Where(x => x.Id == id);
            return post;
        }

        public IQueryable<Post> GetWhere(Expression<Func<Post, bool>> predicate)
        {
            return _db.Posts.Where(predicate);
        }

        public IQueryable<Post> Include(params Expression<Func<Post, object>>[] includes)
        {
            IQueryable<Post> set = _db.Posts;
            foreach (var includeExpression in includes)
            {
                set = set.Include(includeExpression);
            }
            return set;
        }

        public bool isExists(int id)
        {
            var existPost = _db.Posts.Any(x => x.Id == id);
            return existPost;
        }

        public ICollection<Post> ListAll()
        {
            var posts = _db.Posts.ToList();
            return posts;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Post entity)
        {
            //_db.Posts.AsNoTracking().Where(x => x.Id == entity.Id).FirstOrDefault();
            _db.Posts.Update(entity);
            return Save();
        }

        public Post FindByName(string name)
        {
            return _db.Posts.FirstOrDefault(x => x.Name == name);
        }
    }
}
