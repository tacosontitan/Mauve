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

        #region Fields

        private SmtpClient _client;

        #endregion

        #region Properties

        public NetworkConnectionInformation ConnectionInformation { get; internal set; }

        #endregion

        #region Constructor

        public SmtpNetworkClient(NetworkConnectionInformation connectionInformation)
        {
            // Set properties.
            ConnectionInformation = connectionInformation;

            // Create a new raw client.
            _client = new SmtpClient(ConnectionInformation.Host)
            {
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
        public INetworkResponse Execute(INetworkRequest request)
        {
            return null;
        }

        #endregion

    }
}
