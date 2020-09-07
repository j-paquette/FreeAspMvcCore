﻿using System;
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
    }
}