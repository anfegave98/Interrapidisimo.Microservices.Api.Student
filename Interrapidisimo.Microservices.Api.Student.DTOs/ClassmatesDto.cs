namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassmatesDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public List<string> Classmates { get; set; } = new();
    }
}
