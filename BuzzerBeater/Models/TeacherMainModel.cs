using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuzzerBeater.Models
{
    public class TeacherMainModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Test> Tests { get; set; }
    }
}