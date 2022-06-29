using Himbo.Api.Core.Jwt;

namespace Himbo.Api.Core.Common
{
    public class AppSettings
    {
        public string ConnString { get; set; }
        public JwtSettings JwtSettings { get; set; }

        public EmailOptions EmailOptions { get; set; }
    }

    public class EmailOptions
    {
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}
