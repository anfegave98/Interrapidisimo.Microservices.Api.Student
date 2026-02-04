namespace Interrapidisimo.Microservices.Api.Student.Entities
{
    /// <summary>
    /// Entidad Student
    /// </summary>
    public class Student
    {
        /// <summary>
        /// id de la entidad
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nombre del estudiante
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// apellido del estudiante
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// correo del estudiante
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// fecha de creacion del estudiante
        /// </summary>
        public DateTime Created { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// lista de inscripciones del estudiante
        /// </summary>
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
