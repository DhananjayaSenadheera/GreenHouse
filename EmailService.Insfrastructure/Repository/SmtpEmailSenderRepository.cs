using System.Net;
using System.Net.Mail;
using EmailService.Domain.Domain;
using EmailService.Domain.Interfaces;

namespace EmailService.Insfrastructure.Repository;

public class SmtpEmailSenderRepository : IEmailRepository
{
    private readonly string _host = "smtp.gmail.com";
    private readonly int _port = 587;
    private readonly string _username = "guest";
    private readonly string _password ;

    public SmtpEmailSenderRepository(string host, string username, string password, int port)
    {
        _host = host;
        _username = username;
        _password = password;
        _port = port;
    }
    public async Task<bool> SendEmailAsync(Email email)
    {
        try
        {
            var smtpClient = new SmtpClient(_host)
            {
                Port = _port,
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_username),
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(email.To);

            await smtpClient.SendMailAsync(mailMessage);
            return true;
        }
        catch
        {
            return false;
        }
    }
}