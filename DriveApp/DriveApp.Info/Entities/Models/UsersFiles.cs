namespace DriveApp.Info.Entities.Models
{
        public class UsersFiles
        {
            public int UserId { get; set; }
            public Users User { get; set; } = null!;

            public int FileId { get; set; }
            public Files File { get; set; } = null!;

            public int Owner {  get; set; }
        }
}
