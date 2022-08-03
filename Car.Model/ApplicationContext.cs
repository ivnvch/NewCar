using Microsoft.EntityFrameworkCore;

namespace Car.Model
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<CarC> Cars { get; set; } = null!;
        public DbSet<Person> People{ get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext): base(dbContext)
            => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarC>()
                .HasOne(c => c.Company)
                .WithMany(a => a.Cars)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
