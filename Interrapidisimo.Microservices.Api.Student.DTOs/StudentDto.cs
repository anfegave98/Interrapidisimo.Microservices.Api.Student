
namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    /// <summary>
    /// dto del estudiante
    /// </summary>
    public class StudentDto
    {
        /// <summary>
        /// id del estudiante
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// primer nombre
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// apellido
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// correo electrónico
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// fecha de creación
        /// </summary>
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
