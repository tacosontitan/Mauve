namespace Mauve.Security
{
    /// <summary>
    /// Represents an <see cref="enum"/> containing values representing different hashing algorithms shipped with .NET.
    /// </summary>
    public enum HashType
    {
        /// <summary>
        /// Represents an unspecified or unsupported <see cref="HashType"/>.
        /// </summary>
        None = 0,
        /// <summary>
        /// The MD5 message-digest algorithm is a hash function producing a 128-bit hash value.
        /// </summary>
        /// <remarks>The security of the MD5 hash function is severely compromised. <see href="https://en.wikipedia.org/wiki/MD5">Learn more.</see></remarks>
        Md5 = 1,
        /// <summary>
        /// The 256-bit variant of Secure Hash Algorithm 2.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/SHA-2">Learn more.</see></remarks>
        Sha256 = 2,
        /// <summary>
        /// The 384-bit variant of Secure Hash Algorithm 2.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/SHA-2">Learn more.</see></remarks>
        Sha384 = 3,
        /// <summary>
        /// The 512-bit variant of Secure Hash Algorithm 2.
        /// </summary
        /// <remarks><see href="https://en.wikipedia.org/wiki/SHA-2">Learn more.</see></remarks>
        Sha512 = 4,
        /// <summary>
        /// A family of cryptographic hash functions developed in 1992 (the original RIPEMD) and 1996 (other variants).
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/RIPEMD">Learn more.</see></remarks>
        RipeMd = 6
    }
}
