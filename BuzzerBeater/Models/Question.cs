using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BuzzerBeater.Models
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }
        public int LeftOperand { get; set; }
        public int RightOperand { get; set; }
        public string Operator { get; set; }
        public int CorrectAnswer { get; set; }

        [NotMapped]
        public string Answer { get; set; }

        [Required]
        public virtual Test Test { get; set; }

        public Question() { QuestionId = Guid.NewGuid(); }
    }
}