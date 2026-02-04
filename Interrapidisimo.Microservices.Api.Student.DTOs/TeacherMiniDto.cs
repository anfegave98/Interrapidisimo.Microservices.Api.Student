
namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    /// <summary>
    /// Dto para representar un profesor en forma reducida.
    /// </summary>
    public class TeacherMiniDto
    {
        /// <summary>
        /// id del profesor.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nombre del profesor.
        /// </summary>
        public string Name { get; set; } = null!;
    }

}
