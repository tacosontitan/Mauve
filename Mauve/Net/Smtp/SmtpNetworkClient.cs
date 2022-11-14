using System;
using System.Net.Mail;

using Mauve.Extensibility;

namespace Mauve.Net.Smtp
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

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="SmtpNetworkClient"/> instance with the specified connection information.
        /// </summary>
        /// <param name="connectionInformation">The <see cref="NetworkConnectionInformation"/> this <see cref="SmtpNetworkClient"/> uses to send messages.</param>
        /// <param name="enableSsl">Whether or not SSL is enabled.</param>
        public SmtpNetworkClient(NetworkConnectionInformation connectionInformation, bool enableSsl) :
            base(connectionInformation)
        {
            // Verify that the connection information is a basic network credential.
            if (connectionInformation.Credential is BasicNetworkCredential basicNetworkCredential)
            {
                // Create a new raw client.
                _client = new SmtpClient(ConnectionInformation.Uri.ToString())
                {
                    EnableSsl = enableSsl,
                    UseDefaultCredentials = ConnectionInformation.UseDefaultCredentials,
                    Credentials = new System.Net.NetworkCredential
                    {
                        UserName = basicNetworkCredential.Username,
                        Password = basicNetworkCredential.Password
                    }
                };

                // Set the port information if it's available.
                if (ConnectionInformation.Port != null)
                    _client.Port = ConnectionInformation.Port.Value;
            } else
                throw new ArgumentException("The credentials for SMTP interactions require basic network credentials.");
        }

        #endregion

        #region Public Methods

        public void Dispose() => _client?.Dispose();

        #endregion

        #region Protected Methods

        protected override TOut ExecuteRequest<TOut>(SmtpNetworkRequest request)
        {
            _client.Send(request.Data);
            return request.Data.Translate<MailMessage, TOut>();
        }

        #endregion

    }
}
