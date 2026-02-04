namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    /// <summary>
    /// Dto de creación de inscripción
    /// </summary>
    public class CreateEnrollmentDto
    {
        /// <summary>
        /// id del estudiante
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// id de la materia
        /// </summary>
        public int SubjectId { get; set; }
    }
}
