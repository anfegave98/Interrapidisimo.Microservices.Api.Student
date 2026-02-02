using Interrapidisimo.Microservices.Api.Student.DTOs;


namespace Interrapidisimo.Microservices.Api.Student.Abstractions
{
    public interface ITeacherService
    {
        Task<List<TeacherDto>> GetAllAsync();
    }

}
