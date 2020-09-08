using FreeCodeCampCourse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCodeCampCourse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //This class "...DbContext" inherits from Entity Framework DbContext
            //Configuration to use DbContext    
        }
        
        public DbSet<Category> Category { get; set; }
        //This is the entity that I want to create in the database

        public DbSet<ApplicationType> ApplicationType { get; set; }


    }
}
