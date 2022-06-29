using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.Emails
{
    public class MessageDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}
