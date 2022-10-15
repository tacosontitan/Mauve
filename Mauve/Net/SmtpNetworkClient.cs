using System;
using System.Net.Mail;

namespace Mauve.Net
{
    /// <summary>
    /// Represents a <see cref="SmtpNetworkClient"/> for executing <see cref="SmtpNetworkRequest"/> instances.
    /// </summary>
    /// <inheritdoc/>
    public class SmtpNetworkClient : NetworkClient<SmtpNetworkRequest, MailMessage>, IDisposable
    {

        #region Fields

        private readonly SmtpClient _client;

        #endregion

        #region Properties

        /// <summary>
        /// The <see cref="NetworkConnectionInformation"/> this <see cref="SmtpNetworkClient"/> uses to send messages.
        /// </summary>
        public NetworkConnectionInformation ConnectionInformation { get; internal set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="SmtpNetworkClient"/> instance with the specified connection information.
        /// </summary>
        /// <param name="connectionInformation">The <see cref="NetworkConnectionInformation"/> this <see cref="SmtpNetworkClient"/> uses to send messages.</param>
        /// <param name="enableSsl">Whether or not SSL is enabled.</param>
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
