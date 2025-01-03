namespace DriveApp.Domain
{
    static public class UserRegistration
    {

        static public void LogIn()
        {
            Console.Clear();
            Console.WriteLine("Log In");
            string email;
            do
            {
                email = InputHelper.CheckEmail("Insert email: ");
                if (!UserExists(email)) Console.WriteLine("Email in use. Try different one.");
            } while (!UserExists(email));
        }

        static public void SignUp()
        {
            Console.Clear();
            Console.WriteLine("Sign up");
            string email;
            do
            {
                email = InputHelper.CheckEmail("Insert email: ");
                if (UserExists(email)) Console.WriteLine("Email in use. Try different one.");
            } while (UserExists(email));

            string password = "11111111";
            PasswordTimer(password);
            Captcha();
            //triba napraviti novom korisniku 3 nova direktorija
        }

        static private async void PasswordTimer(string originalPassword)
        {
            string passwordAttempt;
            int maxAttempts = 3;
            int attempt = 1;
            int timeoutSeconds = 5;

            while (true)
            {
                if (attempt % maxAttempts == 0)
                {
                    Console.WriteLine("Too many failed attempts. Wait 30 seconds.");
                    await Task.Delay(timeoutSeconds * 1000);
                }

                passwordAttempt = InputHelper.CheckPassword("Insert password again: ");

                if (!string.Equals(passwordAttempt, originalPassword))
                {
                    Console.WriteLine("Passwords do not match");
                    passwordAttempt = "";
                    attempt++;
                }
                else break;
            }
        }

        static private void Captcha()
        {
            string userInput, captcha;
            do
            {
                captcha = Guid.NewGuid().ToString("N");
                Console.WriteLine($"Captcha: {captcha}");
                userInput = InputHelper.CheckUserInput("Repeat the input: ");
                if (!string.Equals(userInput, captcha)) Console.WriteLine("Input not equal to captcha. Try again.");
            } while (!string.Equals(userInput, captcha));
            Console.WriteLine("You're not a bot.");
        }

        static public void Logout() { }

        static public void ResetPassword() { }

        static public bool UserExists(string email)
        {
            return true;
        }
    }
}
