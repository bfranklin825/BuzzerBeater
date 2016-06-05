using BuzzerBeater.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuzzerBeater.Models
{
    public class Test
    {
        private BuzzerBeaterContext db = new BuzzerBeaterContext();

        [Key]
        public Guid TestId { get; set; }
        [Display(Name = "Test Name")]
        public string TestName { get; set; }
        [Display(Name = "Is Default Test?")]
        public Boolean DefaultTest { get; set; }
        [Display(Name = "Is Test Active?")]
        public Boolean Active { get; set; }
        [Display(Name = "Number of Questions")]
        public int NumberOfQuestions { get; set; }


        private int _duration;
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        public int GetSeconds { get { return _duration * 60; } }

        public virtual Teacher Owner { get; set; }
        //public virtual ICollection<Question> Questions { get; set; }

        public Test() { TestId = Guid.NewGuid(); }

        //public Test(Guid testid)
        //{
        //    //TestId = Guid.NewGuid();
        //    NumberOfQuestions = db.Questions.Where(t => t.Test.TestId == testid).Count();            
        //}
    }
}