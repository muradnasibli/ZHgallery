using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("SuperAdmin,Admin")]
    public class AboutOwnerController : Controller
    {
        private readonly IAboutRepository _repo;
        private IMapper _mapper;
        private IWebHostEnvironment _hosting;

        public AboutOwnerController(IAboutRepository repo, IMapper mapper, IWebHostEnvironment hosting)
        {
            _repo = repo;
            _mapper = mapper;
            _hosting = hosting;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var about = _repo.ListAll();
            return View(about);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //TODO: Create with Company Image.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AboutOwnerViewModel model)
        {
            Extensions.ExtensionMethod extension = new Extensions.ExtensionMethod();
            string uniqueFileName = extension.ProcessUploadFile(model, _hosting);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var about = _mapper.Map<About>(model);
                about.CompanyPhoto = uniqueFileName;

                var isSuccess = _repo.Create(about);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View();
            }

        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var aboutOwner = _repo.FindById(id);
            if (aboutOwner == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(aboutOwner);
            if (!isSuccess)
            {
                ModelState.AddModelError("", "Something went wrong...");
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

       
    }
}