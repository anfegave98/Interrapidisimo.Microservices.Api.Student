

namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<SubjectMiniDto> Subjects { get; set; } = new();
    }

}
