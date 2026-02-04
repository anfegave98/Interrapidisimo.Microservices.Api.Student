using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.DTOs;
using Interrapidisimo.Microservices.Api.Student.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace Interrapidisimo.Microservices.Api.Student.Logic.Enrollment.Logic
{
    /// <summary>
    /// Logic de inscripciones
    /// </summary>
    public class EnrollmentLogic : IEnrollmentLogic
    {
        /// <summary>
        /// context de base de datos
        /// </summary>
        private readonly StudentDbContext db;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="db"></param>
        public EnrollmentLogic(StudentDbContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// Logica para inscribir un estudiante a una materia
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task EnrollAsync(CreateEnrollmentDto dto)
        {
            /// Obtener el estudiante con sus inscripciones y materias
            var student = await this.db.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Subject)
                .FirstOrDefaultAsync(s => s.Id == dto.StudentId);

            /// Validar que el estudiante exista
            if (student == null) 
            {
                throw new Exception("Estudiante no encontrado");
            }

            /// Validar que el estudiante no tenga mas de 3 materias
            if (student.Enrollments.Count >= 3) 
            { 
                throw new Exception("El estudiante solo puede tener 3 materias");
            }

            /// Obtener la materia con su profesor
            var subject = await this.db.Subjects
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(s => s.Id == dto.SubjectId);

            /// Validar que la materia exista
            if (subject == null) 
            {
                throw new Exception("Materia no encontrada");
            }

            /// Validar que el estudiante no tenga otra materia con el mismo profesor
            var sameTeacher = student.Enrollments
                .Any(e => e.Subject.TeacherId == subject.TeacherId);

            /// Si tiene el mismo profesor, lanzar una excepcion
            if (sameTeacher)
                throw new Exception("El estudiante no puede tener clase con el mismo profesor");

            /// Crear la inscripcion
            this.db.Enrollments.Add(new Entities.Enrollment
            {
                StudentId = dto.StudentId,
                SubjectId = dto.SubjectId
            });

            /// Guardar los cambios
            await this.db.SaveChangesAsync();
        }
    }
}
