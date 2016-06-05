using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuzzerBeater.fonts
{
    public class School
    {
        [Key]
        public Guid SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCity { get; set; }
        public string SchoolState { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolZipCode { get; set; }
        public string SchoolPhoneNumber { get; set; }

        public School() { SchoolId = Guid.NewGuid(); }
    }
}