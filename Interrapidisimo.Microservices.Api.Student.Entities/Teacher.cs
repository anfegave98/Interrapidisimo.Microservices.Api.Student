namespace Interrapidisimo.Microservices.Api.Student.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Teacher
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
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
