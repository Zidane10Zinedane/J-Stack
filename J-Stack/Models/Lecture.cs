using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Stack.Models
{
    public class Lecture
    {
        [Key]
        public int L_Id { get; set; }
        [Required(ErrorMessage = "Names can't be null")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string Forenames { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string getFirstName(string Forenames)
        {
            string FirstName = "";
            var spaceIndex = Forenames.IndexOf(" ");
            FirstName = Forenames.Substring(0, spaceIndex);
            return FirstName;
        }

        public string geFullName(string Forenames, string LastName)
        {
            string FulltName = Forenames + " " + LastName;
            return FulltName;
        }
        public int D_Id { get; set; }
        public virtual Degree degrees { get; set; }
    }
}