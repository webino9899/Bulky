
using Microsoft.AspNetCore.Mvc;
using Bulky.DataAcess.Data;
using Bulky.Model;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
           return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }

            if(obj.Name.Contains("test", StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError("", "The Name cannot contain the word 'test'.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                 return RedirectToAction("Index");
            }
            return View("Index");
        }


        public IActionResult Edit(int id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u => u.ID == id);
            //Category? categoryFromDb3 = _db.Categories.Where(u => u.ID == id).FirstOrDefault(); 
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u => u.ID == id);
            //Category? categoryFromDb3 = _db.Categories.Where(u => u.ID == id).FirstOrDefault(); 
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete") ]
        public IActionResult Delete(int? id)
        {
            Category obj = _db.Categories.Find(id);
            if(id == null)
            {
                return NotFound();

            }

            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
