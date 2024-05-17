using RecruitmentFormCreator.Helpers;

namespace TestApp.DTOs
{
    public class CreateApplicationFormRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}