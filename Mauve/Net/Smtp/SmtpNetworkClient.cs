using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Net.Smtp
{
    public class SmtpNetworkClient : INetworkClient, IDisposable
    {

        /*
         SmtpClient mySmtpClient = new SmtpClient("my.smtp.exampleserver.net");

    
         */

        #region Fields

        private SmtpClient _client;

        #endregion

        #region Properties

        public NetworkConnectionInformation ConnectionInformation { get; internal set; }

        #endregion

        #region Constructor

        public SmtpNetworkClient() { }
        public SmtpNetworkClient(SmtpClient client) => _client = client;

        #endregion

        #region Public Methods

        public void Dispose() => throw new NotImplementedException();
        public INetworkResponse Execute(INetworkRequest request) => throw new NotImplementedException();

        #endregion

    }
}
