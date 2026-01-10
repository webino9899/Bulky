using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulyWebRazor_Temp.Data;
using BulyWebRazor_Temp.Model;

namespace BulyWebRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Category Category { get; set; }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost ()
        {
            _db.Categories.Add(Category );
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToPage("Index");  
        }
    }
}
