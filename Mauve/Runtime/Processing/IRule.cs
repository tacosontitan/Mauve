using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Runtime.Processing
{
    /// <summary>
    /// Represents an <see langword="interface"/> for applying a rule.
    /// </summary>
    internal interface IRule
    {
        /// <summary>
        /// Applies the rule.
        /// </summary>
        void Apply();
        /// <summary>
        /// Applies the rule asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> that describes the state of the application.</returns>
        Task ApplyAsync();
        /// <summary>
        /// Applies the rule asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> through which the application can be cancelled.</param>
        /// <returns>A <see cref="Task"/> that describes the state of the application.</returns>
        Task ApplyAsync(CancellationToken cancellationToken);
    }
}
