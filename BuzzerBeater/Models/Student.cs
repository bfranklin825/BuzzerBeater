using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuzzerBeater.Models
{
    public class Student : Person
    {
        [Key]
        public Guid StudentId { get; set; }

        [Display(Name = "User Name")]
        [MinLength(6, ErrorMessage = "Usernames must be at least 6 characters.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage = "Passwords must be at least 6 characters.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Password { get; set; }

        //public virtual Class AssignedClass { get; set; }
        public virtual ICollection<TestHistory> History { get; set; }

        public Student() { StudentId = Guid.NewGuid(); }
    }
}