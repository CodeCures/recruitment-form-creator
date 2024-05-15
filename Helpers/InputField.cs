using System.ComponentModel.DataAnnotations;

namespace RecruitmentFormCreator.Helpers
{
    public class InputField
    {
        [Required]
        public string? Name { get; set; }
        public bool IsRequired { get; set; }
        public bool IsInternal { get; set; }
        public bool IsHidden { get; set; }
    }
}