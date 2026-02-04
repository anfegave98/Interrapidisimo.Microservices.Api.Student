using Interrapidisimo.Microservices.Api.Student.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interrapidisimo.Microservices.Api.Student.EntityFramework.Configurations
{
    /// <summary>
    /// configuracion de la entidad Subject
    /// </summary>
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        /// <summary>
        /// configura la entidad Subject
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(120);

            builder.Property(s => s.Credits)
                   .HasDefaultValue(3)
                   .IsRequired();

            /// Relaciones
            builder.HasOne(s => s.Teacher)
                   .WithMany(t => t.Subjects)
                   .HasForeignKey(s => s.TeacherId);

            builder.HasMany(s => s.Enrollments)
                   .WithOne(e => e.Subject)
                   .HasForeignKey(e => e.SubjectId);
        }
    }
}

