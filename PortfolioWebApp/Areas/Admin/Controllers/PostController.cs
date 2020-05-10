using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

namespace PortfolioWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class PostController : Controller
    {
        private IPostRepository _repo;
        private IMapper _mapper;
        private IWebHostEnvironment _hosting;
        private readonly ICategoryRepository _ctgRepo;

       

        public PostController(IPostRepository repo, IMapper mapper,
                                    IWebHostEnvironment hosting, ICategoryRepository ctgRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _hosting = hosting;
            _ctgRepo = ctgRepo;
        }
        //Extension method.
        Extensions.ExtensionMethod extension = new Extensions.ExtensionMethod();

        [HttpGet]
        public ActionResult Index()
        {
            var post = _repo.Include(x => x.Category).ToList();
            return View(post);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel model, IFormFile[] fileobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                //File array, if comes with 0 then gives error.
                if (fileobj.Length == 0 || fileobj == null || fileobj.Length > 6)
                {
                    ViewData["Message"] = "Please select at least one image file or You selected more images than 6 ";
                    return View(model);
                }
                else
                {
                    var post = _mapper.Map<Post>(model);
                    post.CreateDate = DateTime.Today;

                    extension.PostCreate(post, fileobj, _hosting);
                    
                    var isSuccess = _repo.Create(post);
                    return RedirectToAction(nameof(Index));
                }
               
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong... :( ");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var post = _repo.FindById(id);
            var model = _mapper.Map<PostEditViewModel>(post);
            ViewBag.Categories = _ctgRepo.ListAll();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostEditViewModel model, IFormFile[] fileobj)
        {
            ViewBag.Categories = _ctgRepo.ListAll();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
               
                //Find id where Selected PostId equals to Id.
                var post = _repo.FindById(model.Id);

                //Extension method for Edit Post.
                extension.PostEdit(post, model, fileobj, _hosting);
                
                var isSuccess = _repo.Update(post);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong... ");
                return RedirectToAction(nameof(Index));
            }
        }

        
        [HttpGet]     
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var post = _repo.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            var model = _mapper.Map<PostEditViewModel>(post);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var post = _repo.FindById(id);
            //Getting pictures from valid id.
            string[] filepathes = new string[6]
                {
                    post.FirstImageUrl,
                    post.SecondImageUrl,
                    post.ThirdImageUrl,
                    post.FourthImageUrl,
                    post.FifthImageUrl,
                    post.SixthImageUrl
                };

            if (post == null)
            {
                return NotFound();
            }

            var isSuccess = _repo.Delete(post);

            //Checks Delete method will run or not.
            if (!isSuccess)
            {
                ModelState.AddModelError("", "Something went wrong...");
                return BadRequest();
            }

            //Deleting pictures from Root folder "postImages";
            foreach (var picture in filepathes)
            {
                if (picture == null)
                {
                    break;
                }
                string filepath = Path.Combine(_hosting.WebRootPath, "postImages", picture);
                System.IO.File.Delete(filepath);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}