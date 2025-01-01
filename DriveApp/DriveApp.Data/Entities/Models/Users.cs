namespace DriveApp.Data.Entities.Models
{
    public class Users
    {
        public Users(string email, string password) { 
            Email = email;
            Password = password;
        }
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public ICollection<Comments> Comments { get; set; } = new List<Comments>();
        public ICollection<Directories> Directories { get; set; } = new List<Directories>();
        public ICollection<UsersFiles> UsersFiles { get; set; } = new List<UsersFiles>();
    }

}
