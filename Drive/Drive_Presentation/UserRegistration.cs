using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.UI
{
    static public class UserRegistration
    {
        static public void LogIn()
        {
            Console.Clear();
            string email = InputHelper.CheckEmail("Insert email: ");
            Console.WriteLine("Password needs to have at least 8 characters.");
            string password = InputHelper.CheckPassword("Insert password: ");
        }

        static public void SignUp()
        {
            bool userExists = false;
            do
            {
                Console.Clear();
                string email = InputHelper.CheckEmail("Insert email: ");
                Console.WriteLine("Password needs to have at least 8 characters.");
                string password = InputHelper.CheckPassword("Insert password: ");
                string passwordCopy;
                do
                {
                    passwordCopy = InputHelper.CheckPassword("Insert password again: ");
                    if (!string.Equals(password, passwordCopy)) Console.WriteLine("Passwords do not match");
                    passwordCopy = "";
                } while (!string.Equals(password, passwordCopy));

                //userExists = UserExists(email)
                if (!userExists) Console.WriteLine("Email in use. Try different one.");
            } while (!userExists);

            Captcha();
        }

        static public void Captcha()
        {
            string userInput, captcha;
            do
            {
                captcha = new Guid().ToString("N");
                Console.WriteLine("Capcha: ", captcha);
                userInput = InputHelper.CheckUserInput("Repeat the input: ");
                if (string.Equals(userInput, captcha)) Console.WriteLine("Input not equal to captcha. Try again.");
            } while (string.Equals(userInput, captcha));
            Console.WriteLine("You're not a bot.");
        }

        static public void Logout() { }

        static public void ResetPassword() { }

        //treba timeout of 30 sekundi ako je netočna lozinka
        //static public bool UserExists(string email) {} 
    }
}
