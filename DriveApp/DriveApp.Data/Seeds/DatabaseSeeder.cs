using DriveApp.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace DriveApp.Data.Seeds
{

    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Users>().HasData(
                new Users("cmurrells13@xrea.com", "qF3czvmaacr") { UserId = 1 },
                new Users("aklousner0@disqus.com", "lX5JIBd2X9") { UserId = 2 },
                new Users("jdunton1@independent.co.uk", "yJ7pdXOtk") { UserId = 3 },
                new Users("voborne2@artisteer.com", "eO4oorIPc") { UserId = 4 },
                new Users("hbrownhall3@intel.com", "0wX7dieS") { UserId = 5 },
                new Users("gbarnewall4@comsenz.com", "cE5MEA4r1NE=C") { UserId = 6 },
                new Users("dbantham5@businessinsider.com", "XDFCGVHBUNIJKOLP") { UserId = 7 },
                new Users("cchuter6@blogspot.com", "cvhbnjkml") { UserId = 8 }
            );

            builder.Entity<Directories>().HasData(
            new Directories("Documents", new DateTime(2023, 1, 10))
            {
                DirectoryId = 1,
                UserId = 1
            },
            new Directories("Photos", new DateTime(2023, 1, 10))
            {
                DirectoryId = 2,
                UserId = 1
            },
            new Directories("Music", new DateTime(2023, 1, 10))
            {
                DirectoryId = 3,
                UserId = 2
            },
            new Directories("Videos", new DateTime(2023, 1, 10))
            {
                DirectoryId = 4,
                UserId = 2
            },
            new Directories("Projects", new DateTime(2023, 1, 10))
            {
                DirectoryId = 5,
                UserId = 3
            },
            new Directories("Downloads", new DateTime(2023, 1, 10))
            {
                DirectoryId = 6,
                UserId = 3
            },
            new Directories("Backups", new DateTime(2023, 1, 10))
            {
                DirectoryId = 7,
                UserId = 4
            },
            new Directories("Archives", new DateTime(2023, 1, 10))
            {
                DirectoryId = 8,
                UserId = 4
            });

            builder.Entity<Files>().HasData(
                 new Files("Resume.pdf", new DateTime(2023, 1, 10)) { FileId = 1 },
                 new Files("VacationPhoto.jpg", new DateTime(2023, 2, 15)) { FileId = 2 },
                 new Files("ProjectPlan.docx", new DateTime(2023, 3, 5)) { FileId = 3 },
                 new Files("MusicTrack.mp3", new DateTime(2023, 4, 20)) { FileId = 4 },
                 new Files("VideoClip.mp4", new DateTime(2023, 5, 25)) { FileId = 5 },
                 new Files("Presentation.pptx", new DateTime(2023, 6, 30)) { FileId = 6 },
                 new Files("Backup.zip", new DateTime(2023, 7, 10)) { FileId = 7 },
                 new Files("Archive.tar.gz", new DateTime(2023, 8, 15)) { FileId = 8 }
             );

            builder.Entity<Comments>().HasData(
            new Comments("Great job on this document!", new DateTime(2023, 1, 12))
            {
                CommentId = 1,
                UserId = 1,
                FileId = 1
            },
            new Comments("Can we improve the formatting?", new DateTime(2023, 2, 18))
            {
                CommentId = 2,
                UserId = 2,
                FileId = 2
            },
            new Comments("This section is unclear, please revise.", new DateTime(2023, 3, 22))
            {
                CommentId = 3,
                UserId = 1,
                FileId = 3
            },
            new Comments("Awesome photo, very well taken!", new DateTime(2023, 4, 5))
            {
                CommentId = 4,
                UserId = 3,
                FileId = 4
            },
            new Comments("Add more details about the project timeline.", new DateTime(2023, 5, 14))
            {
                CommentId = 5,
                UserId = 2,
                FileId = 5
            },
            new Comments("The video quality is amazing!", new DateTime(2023, 6, 7))
            {
                CommentId = 6,
                UserId = 4,
                FileId = 6
            },
            new Comments("Consider compressing this file further.", new DateTime(2023, 7, 29))
            {
                CommentId = 7,
                UserId = 3,
                FileId = 7
            },
            new Comments("This archive is missing some files.", new DateTime(2023, 8, 21))
            {
                CommentId = 8,
                UserId = 4,
                FileId = 8
            });

            builder.Entity<DirectoriesFiles>().HasData(
            new { DirectoryId = 1, FileId = 1 },
            new { DirectoryId = 1, FileId = 2 },
            new { DirectoryId = 2, FileId = 3 },
            new { DirectoryId = 2, FileId = 4 },
            new { DirectoryId = 3, FileId = 5 },
            new { DirectoryId = 3, FileId = 6 },
            new { DirectoryId = 4, FileId = 7 },
            new { DirectoryId = 4, FileId = 8 });

            builder.Entity<UsersFiles>().HasData(
            new { UserId = 1, FileId = 1, Owner = 1 },
            new { UserId = 1, FileId = 2, Owner = 1 },
            new { UserId = 2, FileId = 3, Owner = 1 },
            new { UserId = 2, FileId = 4, Owner = 2 },
            new { UserId = 3, FileId = 5, Owner = 3 },
            new { UserId = 3, FileId = 6, Owner = 2 },
            new { UserId = 4, FileId = 7, Owner = 4 },
            new { UserId = 4, FileId = 8, Owner = 4 });
        }
    }

}