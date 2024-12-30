namespace Drive.UI
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
            string email;
            do
            {
                email = CheckUserInput(text);
                if (!email.Contains('@') || email.Length < 3) Console.WriteLine("Input didn't fill requirement: min. length = 3, has to contain @.");
            } while (!email.Contains('@') || email.Length < 3);

            return email;
        }

        public static string CheckPassword(string text)
        {
            string password;
            do
            {
                password = CheckUserInput(text);
                if (password.Length < 3) Console.WriteLine("Password needs to have at least 8 characters");
            } while (password.Length < 8);
            return password;
        }
    }
}
