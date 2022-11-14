using System;

using Mauve.Patterns;

namespace Mauve.Net.Smtp
{
    /// <summary>
    /// Represents an implementation of <see cref="IBuilder{T}"/> that is capable of building <see cref="SmtpNetworkClient"/> instances.
    /// </summary>
    /// <inheritdoc/>
    public class SmtpNetworkClientBuilder : IBuilder<SmtpNetworkClient>
    {

        #region Fields

        private bool _useSsl;
        private bool _useDefaultCredentials;
        private int _port;
        private readonly Uri _uri;
        private string _domain;
        private string _username;
        private string _password;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="SmtpNetworkClientBuilder"/> using the specified host.
        /// </summary>
        /// <param name="host">The host the <see cref="SmtpNetworkClient"/> should use.</param>
        public SmtpNetworkClientBuilder(string uri) :
            this(new Uri(uri))
        { }
        public SmtpNetworkClientBuilder(Uri uri) =>
            _uri = uri;

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds a new instance of <see cref="SmtpNetworkClient"/>.
        /// </summary>
        /// <returns>Returns a new instance of <see cref="SmtpNetworkClient"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown if both default and custom credentials are specified.</exception>
        public SmtpNetworkClient Build()
        {
            // Create the network information object.
            var networkConnectionInfo = new NetworkConnectionInformation
            {
                Uri = _uri,
                Port = _port,
                UseDefaultCredentials = _useDefaultCredentials
            };

            // Determine if specific credentials have been provided.
            bool credentialsSpecified =
                !string.IsNullOrWhiteSpace(_domain) ||
                !string.IsNullOrWhiteSpace(_username) ||
                !string.IsNullOrWhiteSpace(_password);

            // If we're supposed to use default credentials and credentials have been specified, inform the consumer.
            if (_useDefaultCredentials && credentialsSpecified)
                throw new InvalidOperationException("Unable to use default credentials when credentials are specified.");

            // Create the network credentials for the network information object.
            NetworkCredential networkCredential = !string.IsNullOrWhiteSpace(_domain)
                ? new BasicNetworkCredential(_username, _password, _domain)
                : new BasicNetworkCredential(_username, _password);

            // Assign the credential to the network information.
            networkConnectionInfo.Credential = networkCredential;

            // Create the network client.
            return new SmtpNetworkClient(networkConnectionInfo, _useSsl);
        }
        /// <summary>
        /// Specifies the port that should be utilized by the <see cref="SmtpNetworkClient"/>.
        /// </summary>
        /// <param name="port">The port that should be utilized by the <see cref="SmtpNetworkClient"/>.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkClientBuilder"/> instance.</returns>
        public SmtpNetworkClientBuilder UsePort(int port)
        {
            _port = port;
            return this;
        }
        /// <summary>
        /// Specifies the custom credentials that should be utilized by the <see cref="SmtpNetworkClient"/>.
        /// </summary>
        /// <param name="username">The username that should be utilized.</param>
        /// <param name="password">The password that should be utilized.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkClientBuilder"/> instance.</returns>
        public SmtpNetworkClientBuilder UseCredentials(string username, string password)
        {
            _username = username;
            _password = password;
            return this;
        }
        /// <summary>
        /// Specifies that the <see cref="SmtpNetworkClient"/> should use default credentials.
        /// </summary>
        /// <returns>Returns the current <see cref="SmtpNetworkClientBuilder"/> instance.</returns>
        public SmtpNetworkClientBuilder UseDefaultCredentials()
        {
            _useDefaultCredentials = true;
            return this;
        }
        /// <summary>
        /// Specifies the domain that should be utilized by the <see cref="SmtpNetworkClient"/>.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns>Returns the current <see cref="SmtpNetworkClientBuilder"/> instance.</returns>
        public SmtpNetworkClientBuilder UseDomain(string domain)
        {
            _domain = domain;
            return this;
        }
        /// <summary>
        /// Specifies that the <see cref="SmtpNetworkClient"/> should use SSL.
        /// </summary>
        /// <returns>Returns the current <see cref="SmtpNetworkClientBuilder"/> instance.</returns>
        public SmtpNetworkClientBuilder UseSsl()
        {
            _useSsl = true;
            return this;
        }

        #endregion

    }
}
