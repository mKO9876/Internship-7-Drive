using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Drive.Data.Entities.Models;
using Microsoft.Extensions.Configuration;
using Drive.Data.Seeds;


namespace Drive.Data
{
    public class DriveContext : DbContext
    {
        public DriveContext(DbContextOptions<DriveContext> options) : base(options) { }


        public DbSet<Users> Users => Set<Users>();
        public DbSet<Directories> Diretories => Set<Directories>();
        public DbSet<Files> Files => Set<Files>();
        public DbSet<Comments> Comments => Set<Comments>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ovo je za veze
            modelBuilder.Entity<UsersFiles>().HasKey(uf => new { uf.UserId, uf.FileId });

            modelBuilder.Entity<DirectoriesFiles>().HasKey(uf => new { uf.DirectoryId, uf.FileId });
            
            modelBuilder.Entity<Comments>().HasKey(c => c.CommentId);

            modelBuilder.Entity<Directories>().HasKey(c => c.DirectoryId);

            modelBuilder.Entity<Files>().HasKey(c => c.FileId);

            modelBuilder.Entity<Users>().HasKey(c => c.UserId);


            modelBuilder.Entity<Comments>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);


            modelBuilder.Entity<Directories>()
            .HasOne(uf => uf.User)
            .WithMany(f => f.Directories)
            .HasForeignKey(uf => uf.UserId);

            modelBuilder.Entity<UsersFiles>()
            .HasOne(uf => uf.User)
            .WithMany(u => u.UsersFiles)
            .HasForeignKey(uf => uf.UserId);

            modelBuilder.Entity<UsersFiles>()
            .HasOne(uf => uf.File)
            .WithMany(f => f.UsersFiles)
            .HasForeignKey(uf => uf.FileId);

            modelBuilder.Entity<DirectoriesFiles>()
            .HasOne(uf => uf.Directory)
            .WithMany(u => u.DirectoriesFiles)
            .HasForeignKey(uf => uf.DirectoryId);

            modelBuilder.Entity<DirectoriesFiles>()
            .HasOne(uf => uf.File)
            .WithMany(f => f.DirectoriesFiles)
            .HasForeignKey(uf => uf.FileId);

            DatabaseSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public class DriveContextFactory : IDesignTimeDbContextFactory<DriveContext>
        {
            public DriveContext CreateDbContext(string[] args)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddXmlFile("app.config.xml")
                    .Build();
                //.AddXmlFile("app.config.xml", optional: false, reloadOnChange: true)

                // Get the connection string from the config
                var connectionString = config.GetConnectionString("DriveConnectionString");
                Console.WriteLine(config);


                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("The connection string 'DriveConnectionString' is missing in the config file.");
                }


                var options = new DbContextOptionsBuilder<DriveContext>()
                    .UseNpgsql(connectionString)
                    .Options;

                return new DriveContext(options);
            }



            private static IConfiguration LoadAppConfig()
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddXmlFile("App.config.xml")  // Specify App.config.xml
                    .Build();

                return config;
            }
        }

    

    }
}

