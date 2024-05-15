using Microsoft.EntityFrameworkCore;

namespace MobileParkTask.Records.Data;

public class RecordsDbContext(DbContextOptions<RecordsDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecordsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}