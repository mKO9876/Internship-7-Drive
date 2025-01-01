using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DriveApp.Data
{
    public class DriveAppContextFactory : IDesignTimeDbContextFactory<DriveAppContext>
    {
        public DriveAppContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("app.config")
                .Build();
            config.Providers
                .First()
                .TryGet("connectionStrings:add:DriveApp:connectionStrings", out var connectionString);

            Console.WriteLine(connectionString);

            var options = new DbContextOptionsBuilder<DriveAppContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DriveAppContext(options);
        }
    }
}