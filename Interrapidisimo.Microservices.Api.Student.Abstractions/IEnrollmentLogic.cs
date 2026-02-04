using Interrapidisimo.Microservices.Api.Student.DTOs;

namespace Interrapidisimo.Microservices.Api.Student.Abstractions
{
    /// <summary>
    /// Interface para el servicio de inscripciones
    /// </summary>
    public interface IEnrollmentLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task EnrollAsync(CreateEnrollmentDto dto);
    }
}
