using System.Net.Mail;
using System.Net;

namespace QuestionBank.Models
{
    public class MailSender
    {
        public void SendMail(string gmail, string username, string password)
        {
            string smtpServer = "smtp.gmail.com";
            int port = 587;
            bool enableSSL = true;
            string userName = "nguyenthanhtuoi1230@gmail.com";
            string passWord = "gjiq rwwb vmos bltj";

            // Tạo đối tượng SmtpClient
            using (var client = new SmtpClient(smtpServer, port))
            {
                client.EnableSsl = enableSSL;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(userName, passWord);

                // Cấu hình thông điệp email
                var from = new MailAddress("nguyenthanhtuoi1230@gmail.com", "Hutech");
                var to = new MailAddress(gmail, "Hutech");
                var message = new MailMessage(from, to);
                message.Subject = "Cảm ơn bạn đã đăng ký tài khoản";
                //string htmlBody = @"
                //    <html>
                //    <head>
                //        <style>
                //            body {
                //                font-family: Arial, sans-serif;
                //                font-size: 14px;
                //                color: #333;
                //            }
                //            h1 {
                //                color: #333;
                //            }
                //            p {
                //                color: #666;
                //            }
                //        </style>
                //    </head>
                //    <body>
                //        <h1>Lưu ý nhớ đổi mật khẩu.</h1>
                //        <p>
                //           Hello, {0}<br/>
                //           Đây là tài khoản của bạn.<br/>
                //           Tên đăng nhập: {0},<br/>
                //           Mật khẩu: {1}
                //        </p>
                //    </body>
                //    </html>
                //";
                message.Body =
                               "Lưu ý: Nhớ đổi mật khẩu" +
                               "\nUsername: " + username +
                               "\nPassword: " + password;
                //message.IsBodyHtml = true;
                try
                {
                    // Gửi email
                    client.Send(message);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send email: {ex.Message}");
                }
            }
        }
    }
}
