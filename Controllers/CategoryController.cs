using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WearHouse.Data;
using WearHouse.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;


namespace WearHouse.Controllers
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
            IEnumerable<Category>objCategory  = _db.Categories;
            return View(objCategory);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int CategoryId)
        {
            var category = _db.Categories.FirstOrDefault(c=>c.CategoryId ==CategoryId);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int CategoryId, Category obj)
        {
            if(CategoryId != obj.CategoryId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int CategoryId)
        {
            var category = _db.Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
            if (category == null)
            {
                return NotFound();
            }            
            return View(category);
        }

        [HttpPost,ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int CategoryId)
        {
            var obj =  _db.Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
            if (obj==null)
            { 
                return NotFound(); 
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}
