using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Runtime.Processing
{
    /// <summary>
    /// Represents an <see langword="interface"/> for applying a rule.
    /// </summary>
    internal interface IRule<T>
    {
        /// <summary>
        /// Applies the rule.
        /// </summary>
        /// <param name="input">The input to which the rule should be applied.</param>
        void Apply(T input);
        /// <summary>
        /// Applies the rule asynchronously.
        /// </summary>
        /// <param name="input">The input to which the rule should be applied.</param>
        /// <returns>A <see cref="Task"/> that describes the state of the application.</returns>
        Task ApplyAsync(T input);
        /// <summary>
        /// Applies the rule asynchronously.
        /// </summary>
        /// <param name="input">The input to which the rule should be applied.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> through which the application can be cancelled.</param>
        /// <returns>A <see cref="Task"/> that describes the state of the application.</returns>
        Task ApplyAsync(T input, CancellationToken cancellationToken);
    }
}
