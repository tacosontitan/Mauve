namespace Mauve.Security
{
    /// <summary>
    /// Represents a <see cref="class"/> for storing signed data.
    /// </summary>
    /// <typeparam name="TData">The type fo the signed data.</typeparam>
    /// <typeparam name="TSignatureAuthority">The type of authority used to sign the data.</typeparam>
    public class Signed<TData, TSignatureAuthority>
    {

        #region Properties

        /// <summary>
        /// The signed data.
        /// </summary>
        public TData Data { get; set; }
        /// <summary>
        /// The signature for the data.
        /// </summary>
        public Signature<TSignatureAuthority> Signature { get; set; }

        #endregion

    }
}
