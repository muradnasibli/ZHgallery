using PortfolioWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortfolioWebApp.Contracts
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        //Show details with multiple table, 
        IQueryable<Post> GetWhere(Expression<Func<Post, bool>> predicate);
        IQueryable<Post> Include(params Expression<Func<Post, object>>[] includes);
    }
}
