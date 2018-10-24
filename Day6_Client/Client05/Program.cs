using System;
using System.Net;
using System.Net.Mail;

// SMTP Client
namespace EmailSmtp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential("jkys1990@gmail.com", "doitgetit90");

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("jkys1990@gmail.com"),
                    Subject = "Test email.",
                    Body = "Test email body"
                };

                mail.To.Add(new MailAddress("jkys1990@gmail.com"));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                // Send it...         
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in sending email: " + ex.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Email sccessfully sent");
            Console.ReadKey();
        }
    }
}
