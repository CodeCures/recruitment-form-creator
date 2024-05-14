
using System.Text.Json.Serialization;
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
        MultipleChoice,
        TrueFalse,
        OpenEnded
    }
}