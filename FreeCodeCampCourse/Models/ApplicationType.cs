using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCodeCampCourse.Models
{
    public class ApplicationType
    {
        [Key]
        //Data annotations: this indicates that Id column has an index & primary key
        public int ApplicationTypeId { get; set; }

        [DisplayName("Name")]
        [Required]
        public string ApplicationTypeName { get; set; }

    }
}
