using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulyWebRazor_Temp.Model;
using BulyWebRazor_Temp.Data;

namespace BulyWebRazor_Temp.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int? id)
        {
            if(id != 0 && id != null)
            {
                Category = _db.Categories.Find(id); 
            }

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update (Category);
                _db.SaveChanges();
                TempData["success"] = "Category Edited Successfully";
                return RedirectToPage("Index");
            }
            return RedirectToPage();

        }
    }
}
