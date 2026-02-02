using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.DTOs;
using Interrapidisimo.Microservices.Api.Student.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace Interrapidisimo.Microservices.Api.Student.Logic.Enrollment.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class EnrollmentService : IEnrollmentService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly StudentDbContext db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public EnrollmentService(StudentDbContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task EnrollAsync(CreateEnrollmentDto dto)
        {
            var student = await this.db.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Subject)
                .FirstOrDefaultAsync(s => s.Id == dto.StudentId);

            if (student == null) 
            {
                throw new Exception("Estudiante no encontrado");
            }

            if (student.Enrollments.Count >= 3) 
            { 
                throw new Exception("El estudiante solo puede tener 3 materias");
            }
                
            var subject = await this.db.Subjects
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(s => s.Id == dto.SubjectId);

            if (subject == null) 
            {
                throw new Exception("Materia no encontrada");
            }
                

            var sameTeacher = student.Enrollments
                .Any(e => e.Subject.TeacherId == subject.TeacherId);


            if (sameTeacher)
                throw new Exception("El estudiante no puede tener clase con el mismo profesor");

            this.db.Enrollments.Add(new Entities.Enrollment
            {
                StudentId = dto.StudentId,
                SubjectId = dto.SubjectId
            });

            await this.db.SaveChangesAsync();
        }
    }
}
