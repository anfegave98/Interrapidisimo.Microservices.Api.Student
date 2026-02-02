using Interrapidisimo.Microservices.Api.Student.DTOs;

namespace Interrapidisimo.Microservices.Api.Student.Abstractions { 

    public interface IStudentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<StudentDto> CreateAsync(Entities.Student student);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<StudentDto>> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentDto?> GetByIdAsync(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(int id, Entities.Student student);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<List<ClassmatesDto>> GetClassmates(int studentId);

    }
}