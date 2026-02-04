using Interrapidisimo.Microservices.Api.Student.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interrapidisimo.Microservices.Api.Student.EntityFramework.Configurations
{
    /// <summary>
    /// Configuracion de la entidad Teacher para Entity Framework Core.
    /// </summary>
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        /// <summary>
        /// configura la entidad Teacher.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            /// Configura la relación uno a muchos entre Teacher y Subject.
            builder.HasMany(t => t.Subjects)
                   .WithOne(s => s.Teacher)
                   .HasForeignKey(s => s.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

