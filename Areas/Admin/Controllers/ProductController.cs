using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();

            return View(objProductList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            _unitOfWork.Product.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product created successfully!";
            return RedirectToAction("Index");
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
            Product? productFronDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFronDb == null)
            {
                return NotFound();
            }
            return View(productFronDb);
        }


        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully!";
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
            Product? productFronDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFronDb == null)
            {
                return NotFound();
            }
            return View(productFronDb);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound(id);
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully!";
            return RedirectToAction("Index");


        }

    }
}
