using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _db.Categories;

        return View(objCategoryList);
    }

    // GET
    public IActionResult Create()
    {
        return View();
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken] // prevent cross site request forgery attack
    public IActionResult Create(Category obj)
    {
        // add custom validation where we do not want to add category with same name and display order
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            // CustomError can also changed to name so the error will appear under input name
            ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");
        }

        // server-side validation
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges(); // this code will push the new record to the db

            // stays in memory for just one redirect
            TempData["success"] = "Category created successfully.";

            return RedirectToAction("Index"); // redirect to action within the same controller
        }

        return View(obj);

        // RedirectToAction("Index", "<controller>") -> example of redirect to action in another controller
    }

    // GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        /*
         * Single - throw an exception if no elements are found for that ID
         * SingleOrDefault - return empty if there are no elements
         * Default - will not throw an exception if element is not found
         * 
         * First - throw an exception if there are more than one elements
         * FirstOrDefault - return the first elements of the list
         */
        // var categoryFromDb = _db.Categories.Find(id); // using find() method
        var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    // POST
    [HttpPost]
    [ValidateAntiForgeryToken] // prevent cross site request forgery attack
    public IActionResult Edit(Category obj)
    {
        // add custom validation where we do not want to add category with same name and display order
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            // CustomError can also changed to name so the error will appear under input name
            ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");
        }

        // server-side validation
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges(); // this code will push the new record to the db

            TempData["success"] = "Category updated successfully.";

            return RedirectToAction("Index"); // redirect to action within the same controller
        }

        return View(obj);

        // RedirectToAction("Index", "<controller>") -> example of redirect to action in another controller
    }

    // GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        /*
         * Single - throw an exception if no elements are found for that ID
         * SingleOrDefault - return empty if there are no elements
         * Default - will not throw an exception if element is not found
         * 
         * First - throw an exception if there are more than one elements
         * FirstOrDefault - return the first elements of the list
         */
        // var categoryFromDb = _db.Categories.Find(id); // using find() method
        var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    // POST
    [HttpPost, ActionName("Delete")] // can also use Delete name inside the view page as action
    [ValidateAntiForgeryToken] // prevent cross site request forgery attack
    public IActionResult DeletePost(int? id)
    {
        var obj = _db.Categories.Find(id);

        if (obj == null)
        {
            return NotFound();
        }

        _db.Categories.Remove(obj);
        _db.SaveChanges();

        TempData["success"] = "Category deleted successfully.";

        return RedirectToAction("Index");
    }
}
