namespace Mauve.Net
{
    /// <summary>
    /// An <see langword="enum"/> representing different types of network tokens.
    /// </summary>
    public enum NetworkTokenType
    {
        /// <summary>
        /// Represents an unspecified or unsupported <see cref="NetworkTokenType"/>.
        /// </summary>
        None = 0,
        /// <summary>
        /// Represents a standard bearer token.
        /// </summary>
        Bearer = 1,
        /// <summary>
        /// 
        /// </summary>
        OAuth = 2
    }
}
