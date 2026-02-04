
using Interrapidisimo.Microservices.Api.Student.Entities;

namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    /// <summary>
    /// dto para materia
    /// </summary>
    public class SubjectDto
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
        public int Credits { get; set; } = 3;
        /// <summary>
        /// id del profesor
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// informacion del profesor
        /// </summary>
        public TeacherMiniDto Teacher { get; set; } = null!;
        /// <summary>
        /// Lista de estudiantes inscritos en la materia
        /// </summary>
        public List<StudentMiniDto> Students { get; set; } = new();
    }
}
