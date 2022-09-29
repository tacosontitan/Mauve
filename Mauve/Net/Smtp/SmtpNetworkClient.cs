using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Net.Smtp
{
    public class SmtpNetworkClient : NetworkClient<SmtpNetworkRequest, MailMessage>, IDisposable
    {

        #region Fields

        private readonly SmtpClient _client;

        #endregion

        #region Properties

        public NetworkConnectionInformation ConnectionInformation { get; internal set; }

        #endregion

        #region Constructor

        public SmtpNetworkClient(NetworkConnectionInformation connectionInformation, bool enableSsl)
        {
            // Set properties.
            ConnectionInformation = connectionInformation;

            // Create a new raw client.
            _client = new SmtpClient(ConnectionInformation.Host)
            {
                EnableSsl = enableSsl,
                UseDefaultCredentials = ConnectionInformation.UseDefaultCredentials,
                Credentials = ConnectionInformation.Credential
            };

            // Set the port information if it's available.
            if (ConnectionInformation.Port != null)
                _client.Port = ConnectionInformation.Port.Value;
        }

        #endregion

        #region Public Methods

        public void Dispose() => _client?.Dispose();

        #endregion

        #region Protected Methods

        protected override MailMessage ExecuteRequest(SmtpNetworkRequest request)
        {
            _client.Send(request.Data);
            return request.Data;
        }

        #endregion

    }
}
