using Microsoft.EntityFrameworkCore;

namespace NailDown.Server.Data {
    public class AppDBContext : DbContext {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {

        }
    }
}
