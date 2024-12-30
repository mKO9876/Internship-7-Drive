namespace Drive.Data.Entities.Models
{
    public class Files
    {
        public Files(string fileName) { 
            FileName = fileName;
            LastChanged = DateTime.UtcNow;
        }

        public int FileId { get; set; }
        public string FileName { get; set; } = null!;
        public DateTime LastChanged { get; set; }

        public ICollection<UsersFiles> UsersFiles { get; set; } = new List<UsersFiles>();
        public ICollection<DirectoriesFiles> DirectoriesFiles { get; set; } = new List<DirectoriesFiles>();

    }

}
