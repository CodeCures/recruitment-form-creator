using RecruitmentFormCreator.Helpers;
using TestApp.DTOs;
using TestApp.Models;

namespace TestApp.Mappers
{
    public static class ApplicationFormMappers
    {
        public static ApplicationForm ToApplicationFormModel(this CreateApplicationFormRequest request)
        {
            return new ApplicationForm
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
                new InputField{
                    Name = "Nationality",
                    Label = "Nationality",
                    IsRequired = false,
                    IsHidden = false,
                    IsInternal = false
                },
                new InputField{
                    Name = "CurrentResidence",
                    Label = "Current Residence",
                    IsRequired = false,
                    IsHidden = false,
                    IsInternal = false
                },
                new InputField{
                    Name = "IdNumber",
                    Label = "ID Number",
                    IsRequired = false,
                    IsHidden = false,
                    IsInternal = false
                },
                new InputField{
                    Name = "DateOfBirth",
                    Label = "Date of Birth",
                    IsRequired = false,
                    IsHidden = false,
                    IsInternal = false
                },
                new InputField{
                    Name = "Gender",
                    Label = "Gender",
                    IsRequired = false,
                    IsHidden = false,
                    IsInternal = false
                }
            ];
        }
    }
}