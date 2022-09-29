using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Mauve.Extensibility;
using Mauve.Patterns;
using Mauve.Serialization;

namespace Mauve.Net.Smtp
{
    public class SmtpNetworkRequestBuilder : IBuilder<SmtpNetworkRequest>
    {

        #region Fields

        private string _subject;
        private StringBuilder _bodyBuilder;
        private readonly Encoding _encoding;
        private readonly MailAddress _fromAddress;
        private readonly List<MailAddress> _toAddresses;
        private readonly List<MailAddress> _replyToAddresses;
        private readonly List<MailAddress> _carbonCopyAddresses;
        private readonly List<MailAddress> _blindCarbonCopyAddresses;
        private readonly List<Attachment> _attachments;
        private readonly Dictionary<string, string> _headers;

        #endregion

        #region Constructor

        private SmtpNetworkRequestBuilder()
        {
            _bodyBuilder = new StringBuilder();
            _encoding = Encoding.UTF8;
            _toAddresses = new List<MailAddress>();
            _carbonCopyAddresses = new List<MailAddress>();
            _blindCarbonCopyAddresses = new List<MailAddress>();
            _attachments = new List<Attachment>();
            _headers = new Dictionary<string, string>();
        }
        public SmtpNetworkRequestBuilder(string from) : this() =>
            _fromAddress = new MailAddress(from);
        public SmtpNetworkRequestBuilder(string from, string to) : this(from) =>
            _toAddresses.Add(new MailAddress(to));

        #endregion

        #region Public Methods

        public SmtpNetworkRequest Build()
        {
            // Create the MailMessage object to be sent.
            var message = new MailMessage
            {
                From = _fromAddress,
                Subject = _subject,
                SubjectEncoding = _encoding,
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
        public SmtpNetworkRequestBuilder Attach(string file)
        {
            _attachments.Add(new Attachment(file));
            return this;
        }
        public SmtpNetworkRequestBuilder Attach<T>(string name, T data) => Attach(name, data, SerializationMethod.Json);
        public SmtpNetworkRequestBuilder Attach<T>(string name, T data, SerializationMethod serializationMethod)
        {
            string serializedData = data.Serialize(serializationMethod);
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                    streamWriter.Write(serializedData);

                string extension = serializationMethod.ToString().ToLowerInvariant();
                _attachments.Add(new Attachment(memoryStream, $"{name}.{extension}"));
            }
            return this;
        }
        public SmtpNetworkRequestBuilder BlindCarbonCopy(string address)
        {
            _toAddresses.Add(new MailAddress(address));
            return this;
        }
        public SmtpNetworkRequestBuilder CarbonCopy(string address)
        {
            _toAddresses.Add(new MailAddress(address));
            return this;
        }
        public SmtpNetworkRequestBuilder CreateSubject(string subject)
        {
            _subject = subject;
            return this;
        }
        public SmtpNetworkRequestBuilder SendTo(string address)
        {
            _toAddresses.Add(new MailAddress(address));
            return this;
        }
        public SmtpNetworkRequestBuilder UsingHeader(string name, string value)
        {
            _headers.Add(name, value);
            return this;
        }
        public SmtpNetworkRequestBuilder Write(string value)
        {
            _ = _bodyBuilder.Append(value);
            return this;
        }
        public SmtpNetworkRequestBuilder WriteLine(string value)
        {
            _ = _bodyBuilder.AppendLine(value);
            return this;
        }

        #endregion

    }
}
