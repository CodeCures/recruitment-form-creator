using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RecruitmentForm.DTOs;
using RecruitmentForm.Models;
using RecruitmentForm.Models.QuestionTypes;
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
                "Date" => DateQuestion(questionRequest),
                "Dropdown" => DropdownQuestion(questionRequest),
                "YesOrNo" => YesOrNoQuestion(questionRequest),
                

                _ => throw new NotImplementedException()
            };

        }

        private static ParagraphQuestion ParagraphQuestion(CreateQuestionRequest questionRequest)
        {
            return new ParagraphQuestion
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

        private static DateQuestion DateQuestion(CreateQuestionRequest questionRequest)
        {
            return new DateQuestion
            {
                Text = questionRequest.Text,
                QuestionType = questionRequest.QuestionType
            };
        }

        private static DropdownQuestion DropdownQuestion(CreateQuestionRequest questionRequest)
        {
            return new DropdownQuestion
            {
                Text = questionRequest.Text,
                QuestionType = questionRequest.QuestionType,
                Choices = questionRequest.Choices
            };
        }

        private static MultipleChoiceQuestion MultipleChoiceQuestion(CreateQuestionRequest questionRequest)
        {
            return new MultipleChoiceQuestion
            {
                Text = questionRequest.Text,
                QuestionType = questionRequest.QuestionType,
                Choices = questionRequest.Choices
            };
        }

        private static YesOrNoQuestion YesOrNoQuestion(CreateQuestionRequest questionRequest)
        {
            return new YesOrNoQuestion
            {
                Text = questionRequest.Text,
                QuestionType = questionRequest.QuestionType
            };
        }
    }
}