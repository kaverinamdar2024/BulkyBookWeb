using BulkyBookWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Authorization;
using BulkyBookWeb.Utility;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles=SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objcategorylist = _unitOfWork.Category.GetAll().ToList();
            return View(objcategorylist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _unitOfWork.Category.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully!";
            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            //var cat=_context.Catogories.Where(a=>a.Id==id).FirstOrDefault();    
            //return View(cat);
            if (id == null)
            {
                return NotFound();
            }
            Category? categoryFronDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFronDb == null)
            {
                return NotFound();
            }
            return View(categoryFronDb);
        }


        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            Category? categoryfromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePot(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound(id);
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");


        }
    }
}
