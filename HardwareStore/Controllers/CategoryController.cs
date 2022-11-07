using HardwareStore.DataAccess;
using HardwareStore.DataAccess.Repository.IRepository;
using HardwareStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HardwareStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.GetAll(); //this method is from the Generic Repository
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj); //again, this method is from the Generic Repository
                _db.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Category name cannot be empty";
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }

            var categoryObj = _db.GetFirstOrDefault(c => c.Id == id);

            if (categoryObj == null)
            {
                return NotFound(); 
            }

            return View(categoryObj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                //_db.Categories.Add(obj);
                _db.Update(obj);
                _db.Save();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryObj = _db.GetFirstOrDefault(c => c.Id == id);

            if (categoryObj == null)
            {
                return NotFound();
            }

            return View(categoryObj);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Remove(obj);                
            _db.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

