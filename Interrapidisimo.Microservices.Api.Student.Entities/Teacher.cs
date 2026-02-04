namespace Interrapidisimo.Microservices.Api.Student.Entities
{
    /// <summary>
    /// Entidad Teacher
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// id de la entidad
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nombre del profesor
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// listado de materias del profesor
        /// </summary>
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
