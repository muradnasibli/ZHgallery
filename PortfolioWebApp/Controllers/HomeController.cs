using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _repo;

        public HomeController(IPostRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var posts = _repo.Include(x => x.Category).ToList();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
