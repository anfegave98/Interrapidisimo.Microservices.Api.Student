
namespace Interrapidisimo.Microservices.Api.Student.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public int Credits { get; set; } = 3;
        /// <summary>
        /// 
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Teacher Teacher { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
