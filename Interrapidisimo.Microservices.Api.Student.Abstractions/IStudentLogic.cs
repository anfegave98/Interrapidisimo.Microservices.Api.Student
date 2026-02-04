using Interrapidisimo.Microservices.Api.Student.DTOs;

namespace Interrapidisimo.Microservices.Api.Student.Abstractions {

    /// <summary>
    /// interface para el servicio de estudiantes
    /// </summary>
    public interface IStudentLogic
    {
        /// <summary>
        /// servicio para crear un estudiante
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<StudentDto> CreateAsync(Entities.Student student);
        /// <summary>
        /// servicio para obtener todos los estudiantes
        /// </summary>
        /// <returns></returns>
        Task<List<StudentDto>> GetAllAsync();
        /// <summary>
        /// servicio para obtener un estudiante por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentDto?> GetByIdAsync(int id);
        /// <summary>
        /// servicio para eliminar un estudiante por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// servicio para actualizar un estudiante
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(int id, Entities.Student student);
        /// <summary>
        /// servicio para obtener los compañeros de clase de un estudiante
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<List<ClassmatesDto>> GetClassmates(int studentId);

    }
}