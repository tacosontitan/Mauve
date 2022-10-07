using System;
using System.Collections.Generic;

namespace Mauve.Security
{
    /// <summary>
    /// Represents a <see cref="Signature{T}"/>
    /// </summary>
    /// <typeparam name="T">The type of data acting as the signing authority for the signature.</typeparam>
    public abstract class Signature<T> : IEquatable<Signature<T>>
    {

        #region Properties

        /// <summary>
        /// The <see cref="T"/> representing the signing authority in this <see cref="Signature{T}"/>.
        /// </summary>
        public T Authority { get; set; }
        /// <summary>
        /// The timestamp this signature was made.
        /// </summary>
        public DateTime? Timestamp { get; set; }
        /// <summary>
        /// Any additional information related to the signature.
        /// </summary>
        public Dictionary<string, object> AdditionalInformation { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="Signature{T}"/> instance.
        /// </summary>
        public Signature() => AdditionalInformation = new Dictionary<string, object>();
        /// <summary>
        /// Creates a new <see cref="Signature{T}"/> instance using the specified authority.
        /// </summary>
        /// <param name="authority">The <see cref="T"/> representing the signing authority in this <see cref="Signature{T}"/>.</param>
        public Signature(T authority) : this() => Authority = authority;
        /// <summary>
        /// Creates a new <see cref="Signature{T}"/> using the specified authority and timestamp.
        /// </summary>
        /// <param name="authority">The <see cref="T"/> representing the signing authority in this <see cref="Signature{T}"/>.</param>
        /// <param name="timestamp">The timestamp this signature was made.</param>
        public Signature(T authority, DateTime timestamp) : this()
        {
            Authority = authority;
            Timestamp = timestamp;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Determines if the current <see cref="Signature{T}"/> instance is equal to another.
        /// </summary>
        /// <param name="other">The <see cref="Signature{T}"/> instance to compare the current instance to.</param>
        /// <returns>Returns <see langword="true"/> if the current instance is equal to the specified <see cref="Signature{T}"/>, otherwise <see langword="false"/>.</returns>
        public bool Equals(Signature<T> other) =>
            Authority.Equals(other.Authority) &&
            Timestamp.Equals(other.Timestamp) &&
            AdditionalInformation.Equals(other.AdditionalInformation);

        #endregion

    }
}
