using Interrapidisimo.Microservices.Api.Student.Entities;
using Interrapidisimo.Microservices.Api.Student.EntityFramework.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Interrapidisimo.Microservices.Api.Student.EntityFramework
{
    /// <summary>
    /// Contexto de base de datos del microservicio de estudiantes
    /// </summary>
    public class StudentDbContext : DbContext
    {
        /// <summary>
        /// Constructor del contexto
        /// </summary>
        /// <param name="options"></param>
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configura las entidades y carga semillas de datos
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas las configuraciones Fluent API automáticamente
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentDbContext).Assembly);

            // Carga los datos semilla
            SeedData.Load(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Tabla Students
        /// </summary>
        public DbSet<Entities.Student> Students => Set<Entities.Student>();

        /// <summary>
        /// Tabla Teachers
        /// </summary>
        public DbSet<Teacher> Teachers => Set<Teacher>();

        /// <summary>
        /// Tabla Subjects
        /// </summary>
        public DbSet<Subject> Subjects => Set<Subject>();

        /// <summary>
        /// Tabla Enrollments
        /// </summary>
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    }
}

