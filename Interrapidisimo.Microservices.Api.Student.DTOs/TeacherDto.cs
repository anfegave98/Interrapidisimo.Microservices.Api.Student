

namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    /// <summary>
    /// Dto para representar un profesor.
    /// </summary>
    public class TeacherDto
    {
        /// <summary>
        /// id del profesor.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nombre del profesor.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// lista de materias que imparte el profesor.
        /// </summary>
        public List<SubjectMiniDto> Subjects { get; set; } = new();
    }

}
