using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuzzerBeater.Models
{
    public class Teacher : Person
    {
        [Key]
        public Guid TeacherId { get; set; }
        public string Email { get; set; }

        public virtual School MySchool { get; set; }

        //public virtual ICollection<Class> Classes { get; set; }
        //public virtual ICollection<Test> Tests { get; set; }

        public Teacher() { TeacherId = Guid.NewGuid(); }
    }
}