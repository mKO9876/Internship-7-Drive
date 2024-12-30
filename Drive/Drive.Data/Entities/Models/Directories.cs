namespace Drive.Data.Entities.Models
{
    public class Directories
    {
        public Directories(string directoryName, DateTime createdDate)
        {
            DirectoryName = directoryName;
            CreatedDate = createdDate;
        }
        public int DirectoryId { get; set; }
        public int UserId { get; set; }

        public string DirectoryName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public Users User { get; set; } = null!;

        public ICollection<DirectoriesFiles> DirectoriesFiles { get; set; } = new List<DirectoriesFiles>();
    }
}
