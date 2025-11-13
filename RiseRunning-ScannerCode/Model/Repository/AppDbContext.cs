using Microsoft.EntityFrameworkCore;
using RiseRunning_ScannerCode.Model.Entity;

namespace RiseRunning_ScannerCode.Model.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RunnerEntity> TB_RUNNERS { get; set; }
    }
}
