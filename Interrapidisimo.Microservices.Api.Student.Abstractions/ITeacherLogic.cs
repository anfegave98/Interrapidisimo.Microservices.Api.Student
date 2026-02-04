using Interrapidisimo.Microservices.Api.Student.DTOs;


namespace Interrapidisimo.Microservices.Api.Student.Abstractions
{
    /// <summary>
    /// interface para el servicio de profesores
    /// </summary>
    public interface ITeacherLogic
    {
        /// <summary>
        /// servicio para obtener todos los profesores
        /// </summary>
        /// <returns>lista de profesores</returns>
        Task<List<TeacherDto>> GetAllAsync();
    }

}
