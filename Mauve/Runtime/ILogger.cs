using System.Threading.Tasks;

namespace Mauve.Runtime
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes generics enabled methods for logging.
    /// </summary>
    public interface ILogger<T>
    {
        /// <summary>
        /// Logs the specified input.
        /// </summary>
        /// <param name="input">The input to log.</param>
        void Log(T input);
        /// <summary>
        /// Logs the specified input.
        /// </summary>
        /// <param name="input">The input to log.</param>
        Task LogAsync(T input);
    }
}
