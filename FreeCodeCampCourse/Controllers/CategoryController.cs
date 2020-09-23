using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCodeCampCourse.Data;
using FreeCodeCampCourse.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeCodeCampCourse.Controllers
{
    public class CategoryController : Controller
    {
        //Add dependancy injection to return the data from Category table.
        private readonly ApplicationDbContext _db;

        //Pulls the db container that uses dependancy injection (DI) in Startup.ConfigureServices
        //ApplicationDbContext db "object" has an instance of the ApplicationDbContext container that the 
        //DI would pass thru the constructor
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            //This can be empty because user will create a new category
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //This checks the values against any validation rules defined in Category.cs model.
            //If the values are valid, then it will add a new category to the database.
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                //You need to commit first (Entity Framework) to add the new category to the database.
                _db.SaveChanges();
                //It's redirecting to the same Controller, so no need to identify it.
                return RedirectToAction("Index");
            }
            //Otherwise, just return the values and its error msg.
            return View(obj);

        }

        //GET - EDIT
        //The int? means that parameter can be NULL.
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //This checks the values against any validation rules defined in Category.cs model.
            //If the values are valid, then it will add a new category to the database.
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                //You need to commit first (Entity Framework) to update the category to the database.
                _db.SaveChanges();
                //It's redirecting to the same Controller, so no need to identify it.
                return RedirectToAction("Index");
            }
            //Otherwise, just return the values and its error msg.
            return View(obj);

        }

        //GET - DELETE
        //The int? means that parameter can be NULL.
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            //This checks the values against any validation rules defined in Category.cs model.
            //If the values are valid, then it will add a new category to the database.
            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            //You need to commit first (Entity Framework) to add the new category to the database.
            _db.SaveChanges();
            //It's redirecting to the same Controller, so no need to identify it.
            return RedirectToAction("Index");
        }

    }
}
