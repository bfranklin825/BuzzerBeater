using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BuzzerBeater.Models
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        [Column("FirstName")]
        public string FirstName { get; set; }
        [StringLength(1, ErrorMessage = "Middle initial cannot be longer than 1 character.")]
        public string MiddleInt { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Grade { get; set; }
        public string School { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public Person() { }
    }
}