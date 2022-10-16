using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

using Mauve.Extensibility;
using Mauve.Patterns;
using Mauve.Serialization;

namespace Mauve.Net.Smtp
{
    /// <summary>
    /// Represents an implementation of <see cref="IBuilder{T}"/> that is capable of building <see cref="SmtpNetworkRequest"/> instances.
    /// </summary>
    /// <inheritdoc/>
    public class SmtpNetworkRequestBuilder : IBuilder<SmtpNetworkRequest>, IDisposable
    {

        #region Fields

        private string _subject;
        private readonly StringBuilder _bodyBuilder;
        private readonly Encoding _encoding;
        private readonly MailAddress _fromAddress;
        private readonly List<MailAddress> _toAddresses;
        private readonly List<MailAddress> _replyToAddresses;
        private readonly List<MailAddress> _carbonCopyAddresses;
        private readonly List<MailAddress> _blindCarbonCopyAddresses;
        private readonly List<Attachment> _attachments;
        private readonly List<MemoryStream> _attachmentMemoryStreams;
        private readonly List<StreamWriter> _attachmentStreamWriters;
        private readonly Dictionary<string, string> _headers;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="SmtpNetworkRequestBuilder"/>.
        /// </summary>
        private SmtpNetworkRequestBuilder()
        {
            _bodyBuilder = new StringBuilder();
            _encoding = Encoding.UTF8;
            _toAddresses = new List<MailAddress>();
            _replyToAddresses = new List<MailAddress>();
            _carbonCopyAddresses = new List<MailAddress>();
            _blindCarbonCopyAddresses = new List<MailAddress>();
            _attachments = new List<Attachment>();
            _attachmentMemoryStreams = new List<MemoryStream>();
            _attachmentStreamWriters = new List<StreamWriter>();
            _headers = new Dictionary<string, string>();
        }
        /// <summary>
        /// Creates a new instance of <see cref="SmtpNetworkRequestBuilder"/>.
        /// </summary>
        /// <param name="from">The sender of the generated request.</param>
        public SmtpNetworkRequestBuilder(string from) : this() =>
            _fromAddress = new MailAddress(from);
        /// <summary>
        /// Creates a new instance of <see cref="SmtpNetworkRequestBuilder"/>.
        /// </summary>
        /// <param name="from">The sender of the generated request.</param>
        /// <param name="to">The primary recipient of the generated request.</param>
        public SmtpNetworkRequestBuilder(string from, string to) : this(from) =>
            _toAddresses.Add(new MailAddress(to));

        #endregion

        #region Public Methods

