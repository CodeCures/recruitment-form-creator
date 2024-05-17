using RecruitmentFormCreator.Helpers;
using TestApp.DTOs;
using TestApp.Models;

namespace TestApp.Mappers
{
    public static class ProgramMappers
    {
        public static AppProgram ToProgramModel(this CreateProgramRequest request)
        {
            return new AppProgram
            {
                Title = request.Title,
                Description = request.Description,
                PersonalInputFields = PersonalInputFields()
            };
        }

        private static List<InputField> PersonalInputFields()
        {
            return [
                new InputField{
                    Name = "FirstName",
                    Label = "First Name",
                    IsRequired = true,
                    IsHidden = false,
                    IsInternal = false
                },
                new InputField{
                    Name = "LastName",
                    Label = "Last Name",
                    IsRequired = true,
                    IsHidden = false,
                    IsInternal = false
                },
                new InputField{
                    Name = "Email",
                    Label = "Email Address",
                    IsRequired = true,
                    IsHidden = false,
                    IsInternal = false
                },
                new InputField{
                    Name = "PhoneNumber",
                    Label = "Phone Number",
                    IsRequired = false,
                    IsHidden = false,
                    IsInternal = false
                },
            ];
        }
    }
}