using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FreeCodeCampCourse.Models
{
    public class Category
    {
        [Key]
        //Data annotations: this indicates that Id column has an index & primary key
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
