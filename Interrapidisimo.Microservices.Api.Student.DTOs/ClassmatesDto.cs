namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    /// <summary>
    /// Dto para compañeros de clase
    /// </summary>
    public class ClassmatesDto
    {
        /// <summary>
        /// Materia
        /// </summary>
        public string Subject { get; set; } = null!;
        /// <summary>
        /// compañeros de clase
        /// </summary>
        public List<string> Classmates { get; set; } = new();
    }
}
