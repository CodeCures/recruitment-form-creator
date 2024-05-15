using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RecruitmentFormCreator.DTOs;
using TestApp.Models;
using TestApp.Models.QuestionTypes;

namespace RecruitmentFormCreator.Mappers
{
    public static class QuestionMapper
    {
        public static QuestionBase ToQuestionTypeModel(this CreateQuestionRequest questionRequest)
        {
            return questionRequest.QuestionType switch
            {
                "Paragraph" => ParagraphQuestion(questionRequest),
                "Number" => NumberQuestion(questionRequest),
                _ => throw new NotImplementedException()
            };

        }

        private static ParagraphQuesion ParagraphQuestion(CreateQuestionRequest questionRequest)
        {
            return new ParagraphQuesion
            {
                Text = questionRequest.Text,
                QuestionType = questionRequest.QuestionType
            };
        }

        private static NumberQuestion NumberQuestion(CreateQuestionRequest questionRequest)
        {
            return new NumberQuestion
            {
                Text = questionRequest.Text,
                QuestionType = questionRequest.QuestionType
            };
        }
    }
}