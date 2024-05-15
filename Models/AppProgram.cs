using RecruitmentFormCreator.Helpers;

namespace TestApp.Models
{
    public class AppProgram
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<InputField> PersonalInfos { get; set; } = [];
        public List<QuestionBase> Questions { get; set; } = [];
    }
}