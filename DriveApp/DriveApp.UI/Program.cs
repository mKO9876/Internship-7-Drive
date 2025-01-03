using DriveApp.Domain;
namespace DriveApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("1 - Log in\n2 - Sign up\n3 - Quit");
                string userInput = InputHelper.CheckUserInput("Select: ");
                //int userId; -> login i signup bi tribali vraćati id osobe
                switch (userInput)
                {
                    case "1":
                        UserRegistration.LogIn();
                        UserDirectories();
                        break;
                    case "2":
                        UserRegistration.SignUp();
                        UserDirectories();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Unknown action. Try again.");
                        break;
                }
            }
        }

        static void UserDirectories()
        {
            Console.WriteLine("1 - My Disc\n2 - Shared with me\n3 - Settings\n4 - Log Out");
            string userInput = InputHelper.CheckUserInput("Select: ");
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("My Disc");
                    break;
                case "2":
                    Console.WriteLine("shared");
                    break;
                case "3":
                    Console.WriteLine("Settings");
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Unknown action. Try again.");
                    break;
            }

        }
    }
}
