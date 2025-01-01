namespace DriveApp.Data.Entities.Models
{
    public class DirectoriesFiles
    {
        public int DirectoryId { get; set; }
        public Directories Directory { get; set; } = null!;

        public int FileId { get; set; }
        public Files File { get; set; } = null!;
    }
}
