using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace HotelManagementSystem.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendBookingConfirmationAsync(string toEmail, string guestName, string roomName, DateTime checkin, DateTime checkout)
        {
            var smtpServer = _config["EmailSettings:SmtpServer"];
            var port = int.Parse(_config["EmailSettings:Port"]);
            var senderEmail = _config["EmailSettings:SenderEmail"];
            var password = _config["EmailSettings:Password"]; // Add this in json!

            var body = $@"
                Hello {guestName},<br><br>
                Thank you for booking with Cloud9 Suites!<br><br>
                <strong>Room:</strong> {roomName}<br>
                <strong>Check-in:</strong> {checkin:MMM dd, yyyy}<br>
                <strong>Check-out:</strong> {checkout:MMM dd, yyyy}<br><br>
                We look forward to your stay! ✨<br><br>
                – Cloud9 Suites Team
            ";

            var mail = new MailMessage(senderEmail, toEmail, "Booking Confirmation", body);
            mail.IsBodyHtml = true;

            using var smtp = new SmtpClient(smtpServer, port)
            {
                Credentials = new NetworkCredential(senderEmail, password),
                EnableSsl = true
            };

            await smtp.SendMailAsync(mail);
        }
    }
}
