using Interrapidisimo.Microservices.Api.Student.Entities;
using Microsoft.EntityFrameworkCore;

namespace Interrapidisimo.Microservices.Api.Student.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class StudentDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.SubjectId })
                .IsUnique();

            modelBuilder.Entity<Subject>().Property(s => s.Credits).HasDefaultValue(3);

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "Profesor Juan Perez" },
                new Teacher { Id = 2, Name = "Profesor Maria Gomez" },
                new Teacher { Id = 3, Name = "Profesor Carlos Ruiz" },
                new Teacher { Id = 4, Name = "Profesor Ana Torres" },
                new Teacher { Id = 5, Name = "Profesor. Luis Herrera" }
            );


            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Matematicas", Credits = 3, TeacherId = 1 },
                new Subject { Id = 2, Name = "Fisica", Credits = 3, TeacherId = 1 },

                new Subject { Id = 3, Name = "Quimica", Credits = 3, TeacherId = 2 },
                new Subject { Id = 4, Name = "Biologia", Credits = 3, TeacherId = 2 },

                new Subject { Id = 5, Name = "Historia", Credits = 3, TeacherId = 3 },
                new Subject { Id = 6, Name = "Geografia", Credits = 3, TeacherId = 3 },

                new Subject { Id = 7, Name = "Programacion", Credits = 3, TeacherId = 4 },
                new Subject { Id = 8, Name = "Base de Datos", Credits = 3, TeacherId = 4 },

                new Subject { Id = 9, Name = "Economia", Credits = 3, TeacherId = 5 },
                new Subject { Id = 10, Name = "Estadistica", Credits = 3, TeacherId = 5 }
            );

            modelBuilder.Entity<Entities.Student>().HasData(
                new Entities.Student { Id = 1, FirstName = "Andres", LastName = "Galeano", Email = "andres.galeano@gmail.com" },
                new Entities.Student { Id = 2, FirstName = "Isabella", LastName = "Roche", Email = "isabella@gmail.com" },
                new Entities.Student { Id = 3, FirstName = "Andrea", LastName = "Velasco", Email = "andrea@gmail.com" },
                new Entities.Student { Id = 4, FirstName = "Felipe", LastName = "Velasco", Email = "felipe@gmail.com" },
                new Entities.Student { Id = 5, FirstName = "Danya", LastName = "Sotelo", Email = "danya@gmail.com" }
            );

            modelBuilder.Entity<Enrollment>().HasData(

                new Enrollment { Id = 1, StudentId = 1, SubjectId = 1 },
                new Enrollment { Id = 2, StudentId = 1, SubjectId = 3 }, 
                new Enrollment { Id = 3, StudentId = 1, SubjectId = 7 }, 

                new Enrollment { Id = 4, StudentId = 2, SubjectId = 1 }, 
                new Enrollment { Id = 5, StudentId = 2, SubjectId = 5 }, 
                new Enrollment { Id = 6, StudentId = 2, SubjectId = 7 }, 

                new Enrollment { Id = 7, StudentId = 3, SubjectId = 1 }, 
                new Enrollment { Id = 8, StudentId = 3, SubjectId = 3 }, 

                new Enrollment { Id = 9, StudentId = 4, SubjectId = 5 }, 
                new Enrollment { Id = 10, StudentId = 4, SubjectId = 7 }, 


                new Enrollment { Id = 11, StudentId = 5, SubjectId = 1 }, 
                new Enrollment { Id = 12, StudentId = 5, SubjectId = 7 }  
            );

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Entities.Student> Students => Set<Entities.Student>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Teacher> Teachers => Set<Teacher>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Subject> Subjects => Set<Subject>();
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    }
}
