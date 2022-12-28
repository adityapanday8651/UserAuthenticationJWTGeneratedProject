using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Security.Policy;
using UserAuthenticationJWTGenerated.Dto;
using UserAuthenticationJWTGenerated.Interfaces;

namespace UserAuthenticationJWTGenerated.Repositories
{
   
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(EmailDto request)
        {
            //Set the all Information Here of share the through Email. 
            request.Body = "This is Google Link  <p><a href='https://www.google.com/'>Google</a></p>";

            var mails = new MimeMessage();
            mails.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            mails.To.Add(MailboxAddress.Parse(request.To));
            mails.Subject = request.Subject;
            mails.Body = new TextPart(TextFormat.Html) { Text = request.Body };
            

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(mails);
            smtp.Disconnect(true);
        }
    }
}
