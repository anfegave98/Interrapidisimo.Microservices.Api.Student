using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.DTOs;
using Interrapidisimo.Microservices.Api.Student.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Interrapidisimo.Microservices.Api.Subject.Logic.Subject.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SubjectService : ISubjectService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly StudentDbContext db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public SubjectService(StudentDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<SubjectDto>> GetAllAsync()
        {
            var subjects = await db.Subjects
                .Include(s => s.Teacher)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Student)
                .ToListAsync();

            return subjects.Select(s => new SubjectDto
            {
                Id = s.Id,
                Name = s.Name,
                Credits = s.Credits,

                Teacher = new TeacherMiniDto
                {
                    Id = s.Teacher.Id,
                    Name = s.Teacher.Name
                },

                Students = s.Enrollments
                    .Select(e => new StudentMiniDto
                    {
                        Id = e.Student.Id,
                        FullName = $"{e.Student.FirstName} {e.Student.LastName}"
                    })
                    .ToList()

            }).ToList();
        }
    }
}
