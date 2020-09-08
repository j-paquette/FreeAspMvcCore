using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCodeCampCourse.Data;
using FreeCodeCampCourse.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeCodeCampCourse.Controllers
{
    public class ApplicationTypeController : Controller
    {
        //Add dependancy injection to return the data from Category table.
        private readonly ApplicationDbContext _db;

        //Pulls the db container that uses dependancy injection (DI) in Startup.ConfigureServices
        //ApplicationDbContext db "object" has an instance of the ApplicationDbContext container that the 
        //DI would pass thru the constructor
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
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
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            //You need to commit first (Entity Framework) to add the new category to the database.
            _db.SaveChanges();
            //It's redirecting to the same Controller, so no need to identify it.
            return RedirectToAction("Index");
        }
    }
}
