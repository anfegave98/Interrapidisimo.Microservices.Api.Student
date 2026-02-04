using Interrapidisimo.Microservices.Api.Student.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interrapidisimo.Microservices.Api.Student.EntityFramework.Configurations
{
    /// <summary>
    /// Configuracion de la entidad Enrollment
    /// </summary>
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        /// <summary>
        /// configura la entidad Enrollment
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments");

            builder.HasKey(e => e.Id);

            ///clave foranea a Student
            builder.HasOne(e => e.Student)
                   .WithMany(s => s.Enrollments)
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
            ///clave foranea a Subject
            builder.HasOne(e => e.Subject)
                   .WithMany(s => s.Enrollments)
                   .HasForeignKey(e => e.SubjectId)
                   .OnDelete(DeleteBehavior.Cascade);

            /// Indice unico para evitar que un estudiante se inscriba dos veces en la misma materia
            builder.HasIndex(e => new { e.StudentId, e.SubjectId })
                   .IsUnique();
        }
    }
}
