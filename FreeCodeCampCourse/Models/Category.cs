using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FreeCodeCampCourse.Models
{
    public class Category
    {
        [Key]
        //Data annotations: this indicates that Id column has an index & primary key
        public int Id { get; set; }

        [DisplayName("Name")]
        public string CategoryName { get; set; }
        //Annotations allow us to show the column header as text we want instead of just column name
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
