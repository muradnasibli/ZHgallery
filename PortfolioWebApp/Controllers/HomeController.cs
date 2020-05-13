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

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            Extensions.ExtensionMethod ext = new Extensions.ExtensionMethod();
            ext.SentMail(model);
            return View();
        }

        [HttpGet]
        [Route("/Home/Post/{name}/{id}")]
        public IActionResult Post(string name, int id)
        {
            var postId = _postRepo.FindById(id);
            //var post = _postRepo.GetWhere(x => postId.Name == name).FirstOrDefault();
            //var post = _postRepo.FindByName(name);
            return View(postId);
        }
    }
}
