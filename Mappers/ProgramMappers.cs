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
                PersonalInfos = request.PersonalInfos
            };
        }
    }
}