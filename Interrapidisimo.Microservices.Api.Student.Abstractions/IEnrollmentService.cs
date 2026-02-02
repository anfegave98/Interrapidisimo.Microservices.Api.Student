using Interrapidisimo.Microservices.Api.Student.DTOs;

namespace Interrapidisimo.Microservices.Api.Student.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEnrollmentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task EnrollAsync(CreateEnrollmentDto dto);
    }
}
