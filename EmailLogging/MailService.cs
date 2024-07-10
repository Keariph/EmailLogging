using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using EmailLogging.Models;
using Microsoft.Extensions.Configuration;

namespace EmailLogging
{
    /// <summary>
    /// Forms and tryes to send the email
    /// </summary>
    public class MailService
    {
        /// <summary>
        /// Initialize a new instance of the MailSevice class with special options for sending email
        /// </summary>
        public MailService() 
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<MailService>();
        }

        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }

        /// <summary>
        /// Form and try to send the email
        /// </summary>
        /// <param name="email">The instance of the Email class</param>
        public void SendMessage(Email email)
        {
            string goodResult = "OK";
            string failedResult = "FAILED";
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(SenderName, SenderEmail));
            InternetAddressList addressList = new InternetAddressList();
            
            foreach (string recepient in email.Recipients)
            {
                addressList.Add(new MailboxAddress(recepient, recepient));
            }

            message.To.AddRange(addressList);
            message.Subject = email.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = email.Body
            };

            var smtp = new SmtpClient();

            try
            {
                smtp.Connect(SmtpServer, SmtpPort, false);
                smtp.Authenticate(Username, Password);
                smtp.Send(message);
                email.Result = goodResult;
            }
            catch (Exception ex)
            {
                email.FailedMessage = ex.Message;
                email.Result = failedResult;
                return;
            }
            finally
            {               
                smtp.Disconnect(true);
                smtp.Dispose();              
            }   
        }
    }
}
