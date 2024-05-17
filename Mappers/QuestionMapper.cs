using RecruitmentFormCreator.DTOs;
using TestApp.Models;

namespace RecruitmentFormCreator.Mappers
{
    public static class QuestionMapper
    {
        public static Question ToQuestionModel(this CreateQuestionRequest questionRequest)
        {
            return new Question
            {
                AppProgramId = questionRequest.ProgramId,
                Text = questionRequest.Text,
                QuestionType = questionRequest.QuestionType,
                Choices = questionRequest.Choices,
            };
        }
    }
}