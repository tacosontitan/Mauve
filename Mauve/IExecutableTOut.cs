using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    public interface IExecutable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Execute();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<T> ExecuteAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> ExecuteAsync(CancellationToken cancellationToken);
    }
}
