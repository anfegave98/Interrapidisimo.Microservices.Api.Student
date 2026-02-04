

namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    /// <summary>
    /// dto para representar información mínima de una materia.
    /// </summary>
    public class SubjectMiniDto
    {
        /// <summary>
        /// id de la materia
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nombre de la materia
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// numero de creditos
        /// </summary>
        public int Credits { get; set; }
    }

}
