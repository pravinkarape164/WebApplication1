using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataAccess.Data;
using WebApplication1.DataAccess.Repository.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _db;
        public ProductController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _db.ProductRepository.GetAll().ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            //if (category.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", category.Name +" is invalid Category");
            //}
            if (ModelState.IsValid)
            {
                _db.ProductRepository.Add(product);
                _db.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View(product);

        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            //Following 3 ways are used for the fetch the record.
            //Category category= _db.Categories.Find(id);
            //Category category = _db.Categories.FirstOrDefault(u => u.Id == id);
            Product? product = _db.ProductRepository.Get(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.ProductRepository.Update(product);
                _db.Save();
                TempData["success"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            { return NotFound(); }
            Product? product = _db.ProductRepository.Get(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? product = _db.ProductRepository.Get(c => c.Id == id);
            if (product == null)
            { return NotFound(); }
            _db.ProductRepository.Remove(product);
            _db.Save();
            TempData["success"] = "Product Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
