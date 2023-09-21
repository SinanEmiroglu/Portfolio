using Microsoft.EntityFrameworkCore;
using NailDown.Shared.Model;

namespace NailDown.Server.Data {
    public class AppDBContext : DbContext {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {

        }

        public DbSet<JobModel> Jobs { get; set; }
    }
}
