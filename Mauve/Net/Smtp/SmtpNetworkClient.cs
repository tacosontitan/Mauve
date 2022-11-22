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

        private readonly bool _enableSsl;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="SmtpNetworkClient"/> instance.
        /// </summary>
        /// <param name="enableSsl">Whether or not SSL is enabled.</param>
        public SmtpNetworkClient(bool enableSsl) :
            base(new SmtpNetworkConnectionBuilder()) => _enableSsl = enableSsl;

        #endregion

        #region Public Methods

        public void Dispose() { }

        #endregion

        #region Protected Methods

        protected override TOut ExecuteRequest<TOut>(INetworkConnection connection, SmtpNetworkRequest request)
        {
            // Verify that the connection information is a basic network credential.
            if (connection.ConnectionInformation.Credential is BasicNetworkCredential basicNetworkCredential)
            {
                // Create a new raw client.
                var client = new SmtpClient(connection.ConnectionInformation.Uri.ToString())
                {
                    EnableSsl = _enableSsl,
                    UseDefaultCredentials = connection.ConnectionInformation.UseDefaultCredentials,
                    Credentials = new System.Net.NetworkCredential
                    {
                        UserName = basicNetworkCredential.Username,
                        Password = basicNetworkCredential.Password
                    }
                };

                // Set the port information if it's available.
                if (connection.ConnectionInformation.Port != null)
                    client.Port = connection.ConnectionInformation.Port.Value;

                try
                {
                    client.Send(request.Data);
                    return request.Data.Translate<MailMessage, TOut>();
                } finally
                {
                    client.Dispose();
                }
            } else
                return default;
        }

        #endregion

    }
}
