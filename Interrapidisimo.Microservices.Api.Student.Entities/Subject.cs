
namespace Interrapidisimo.Microservices.Api.Student.Entities
{
    /// <summary>
    /// entidad Subject
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// id de la entidad
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nombre de la materia
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// numero de creditos de la materia
        /// </summary>
        public int Credits { get; set; } = 3;
        /// <summary>
        /// id del profesor de la materia
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// informacion del profesor de la materia
        /// </summary>
        public Teacher Teacher { get; set; } = null!;
        /// <summary>
        /// listado de inscripciones de la materia
        /// </summary>
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
