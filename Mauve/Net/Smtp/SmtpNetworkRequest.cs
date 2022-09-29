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

        #region Properties

        public MailMessage Data { get; set; }

        #endregion

        #region Constructor

        public SmtpNetworkRequest(MailMessage message) => Data = message;

        #endregion

    }
}
