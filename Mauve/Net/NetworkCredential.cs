namespace Mauve.Net
{
    /// <summary>
    /// Represents a simplified definition of a network credential.
    /// </summary>
    public class NetworkCredential
    {
        /// <summary>
        /// The type of this credential.
        /// </summary>
        public NetworkCredentialType Type { get; set; }
        /// <summary>
        /// The value of this credential.
        /// </summary>
        public string Value { get; set; }
    }
}
