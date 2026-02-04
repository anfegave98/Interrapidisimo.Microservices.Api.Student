using Microsoft.EntityFrameworkCore;
using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.DTOs;
using Interrapidisimo.Microservices.Api.Student.EntityFramework;

namespace Interrapidisimo.Microservices.Api.Student.Logic.Student.Logic
{
    /// <summary>
    /// logica de estudiantes
    /// </summary>
    public class StudentLogic : IStudentLogic
    {
        /// <summary>
        /// context de base de datos
        /// </summary>
        private readonly StudentDbContext db;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="db"></param>
        public StudentLogic(StudentDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Logica para crear un estudiante
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<StudentDto> CreateAsync(Entities.Student student)
        {
            /// crear la entidad de estudiante
            var studentinfo = new Entities.Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Created = DateTime.UtcNow,

            };

            /// agregar a la base de datos
            this.db.Students.Add(studentinfo);
            /// guardar cambios
            await this.db.SaveChangesAsync();

            /// retornar el estudiante mapeado
            return Map(student);
        }

        /// <summary>
        /// logica para obtener todos los estudiantes
        /// </summary>
        /// <returns></returns>
        public async Task<List<StudentDto>> GetAllAsync()
        {
            /// retornar la lista de estudiantes mapeados
            return await this.db.Students
                .Select(s => Map(s))
                .ToListAsync();
        }

        /// <summary>
        /// logica para obtener un estudiante por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            /// buscar el estudiante por id
            var student = await this.db.Students.FindAsync(id);

            /// retornar el estudiante mapeado o null si no existe
            return student == null ? null : Map(student);
        }

        /// <summary>
        /// logica para eliminar un estudiante por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            /// buscar el estudiante por id
            var student = await this.db.Students.FindAsync(id);

            /// si no existe, retornar false
            if (student == null) return false;

            /// eliminar el estudiante
            this.db.Students.Remove(student);
            /// guardar cambios
            await this.db.SaveChangesAsync();

            /// retornar true
            return true;
        }

        /// <summary>
        /// Logica para actualizar un estudiante
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(int id, Entities.Student student )
        {
            /// buscar el estudiante por id
            var studentData = await this.db.Students.FindAsync(id);

            /// si no existe, retornar false
            if (studentData == null)
                return false;

            /// actualizar los datos del estudiante
            studentData.FirstName = student.FirstName;
            studentData.LastName = student.LastName;
            studentData.Email = student.Email;

            /// guardar cambios
            await this.db.SaveChangesAsync();

            /// retornar true
            return true;
        }

        /// <summary>
        /// logica para obtener los compañeros de clase de un estudiante
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<List<ClassmatesDto>> GetClassmates(int studentId)
        {
            /// obtener los ids de las materias en las que el estudiante esta inscrito
            var subjectIds = await this.db.Enrollments
                .Where(x => x.StudentId == studentId)
                .Select(x => x.SubjectId)
                .ToListAsync();

            /// obtener los compañeros de clase en esas materias, excluyendo al estudiante mismo
            var flatData = await this.db.Enrollments
                .Where(x => subjectIds.Contains(x.SubjectId) && x.StudentId != studentId)
                .Select(x => new
                {
                    SubjectName = x.Subject.Name,
                    StudentName = x.Student.FirstName + " " + x.Student.LastName
                })
                .ToListAsync();

            /// agrupar por materia y crear el DTO de compañeros de clase
            var result = flatData
                .GroupBy(x => x.SubjectName)
                .Select(g => new ClassmatesDto
                {
                    Subject = g.Key,
                    Classmates = g.Select(x => x.StudentName)
                                  .Distinct()
                                  .ToList()
                })
                .ToList();

            /// retornar el resultado
            return result;
        }

        /// <summary>
        /// mapea una entidad de estudiante a un dto de estudiante
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static StudentDto Map(Entities.Student s) => new()
        {
            Id = s.Id,
            Email = s.Email,
            Created = s.Created,
            FirstName = s.FirstName,
            LastName = s.LastName

        };

    }
}
