using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuzzerBeater.Models
{
    public class TestHistory
    {
        [Key]
        public Guid TestHistoryId { get; set; }
        public DateTime DateTaken { get; set; }
        public TimeSpan ElaspedTime { get; set; }
        public int Score { get; set; }

        public virtual Test Test { get; set; }
        public virtual Student Student { get; set; }

        public TestHistory() { TestHistoryId = Guid.NewGuid(); }
    }
}