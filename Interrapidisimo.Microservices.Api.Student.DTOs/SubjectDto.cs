
using Interrapidisimo.Microservices.Api.Student.Entities;

namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class SubjectDto
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
        public TeacherMiniDto Teacher { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public List<StudentMiniDto> Students { get; set; } = new();
    }
}
