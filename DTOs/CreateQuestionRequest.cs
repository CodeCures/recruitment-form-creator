using System.ComponentModel.DataAnnotations;

namespace RecruitmentFormCreator.DTOs
{
    public class CreateQuestionRequest
    {
        [Required]
        public Guid ApplicationFormId { get; set; }
        [Required]
        public string Text { get; set; } = string.Empty;
        [Required]
        public string QuestionType { get; set; } = string.Empty;
        public List<string>? Choices { get; set; }
    }
}