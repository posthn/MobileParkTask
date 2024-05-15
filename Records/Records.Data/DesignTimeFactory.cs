using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MobileParkTask.Records.Data;

public class DesignTimeFactory : IDesignTimeDbContextFactory<RecordsDbContext>
{
    public RecordsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RecordsDbContext>();

        optionsBuilder.UseNpgsql(string.Empty);

        return new RecordsDbContext(optionsBuilder.Options);
    }
}
