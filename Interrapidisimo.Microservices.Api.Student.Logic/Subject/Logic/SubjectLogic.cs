using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.DTOs;
using Interrapidisimo.Microservices.Api.Student.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Interrapidisimo.Microservices.Api.Subject.Logic.Subject.Logic
{
    /// <summary>
    /// Logica de materias
    /// </summary>
    public class SubjectLogic : ISubjectLogic
    {
        /// <summary>
        /// context de base de datos
        /// </summary>
        private readonly StudentDbContext db;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="db"></param>
        public SubjectLogic(StudentDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// logica para obtener todas las materias
        /// </summary>
        /// <returns></returns>
        public async Task<List<SubjectDto>> GetAllAsync()
        {
            /// obtenemos las materias con sus profesores y estudiantes
            var subjects = await db.Subjects
                .Include(s => s.Teacher)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Student)
                .ToListAsync();

            /// mapeamos a dto y retorna
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
