using System.Text.RegularExpressions;

namespace Drive.Domain
{
    public static class InputHelper
    {
        public static string CheckUserInput(string text)
        {
            string input;
            do
            {
                Console.Write(text);
                input = Console.ReadLine() ?? string.Empty;
                if (String.IsNullOrEmpty(input)) Console.WriteLine("Input cannot be empty.");
            } while (String.IsNullOrEmpty(input));
            Console.Clear();
            return input;
        }

        public static string CheckEmail(string text)
        {
            string pattern = @"^[^@]+@[a-zA-Z]{2,}\.[a-zA-Z]{3,}$";
            string email;

            while (true)
            {
                email = CheckUserInput(text);

                if (Regex.IsMatch(email, pattern))
                {
                    Console.WriteLine("Valid email format.");
                    return email;
                }

                else Console.WriteLine("Invalid email format.");
            }
        }

        public static string CheckPassword(string text)
        {
            string password;
            do
            {
                password = CheckUserInput(text);
                if (password.Length < 8) Console.WriteLine("Password needs to have at least 8 characters");
            } while (password.Length < 8);
            return password;
        }
    }
}
