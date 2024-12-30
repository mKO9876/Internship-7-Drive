
// Drive.Data/DriveContextFactory.cs (New file)
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Drive.Data
{
    public class DriveContextFactory : IDesignTimeDbContextFactory<DriveContext>
    {
        public DriveContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("app.config.xml", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("DriveConnectionString");
            Console.WriteLine(connectionString);

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string 'DriveConnectionString' is missing in the config file.");
            }

            var options = new DbContextOptionsBuilder<DriveContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DriveContext(options);
        }
    }
}