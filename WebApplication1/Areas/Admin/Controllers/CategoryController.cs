using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.DataAccess.Data;
using WebApplication1.DataAccess.Repository.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public readonly IUnitOfWork _db;
        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objcategroyList = _db.CategoryRepository.GetAll().ToList();
            return View(objcategroyList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Category and Display order does not same");
            }
            //if (category.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", category.Name +" is invalid Category");
            //}
            if (ModelState.IsValid)
            {
                _db.CategoryRepository.Add(category);
                _db.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);

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
            Category? category = _db.CategoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.CategoryRepository.Update(category);
                TempData["success"] = "Category Updated Successfully";
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(category);

        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            //Following 3 ways are used for the fetch the record.
            //Category category= _db.Categories.Find(id);
            //Category category = _db.Categories.FirstOrDefault(u => u.Id == id);
            Category? category = _db.CategoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _db.CategoryRepository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _db.CategoryRepository.Remove(category);
            _db.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");



        }
    }
}
