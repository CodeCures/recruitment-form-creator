using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestApp.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        [Required]
        public string Text { get; set; } = string.Empty;
        [Required]
        public string QuestionType { get; set; } = string.Empty;
        public List<string>? Choices { get; set; }
        public Guid AppProgramId { get; set; }
        [JsonIgnore]
        public AppProgram AppProgram { get; set; }
    }
}