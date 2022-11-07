using HardwareStore.DataAccess;
using HardwareStore.DataAccess.Repository.IRepository;
using HardwareStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HardwareStoreWeb.Areas.Admin.Controllers
{
    public class FinishController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinishController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Finish> finishList = _unitOfWork.Finish.GetAll(); //this method is from the Generic Repository
            return View(finishList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Finish obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Finish.Add(obj); //again, this method is from the Generic Repository
                _unitOfWork.Save();
                TempData["success"] = "Finish created successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Finish name cannot be empty";
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var finishObj = _unitOfWork.Finish.GetFirstOrDefault(c => c.Id == id);

            if (finishObj == null)
            {
                return NotFound();
            }

            return View(finishObj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Finish obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Finish.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Finish edited successfully";
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

            var finishObj = _unitOfWork.Finish.GetFirstOrDefault(c => c.Id == id);

            if (finishObj == null)
            {
                return NotFound();
            }

            return View(finishObj);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Finish.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Finish.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Finish deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

