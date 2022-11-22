namespace Mauve.Net
{
    /// <summary>
    /// Represents a collection of different network request method types.
    /// </summary>
    public enum NetworkRequestMethod
    {
        /// <summary>
        /// Represents an unspecified or unsupported <see cref="NetworkRequestMethod"/>.
        /// </summary>
        None = 0,
        /// <summary>
        /// Represents a network request that receives data from the client.
        /// </summary>
        Get = 1,
        /// <summary>
        /// Represents a network request that sends data to the client.
        /// </summary>
        Post = 2,
        /// <summary>
        /// Represents a network request that completely mutates data with the client.
        /// </summary>
        Put = 3,
        /// <summary>
        /// Represents a network request that deletes data with the client.
        /// </summary>
        Delete = 4,
        /// <summary>
        /// Represents a network request that partially mutates data with the client.
        /// </summary>
        Patch = 5
    }
}
