using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Data;

namespace PortfolioWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CategoryController : Controller
    {
        private ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            var categoryList = _repo.ListAll();
            return View(categoryList);
        }
        [HttpGet]
        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                var isSuccess = _repo.Create(category);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(category);
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
            var category = _repo.FindById(id);
            if (category == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(category);
            if (!isSuccess)
            {
                ModelState.AddModelError("", "Something went wrong...");
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

       
    }
}