using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace RecruitmentForm.Models.QuestionTypes
{
    public class MultipleChoiceQuestion : QuestionBase
    {
        public List<string> Choices { get; set; } = [];
    }
}