using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class QuestionBase
    {
        public Guid Id { get; set; }
        [Required]
        public string? Text { get; set; }
        [Required]
        public string? QuestionType { get; set; }
    }
}