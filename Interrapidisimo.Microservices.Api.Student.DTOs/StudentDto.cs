
namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    public class StudentDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
