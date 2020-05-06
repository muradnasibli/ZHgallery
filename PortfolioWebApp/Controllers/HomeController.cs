using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepo;
        private readonly IAboutRepository _aboutRepo;

        public HomeController(IPostRepository postRepo, IAboutRepository aboutRepo)
        {
            _postRepo = postRepo;
            _aboutRepo = aboutRepo;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var posts = _postRepo.Include(x => x.Category).ToList();
            return View(posts);
        }
        [HttpGet]
        public IActionResult About()
        {
            var aboutOwner = _aboutRepo.ListAll();
            return View(aboutOwner);
        }

        [HttpGet]
        public IActionResult Portfolio()
        {
            var portfolioPosts = _postRepo.Include(x => x.Category).ToList();
            return View(portfolioPosts);
        }

    }
}
