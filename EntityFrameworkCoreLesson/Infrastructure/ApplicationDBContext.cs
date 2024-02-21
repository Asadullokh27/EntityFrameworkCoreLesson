using EntityFrameworkCoreLesson.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreLesson.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<LearningCentre> LearningCentres { get; set; }

    }
}
