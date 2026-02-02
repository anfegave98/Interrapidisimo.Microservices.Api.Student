using Microsoft.EntityFrameworkCore;
using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.DTOs;
using Interrapidisimo.Microservices.Api.Student.EntityFramework;

namespace Interrapidisimo.Microservices.Api.Student.Logic.Student.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class StudentService : IStudentService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly StudentDbContext db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public StudentService(StudentDbContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<StudentDto> CreateAsync(Entities.Student student)
        {
            var studentinfo = new Entities.Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Created = DateTime.UtcNow,

            };

            this.db.Students.Add(studentinfo);
            await this.db.SaveChangesAsync();

            return Map(student);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<StudentDto>> GetAllAsync()
        {
            return await this.db.Students
                .Select(s => Map(s))
                .ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await this.db.Students.FindAsync(id);
            return student == null ? null : Map(student);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var student = await this.db.Students.FindAsync(id);
            if (student == null) return false;

            this.db.Students.Remove(student);
            await this.db.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(int id, Entities.Student student )
        {
            var studentData = await this.db.Students.FindAsync(id);

            if (studentData == null)
                return false;

            studentData.FirstName = student.FirstName;
            studentData.LastName = student.LastName;
            studentData.Email = student.Email;

            await this.db.SaveChangesAsync();

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<List<ClassmatesDto>> GetClassmates(int studentId)
        {
            var subjectIds = await this.db.Enrollments
                .Where(x => x.StudentId == studentId)
                .Select(x => x.SubjectId)
                .ToListAsync();

            var flatData = await this.db.Enrollments
                .Where(x => subjectIds.Contains(x.SubjectId) && x.StudentId != studentId)
                .Select(x => new
                {
                    SubjectName = x.Subject.Name,
                    StudentName = x.Student.FirstName + " " + x.Student.LastName
                })
                .ToListAsync();

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

            return result;
        }

        /// <summary>
        /// 
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