        /// <summary>
        /// Attaches a file to the request.
        /// </summary>
        /// <param name="file">The file to attach.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder Attach(string file)
        {
            _attachments.Add(new Attachment(file));
            return this;
        }
        /// <summary>
        /// Attaches raw data to the request.
        /// </summary>
        /// <typeparam name="T">The type of data to attach.</typeparam>
        /// <param name="name">The name of the generated file.</param>
        /// <param name="data">The data to attach.</param>
        /// <remarks>This method uses <see cref="SerializationMethod.Json"/> to serialize the incoming data prior to attachment.</remarks>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder Attach<T>(string name, T data) => Attach(name, data, SerializationMethod.Json);
        /// <summary>
        /// Attaches raw data to the request.
        /// </summary>
        /// <typeparam name="T">The type of data to attach.</typeparam>
        /// <param name="name">The name of the generated file.</param>
        /// <param name="data">The data to attach.</param>
        /// <param name="serializationMethod">The serialization method that should be utilized to serialize the incoming data prior to attachment.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder Attach<T>(string name, T data, SerializationMethod serializationMethod)
        {
            string serializedData = data.Serialize(serializationMethod);
            byte[] buffer = _encoding.GetBytes(serializedData);
            var memoryStream = new MemoryStream(buffer);
            var streamWriter = new StreamWriter(memoryStream);
            streamWriter.Write(serializedData);

            string extension = serializationMethod.ToString().ToLowerInvariant();
            _attachments.Add(new Attachment(memoryStream, $"{name}.{extension}"));
            _attachmentMemoryStreams.Add(memoryStream);
            return this;
        }
        /// <summary>
        /// Adds a blind carbon copy recipient to the request.
        /// </summary>
        /// <param name="address">The address of the recipient.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder BlindCarbonCopy(string address)
        {
            _blindCarbonCopyAddresses.Add(new MailAddress(address));
            return this;
        }
        /// <summary>
        /// Builds a new <see cref="SmtpNetworkRequest"/> instance.
        /// </summary>
        /// <returns>Returns a new <see cref="SmtpNetworkRequest"/> instance.</returns>
        public SmtpNetworkRequest Build()
        {
            // Create the MailMessage object to be sent.
            var message = new MailMessage
            {
                From = _fromAddress,
                Subject = _subject,
                SubjectEncoding = _encoding,
                Body = _bodyBuilder.ToString(),
                BodyEncoding = _encoding,
                HeadersEncoding = _encoding
            };

            // Add the "to" addresses.
            foreach (MailAddress address in _toAddresses)
                message.To.Add(address);

            // Add the "reply-to" addresses.
            foreach (MailAddress address in _replyToAddresses)
                message.To.Add(address);

            // Add the "carbon-copy" addresses.
            foreach (MailAddress address in _carbonCopyAddresses)
                message.CC.Add(address);

            // Add the "blind-carbon-copy" addresses.
            foreach (MailAddress address in _blindCarbonCopyAddresses)
                message.Bcc.Add(address);

            // Add any attachements.
            foreach (Attachment attachment in _attachments)
                message.Attachments.Add(attachment);

            // Create a new network request.
            return new SmtpNetworkRequest(message);
        }
        /// <summary>
        /// Adds a blind carbon copy recipient to the request.
        /// </summary>
        /// <param name="address">The address of the recipient.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder CarbonCopy(string address)
        {
            _carbonCopyAddresses.Add(new MailAddress(address));
            return this;
        }
        /// <summary>
        /// Adds a subject to the request.
        /// </summary>
        /// <param name="subject">The subject of the request.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder CreateSubject(string subject)
        {
            _subject = subject;
            return this;
        }
        /// <summary>
        /// Disposes of the <see cref="MemoryStream"/> and <see cref="StreamWriter"/> instances used to attach raw data to the request.
        /// </summary>
        public void Dispose()
        {
            _attachmentMemoryStreams.ForEach(memoryStream => memoryStream.Dispose());
            _attachmentStreamWriters.ForEach(streamWriter => streamWriter.Dispose());
        }
        /// <summary>
        /// Adds a reply-to recipient to the request.
        /// </summary>
        /// <param name="address">The address of the recipient.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder ReplyTo(string address)
        {
            _replyToAddresses.Add(new MailAddress(address));
            return this;
        }
        /// <summary>
        /// Adds a recipient to the request.
        /// </summary>
        /// <param name="address">The address of the recipient.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder SendTo(string address)
        {
            _toAddresses.Add(new MailAddress(address));
            return this;
        }
        /// <summary>
        /// Adds a header to the request.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value for the header.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder UsingHeader(string name, string value)
        {
            _headers.Add(name, value);
            return this;
        }
        /// <summary>
        /// Writes a specified value to the body of the request.
        /// </summary>
        /// <param name="value">The value to write to the request.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder Write(string value)
        {
            _ = _bodyBuilder.Append(value);
            return this;
        }
        /// <summary>
        /// Writes a specified value to the body of the request as a line.
        /// </summary>
        /// <param name="value">The value to write to the request.</param>
        /// <returns>Returns the current <see cref="SmtpNetworkRequestBuilder"/> instance.</returns>
        public SmtpNetworkRequestBuilder WriteLine(string value)
        {
            _ = _bodyBuilder.AppendLine(value);
            return this;
        }

        #endregion

    }
}
