using Interrapidisimo.Microservices.Api.Student.Entities;
using Microsoft.EntityFrameworkCore;

namespace Interrapidisimo.Microservices.Api.Student.EntityFramework
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Student> Students => Set<Entities.Student>();
    }
}
