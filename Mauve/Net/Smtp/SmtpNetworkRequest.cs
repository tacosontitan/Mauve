using System.Net.Mail;

namespace Mauve.Net.Smtp
{
    /// <summary>
    /// Represents an <see cref="INetworkRequest{T}"/> instance for sending <see cref="MailMessage"/> instances using <see cref="INetworkClient{TRequest, TIn, TOut}"/> implementations.
    /// </summary>
    /// <inheritdoc/>
    public class SmtpNetworkRequest : INetworkRequest<MailMessage>
    {

        #region Properties

        public MailMessage Data { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="SmtpNetworkRequest"/> using the specified <see cref="MailMessage"/>.
        /// </summary>
        /// <param name="message">The message this request is focused on sending.</param>
        public SmtpNetworkRequest(MailMessage message) => Data = message;

        #endregion

    }
}
