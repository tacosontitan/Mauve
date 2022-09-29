using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Mauve.Patterns;

namespace Mauve.Net.Smtp
{
    public class SmtpNetworkClientBuilder : IBuilder<SmtpNetworkClient>
    {

        #region Fields

        private bool _useDefaultCredentials;
        private int _port;
        private string _host;
        private string _domain;
        private string _username;
        private string _password;

        #endregion

        #region Constructor

        public SmtpNetworkClientBuilder(string host) => _host = host;

        #endregion

        #region Public Methods

        public SmtpNetworkClient Build()
        {
            // Create the network information object.
            var networkConnectionInfo = new NetworkConnectionInformation
            {
                Host = _host,
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
                ? new NetworkCredential(_username, _password, _domain)
                : new NetworkCredential(_username, _password);

            // Assign the credential to the network information.
            networkConnectionInfo.Credential = networkCredential;

            // Create the network client.
            return new SmtpNetworkClient(networkConnectionInfo);
        }
        public SmtpNetworkClientBuilder UsePort(int port)
        {
            _port = port;
            return this;
        }
        public SmtpNetworkClientBuilder UseCredentials(string username, string password)
        {
            _username = username;
            _password = password;
            return this;
        }
        public SmtpNetworkClientBuilder UseDefaultCredentials()
        {
            _useDefaultCredentials = true;
            return this;
        }
        public SmtpNetworkClientBuilder UseDomain(string domain)
        {
            _domain = domain;
            return this;
        }

        #endregion

    }
}
