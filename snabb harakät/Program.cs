// See https://aka.ms/new-console-template for more information


using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RandomPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //frågar email adressen som lösenordet ska skickas till
            Console.Write("Enter your email address: ");
            string recipient = Console.ReadLine();

            // extremt komplex lösning på att göra ett lösenord
            string password = GeneratePassword();

            // Skickar lösenordet till email adressen som är skriven
            SendEmail(recipient, password);

            Console.WriteLine("Password sent successfully!");
        }

        //väldigt komplex sätt att lösa ett slumpmässigt lösenord
        static string GeneratePassword()
        {
            //allt som kan väljas för att bli lösenord
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{};:,.<>/?";

            Random rand = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < 12; i++)
            {
                password.Append(allowedChars[rand.Next(allowedChars.Length)]);
            }

            return password.ToString();
        }

        //extremt komplex kod som används för att skicka det genererade lösenordet till den givna emailen
        //genom gmails smtp server
        static void SendEmail(string recipient, string password)
        {
            const string sender = "haidoriskickar@gmail.com";
            const string senderPassword = "npykhzrvmbjyrxrd";

            MailMessage message = new MailMessage(sender, recipient, "Your random password", password);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(sender, senderPassword);

            //cool felhanterin
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}



