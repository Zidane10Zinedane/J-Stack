using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Stack.Models
{
    public class Course
    {
        [Key]
        public int C_Id { get; set; }
        [Required(ErrorMessage = "Course name is required")]
        public string CourseName { get; set; }
        public int DurationMonths { get; set; }
        public int D_Id { get; set; }
        public virtual Degree degrees { get; set; }
    }
}