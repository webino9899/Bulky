using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulyWebRazor_Temp.Model;
using BulyWebRazor_Temp.Data;

namespace BulyWebRazor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int? id)
        {
            if (id != 0 && id != null)
            {
                Category = _db.Categories.Find(id);
            }

        }

        public IActionResult OnPost()
        {
            Category obj = _db.Categories.Find(Category.ID);
            if (obj == null)
            {
                return NotFound();

            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                 TempData["success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");
            

        }
    }
}
