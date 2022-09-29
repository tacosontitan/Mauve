using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Net.Smtp
{
    public class SmtpNetworkRequest : INetworkRequest<MailMessage>
    {
        public MailMessage Data { get; set; }
    }
}
