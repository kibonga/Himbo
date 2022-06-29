using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.Emails
{
    public interface IEmailSender
    {
        void Send(MessageDto dto);
    }
}
