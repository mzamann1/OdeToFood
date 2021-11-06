using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContextFactory : IDesignTimeDbContextFactory<OdeToFoodDbContext>
    {

        OdeToFoodDbContext IDesignTimeDbContextFactory<OdeToFoodDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<OdeToFoodDbContext>();
            var connectionString = configuration.GetConnectionString("OdeToFoodDb");

            builder.UseSqlServer(connectionString);
            return new OdeToFoodDbContext(builder.Options);
        }
    }
}
