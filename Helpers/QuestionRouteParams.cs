
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestApp.Helpers
{
    public class QuestionRouteParams
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public QuestionType QuestionType { get; set; }
    }

    public enum QuestionType
    {
        [Display]
        MultipleChoice,
        [Display]
        TrueFalse,
        [Display]
        OpenEnded
    }
}