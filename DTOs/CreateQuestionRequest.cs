using System.ComponentModel.DataAnnotations;

namespace RecruitmentFormCreator.DTOs
{
    public class CreateQuestionRequest
    {
        [Required]
        public string? Text { get; set; }
        [Required]
        public string? QuestionType { get; set; }
        public List<string>? Choices { get; set; } = [];

    }
}