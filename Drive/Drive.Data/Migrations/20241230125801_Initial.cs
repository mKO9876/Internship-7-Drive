using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    LastChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    CommentText = table.Column<string>(type: "text", nullable: false),
                    CommentingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diretory",
                columns: table => new
                {
                    DirectoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    DirectoryName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretory", x => x.DirectoryId);
                    table.ForeignKey(
                        name: "FK_Diretory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersFiles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFiles", x => new { x.UserId, x.FileId });
                    table.ForeignKey(
                        name: "FK_UsersFiles_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersFiles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectoriesFiles",
                columns: table => new
                {
                    DirectoryId = table.Column<int>(type: "integer", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoriesFiles", x => new { x.DirectoryId, x.FileId });
                    table.ForeignKey(
                        name: "FK_DirectoriesFiles_Diretory_DirectoryId",
                        column: x => x.DirectoryId,
                        principalTable: "Diretory",
                        principalColumn: "DirectoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectoriesFiles_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "File",
                columns: new[] { "FileId", "FileName", "LastChanged" },
                values: new object[,]
                {
                    { 1, "Resume.pdf", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "VacationPhoto.jpg", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "ProjectPlan.docx", new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "MusicTrack.mp3", new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "VideoClip.mp4", new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Presentation.pptx", new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Backup.zip", new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Archive.tar.gz", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "cmurrells13@xrea.com", "qF3czvmaacr" },
                    { 2, "aklousner0@disqus.com", "lX5JIBd2X9" },
                    { 3, "jdunton1@independent.co.uk", "yJ7pdXOtk" },
                    { 4, "voborne2@artisteer.com", "eO4oorIPc" },
                    { 5, "hbrownhall3@intel.com", "0wX7dieS" },
                    { 6, "gbarnewall4@comsenz.com", "cE5MEA4r1NE=C" },
                    { 7, "dbantham5@businessinsider.com", "XDFCGVHBUNIJKOLP" },
                    { 8, "cchuter6@blogspot.com", "cvhbnjkml" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "CommentText", "CommentingDate", "FileId", "UserId" },
                values: new object[,]
                {
                    { 1, "Great job on this document!", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, "Can we improve the formatting?", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, "This section is unclear, please revise.", new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 4, "Awesome photo, very well taken!", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 5, "Add more details about the project timeline.", new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 6, "The video quality is amazing!", new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 4 },
                    { 7, "Consider compressing this file further.", new DateTime(2023, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3 },
                    { 8, "This archive is missing some files.", new DateTime(2023, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4 }
                });

            migrationBuilder.InsertData(
                table: "Diretory",
                columns: new[] { "DirectoryId", "CreatedDate", "DirectoryName", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 30, 12, 58, 0, 163, DateTimeKind.Utc).AddTicks(85), "Documents", 1 },
                    { 2, new DateTime(2024, 12, 30, 12, 58, 0, 163, DateTimeKind.Utc).AddTicks(907), "Photos", 1 },
                    { 3, new DateTime(2024, 12, 30, 12, 58, 0, 163, DateTimeKind.Utc).AddTicks(908), "Music", 2 },
                    { 4, new DateTime(2024, 12, 30, 12, 58, 0, 163, DateTimeKind.Utc).AddTicks(910), "Videos", 2 },
                    { 5, new DateTime(2024, 12, 30, 12, 58, 0, 163, DateTimeKind.Utc).AddTicks(911), "Projects", 3 },
                    { 6, new DateTime(2024, 12, 30, 12, 58, 0, 163, DateTimeKind.Utc).AddTicks(912), "Downloads", 3 },
                    { 7, new DateTime(2024, 12, 30, 12, 58, 0, 163, DateTimeKind.Utc).AddTicks(913), "Backups", 4 },
                    { 8, new DateTime(2024, 12, 30, 12, 58, 0, 163, DateTimeKind.Utc).AddTicks(938), "Archives", 4 }
                });

            migrationBuilder.InsertData(
                table: "UsersFiles",
                columns: new[] { "FileId", "UserId", "Owner" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 3, 2, 1 },
                    { 4, 2, 2 },
                    { 5, 3, 3 },
                    { 6, 3, 2 },
                    { 7, 4, 4 },
                    { 8, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "DirectoriesFiles",
                columns: new[] { "DirectoryId", "FileId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 7 },
                    { 4, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectoriesFiles_FileId",
                table: "DirectoriesFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Diretory_UserId",
                table: "Diretory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFiles_FileId",
                table: "UsersFiles",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "DirectoriesFiles");

            migrationBuilder.DropTable(
                name: "UsersFiles");

            migrationBuilder.DropTable(
                name: "Diretory");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
