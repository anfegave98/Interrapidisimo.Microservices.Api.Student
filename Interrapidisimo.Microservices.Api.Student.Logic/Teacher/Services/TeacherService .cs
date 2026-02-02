using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.DTOs;
using Interrapidisimo.Microservices.Api.Student.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Interrapidisimo.Microservices.Api.Student.Logic.Teacher.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly StudentDbContext db;

        public TeacherService(StudentDbContext db)
        {
            this.db = db;
        }

        public async Task<List<TeacherDto>> GetAllAsync()
        {
            var teachers = await db.Teachers
                .Include(t => t.Subjects)
                .ToListAsync();

            return teachers.Select(t => new TeacherDto
            {
                Id = t.Id,
                Name = t.Name,

                Subjects = t.Subjects.Select(s => new SubjectMiniDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Credits = s.Credits
                }).ToList()

            }).ToList();
        }
    }
}
