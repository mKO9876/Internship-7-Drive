using DriveApp.Info.Entities.Models;
using DriveApp.Info.Seeds;
using Microsoft.EntityFrameworkCore;
namespace DriveApp.Info
{
    public class DriveAppContext : DbContext
    {
        public DriveAppContext(DbContextOptions<DriveAppContext> options) : base(options) { }
        public DriveAppContext() : base() { }

        public DbSet<Users> Users => Set<Users>();
        public DbSet<Directories> Diretories => Set<Directories>();
        public DbSet<Files> Files => Set<Files>();
        public DbSet<Comments> Comments => Set<Comments>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersFiles>().HasKey(uf => new { uf.UserId, uf.FileId });
            modelBuilder.Entity<DirectoriesFiles>().HasKey(uf => new { uf.DirectoryId, uf.FileId });
            modelBuilder.Entity<Comments>().HasKey(c => c.CommentId);
            modelBuilder.Entity<Directories>().HasKey(c => c.DirectoryId);
            modelBuilder.Entity<Files>().HasKey(c => c.FileId);
            modelBuilder.Entity<Users>().HasKey(c => c.UserId);

            modelBuilder.Entity<Directories>()
                .Property(d => d.CreatedDate)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder.Entity<Files>()
                .Property(d => d.LastChanged)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder.Entity<Comments>()
                .Property(d => d.CommentingDate)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));



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
    }
}
