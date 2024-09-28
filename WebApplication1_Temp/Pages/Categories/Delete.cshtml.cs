using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_Temp.Data;
using WebApplication1_Temp.Models;

namespace WebApplication1_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category? Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.FirstOrDefault(c => c.Id == id);
            }
        }
        public IActionResult OnPost()
        {
            Category? category = _db.Categories.Find(Category.Id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToPage("Index");
        }


    }
}
