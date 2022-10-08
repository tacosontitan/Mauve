
using Mauve.Patterns;

namespace Mauve.Security
{
    /// <summary>
    /// Represents an <see cref="interface"/> that exposes methods for building a token.
    /// </summary>
    public interface ITokenBuilder : IBuilder<byte[]>
    {
        /// <summary>
        /// Signs the token.
        /// </summary>
        void Sign();
    }
}
