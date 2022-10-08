using System.Collections.Generic;

using Mauve.Net.Smtp;

namespace Mauve.Runtime
{
    /// <summary>
    /// Represents an <see cref="EventMessageLogger"/> for writing <see cref="EventMessage"/> data using a <see cref="SmtpNetworkClient"/>.
    /// </summary>
    /// <inheritdoc/>
    public class EventMessageSmtpLogger : EventMessageLogger
    {

        #region Fields

        private readonly string _sender;
        private readonly IEnumerable<string> _recipients;
        private readonly SmtpNetworkClientBuilder _clientBuilder;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="EventMessageSmtpLogger"/> instance using the specified <see cref="SmtpNetworkClientBuilder"/>, sender, and recipients.
        /// </summary>
        /// <param name="clientBuilder">The <see cref="SmtpNetworkClientBuilder"/> capable of building <see cref="SmtpNetworkClient"/> instances.</param>
        /// <param name="senderAddress">The sender of the emails.</param>
        /// <param name="recipientAddresses">The recipients of the emails.</param>
        public EventMessageSmtpLogger(SmtpNetworkClientBuilder clientBuilder, string senderAddress, params string[] recipientAddresses)
        {
            _sender = senderAddress;
            _recipients = recipientAddresses;
            _clientBuilder = clientBuilder;
        }

        #endregion

        #region Protected Methods

        protected override void WriteMessage(EventMessage message)
        {
            using (SmtpNetworkClient client = _clientBuilder.Build())
            {
                using (var requestBuilder = new SmtpNetworkRequestBuilder(_sender))
                {
                    // Create the subject and body.
                    _ = requestBuilder.CreateSubject(message.Type.ToString())
                                      .WriteLine(message.Value);

                    // Append all recipients.
                    foreach (string recipientAddress in _recipients)
                        _ = requestBuilder.SendTo(recipientAddress);

                    // Send the email.
                    SmtpNetworkRequest request = requestBuilder.Build();
                    _ = client.Execute(request);
                }
            }
        }

        #endregion

    }
}
