namespace Interrapidisimo.Microservices.Api.Student.Entities
{
    /// <summary>
    /// Entidad Enrollment
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// id de la matricula
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// id del estudiante
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// informacion del estudiante
        /// </summary>
        public Student Student { get; set; } = null!;
        /// <summary>
        /// id de la materia
        /// </summary>
        public int SubjectId { get; set; }
        /// <summary>
        /// informacion de la materia
        /// </summary>
        public Subject Subject { get; set; } = null!;
    }
}
