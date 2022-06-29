using Himbo.Application.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Emails
{
    public class SmtpEmailSender : IEmailSender
    {
        private string _fromEmail;
        private string _password;
        private int _port;
        private string _host;
        public SmtpEmailSender(string fromEmail, string password, int port, string host)
        {
            _fromEmail = fromEmail;
            _password = password;
            _port = port;
            _host = host;
        }

        public void Send(MessageDto dto)
        {
            #region Create SmtpClient
            var smtp = new SmtpClient
            {
                Host = _host,
                Port = _port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(_fromEmail, _password),
            };
            #endregion

            #region Create Message
            var message = new MailMessage(_fromEmail, dto.To)
            {
                Subject = dto.Title,
                Body = dto.Body,
                IsBodyHtml = true
            };
            #endregion

            #region Send Message
            smtp.Send(message); 
            #endregion
        }
    }
}
