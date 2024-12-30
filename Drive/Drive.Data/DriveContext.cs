using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Drive.Data.Entities.Models;
using Microsoft.Extensions.Configuration;
using Drive.Data.Seeds;


namespace Drive.Data
{
    public class DriveContext : DbContext
    {
        public DriveContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //        optionsBuilder.UseNpgsql(connectionString);
        //    }
        //}

        public DbSet<Users> User => Set<Users>();
        public DbSet<Directories> Diretory => Set<Directories>();
        public DbSet<Files> File => Set<Files>();
        public DbSet<Comments> Comment => Set<Comments>();

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

            DatabaseSeeder.Seed(modelBuilder); ;
            base.OnModelCreating(modelBuilder);
        }

        public class DriveContextFactory : IDesignTimeDbContextFactory<DriveContext>
        {
            public DriveContext CreateDbContext(string[] args)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddXmlFile("App.config.xml")
                    .Build();

                config.Providers
                    .First()
                    .TryGet("connectionString:add:Drive:connectionString", out var connectionString);

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

