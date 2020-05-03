using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebApp.Contracts;

namespace PortfolioWebApp.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPostRepository _repo;

        public PortfolioController(IPostRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var posts = _repo.Include(x => x.Category).ToList();
            return View(posts);
        }
    }
}