using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DriveApp.Info
{
    public class DriveAppContextFactory : IDesignTimeDbContextFactory<DriveAppContext>
    {
        public DriveAppContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddXmlFile("app.config.xml", optional: false, reloadOnChange: true);

            var config = builder.Build();

            config.Providers
                .First()
                .TryGet("connectionStrings:add:DriveApp:connectionString", out var connectionString);

            var options = new DbContextOptionsBuilder<DriveAppContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DriveAppContext(options);
        }
    }
}