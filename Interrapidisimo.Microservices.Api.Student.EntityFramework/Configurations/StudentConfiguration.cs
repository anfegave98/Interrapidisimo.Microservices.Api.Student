using Interrapidisimo.Microservices.Api.Student.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interrapidisimo.Microservices.Api.Student.EntityFramework.Configurations
{
    /// <summary>
    /// configuration para la entidad Student
    /// </summary>
    public class StudentConfiguration : IEntityTypeConfiguration<Entities.Student>
    {
        /// <summary>
        /// configura la entidad Student
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Entities.Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(s => s.Email)
                   .IsUnique();

            builder.Property(s => s.Created)
                   .HasDefaultValueSql("GETUTCDATE()");

            /// Relaciones
            builder.HasMany(s => s.Enrollments)
                   .WithOne(e => e.Student)
                   .HasForeignKey(e => e.StudentId);
        }
    }
}

