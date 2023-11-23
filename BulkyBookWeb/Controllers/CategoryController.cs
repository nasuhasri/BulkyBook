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

    [HttpPost]
    [ValidateAntiForgeryToken] // prevent cross site request forgery attack
    public IActionResult Create(Category obj)
    {
        _db.Categories.Add(obj);
        _db.SaveChanges(); // this code will push the new record to the db

        return RedirectToAction("Index"); // redirect to action within the same controller

        // RedirectToAction("Index", "<controller>") -> example of redirect to action in another controller
    }
}
