namespace Interrapidisimo.Microservices.Api.Student.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Student Student { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public int SubjectId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Subject Subject { get; set; } = null!;
    }
}
