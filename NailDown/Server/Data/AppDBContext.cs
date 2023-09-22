using Microsoft.EntityFrameworkCore;
using NailDown.Shared.Model;

namespace NailDown.Server.Data {
    public class AppDBContext : DbContext {
        public DbSet<JobModel> Jobs { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<JobModel>().HasData(
                new JobModel { Id = 1, Title = "Register to gym", Description = "Totus", Status = JobStatus.Done, LastEditDate = DateTime.Now },
                new JobModel { Id = 2, Title = "Unregister to gym", Description = "Totus", Status = JobStatus.Doing, LastEditDate = DateTime.Now },
                new JobModel { Id = 3, Title = "Reregister to gym", Description = "Totus", Status = JobStatus.Todo, LastEditDate = DateTime.Now }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
