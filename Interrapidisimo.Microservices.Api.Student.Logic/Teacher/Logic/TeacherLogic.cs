using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.DTOs;
using Interrapidisimo.Microservices.Api.Student.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Interrapidisimo.Microservices.Api.Student.Logic.Teacher.Logic
{
    /// <summary>
    /// Logica de profesores
    /// </summary>
    public class TeacherLogic : ITeacherLogic
    {

        /// <summary>
        /// Context de base de datos
        /// </summary>
        private readonly StudentDbContext db;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="db"></param>
        public TeacherLogic(StudentDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// logica para obtener todos los profesores
        /// </summary>
        /// <returns></returns>
        public async Task<List<TeacherDto>> GetAllAsync()
        {
            /// obtenemos los profesores con sus materias
            var teachers = await db.Teachers
                .Include(t => t.Subjects)
                .ToListAsync();

            /// mapeamos a dto
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
