using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method.
    /// </summary>
    public interface IExecutable
    {
        void Execute();
        Task ExecuteAsync();
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
