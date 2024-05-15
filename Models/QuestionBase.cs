using System.ComponentModel.DataAnnotations;

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