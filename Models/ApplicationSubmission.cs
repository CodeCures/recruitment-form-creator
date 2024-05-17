using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RecruitmentFormCreator.Helpers;
using TestApp.Models;

namespace RecruitmentFormCreator.Models
{
    public class ApplicationSubmission
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResidence { get; set; }
        public string? IdNumber { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public List<QuestionAnswer> AdditionalDetails { get; set; } = [];
        [Required]
        public Guid ApplicationFormId { get; set; }
        [JsonIgnore]
        public ApplicationForm? ApplicationForm { get; set; }


    }
}