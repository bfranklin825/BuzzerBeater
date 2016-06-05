using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuzzerBeater.Models
{
    public class Class
    {
        [Key]
        public Guid ClassId { get; set; }
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }
        public int Year { get; set; }

        public virtual List<Student> Students { get; set; }
        public virtual Teacher Teacher { get; set; }

        //[NotMapped] 
        [Display(Name = "Student Count")]
        public int StudentCount
        {
            get { return Students.Count; }
        }

        public Class()
        {
            ClassId = Guid.NewGuid();
            Students = new List<Student>();
        }
    }
}