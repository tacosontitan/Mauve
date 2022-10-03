using System.Threading.Tasks;

namespace Mauve.Runtime
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes generics enabled methods for logging.
    /// </summary>
    public interface ILogger<T>
    {
        void Log(T input);
        Task LogAsync(T input);
    }
}
