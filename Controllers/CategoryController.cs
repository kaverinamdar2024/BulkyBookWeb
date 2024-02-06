using BulkyBookWeb.Models;
using BulkyBookWeb.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category>objcategorylist=_context.Catogories.ToList();
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
            _context.Catogories.Add(obj);
            _context.SaveChanges();
            TempData["success"] = "Category created successfully!";
            return RedirectToAction("Index","Category");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        { 

            //var cat=_context.Catogories.Where(a=>a.Id==id).FirstOrDefault();    
            //return View(cat);
            if(id == null)
            {
                return NotFound();
            }
            Category? categoryFronDb = _context.Catogories.Find(id);
            if(categoryFronDb == null)
            {
                return NotFound();
            }
            return View(categoryFronDb);
        }


        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if(ModelState.IsValid)
            {
                _context.Catogories.Update(obj);
                _context.SaveChanges();
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
            Category? categoryfromDb = _context.Catogories.Find(id);
            if(categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePot(int? id)
          {
            Category? obj = _context.Catogories.Find(id);
            if(obj == null)
            {
                return NotFound(id);
            }

                _context.Catogories.Remove(obj);
                _context.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");

            
        }
    }
}
