using System;
using System.Text;
using System.Xml.Serialization;

using Mauve.Extensibility;

using Newtonsoft.Json;

using YamlDotNet.Serialization;

namespace Mauve.Net
{
    /// <summary>
    /// Represents a <see cref="NetworkCredential"/> of type <see cref="NetworkCredentialType.Basic"/> which is comprised of a username and password.
    /// </summary>
    public class BasicNetworkCredential : NetworkCredential
    {

        #region Properties

        /// <summary>
        /// The domain of the credential.
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// The username of the credential.
        /// </summary>
        [XmlIgnore] [JsonIgnore] [YamlIgnore]
        public string Username
        {
            get
            {
                byte[] bytes = Convert.FromBase64String(Value);
                string decodedValue = Encoding.UTF8.GetString(bytes);
                return decodedValue.TakeTo(":");
            }
        }
        /// <summary>
        /// The password of the credential.
        /// </summary>
        [XmlIgnore] [JsonIgnore] [YamlIgnore]
        public string Password
        {
            get
            {
                byte[] bytes = Convert.FromBase64String(Value);
                string decodedValue = Encoding.UTF8.GetString(bytes);
                return decodedValue.TakeTo(":");
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="BasicNetworkCredential"/> instance.
        /// </summary>
        public BasicNetworkCredential() :
            base() =>
                Type = NetworkCredentialType.Basic;
        /// <summary>
        /// Creates a new <see cref="BasicNetworkCredential"/> instance using the specified value.
        /// </summary>
        /// <param name="value">The value of the <see cref="NetworkCredential"/>.</param>
        public BasicNetworkCredential(string value) :
            this() =>
                Value = value;
        /// <summary>
        /// Creates a new <see cref="BasicNetworkCredential"/> instance using the specified username and password.
        /// </summary>
        /// <param name="username">The username of the credential.</param>
        /// <param name="password">The password of the credential.</param>
        public BasicNetworkCredential(string username, string password) :
            this()
        {
            string value = $"{username}:{password}";
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            Value = Convert.ToBase64String(valueBytes);
        }
        /// <summary>
        /// Creates a new <see cref="BasicNetworkCredential"/> instance using the specified username and password.
        /// </summary>
        /// <param name="username">The username of the credential.</param>
        /// <param name="password">The password of the credential.</param>
        /// <param name="domain">The domain of the credential.</param>
        public BasicNetworkCredential(string username, string password, string domain) :
            this(username, password) =>
                Domain = domain;

        #endregion

    }
}
