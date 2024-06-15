using SendGrid;
using SendGrid.Helpers.Mail;
namespace QuestionBank.Models
{
    public class EmailSender
    {
        private readonly string _sendGridApiKey;

        public EmailSender(string sendGridApiKey)
        {
            _sendGridApiKey = sendGridApiKey;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var msg = new SendGridMessage
            {
                From = new EmailAddress("your-email@example.com", "Your Name"),
                Subject = subject,
                HtmlContent = htmlMessage,
                PlainTextContent = htmlMessage // optional: you can also provide plain text content
            };
            msg.AddTo(new EmailAddress(email));

            var response = await client.SendEmailAsync(msg);
        }
    }
}
