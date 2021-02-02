using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Stack.Models
{
    public class Degree
    {
        [Key]
        public int D_Id { get; set; }
        [Required(ErrorMessage = "Degree name is required")]
        public string DegreeName { get; set; }
        public int DurationYears { get; set; }
        public virtual ICollection<Student> students { get; set; }
        public virtual ICollection<Course> courses { get; set; }
        public virtual ICollection<Degree> degrees { get; set; }
    }
}