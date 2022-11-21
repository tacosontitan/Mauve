using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Runtime.Processing
{
    /// <summary>
    /// Represents an <see langword="abstract"/> implementation of <see cref="IRule{T}"/>.
    /// </summary>
    /// <typeparam name="T">Specifies the type this rule applies to.</typeparam>
    public abstract class Rule<T> : IRule<T>
    {
        /// <summary>
        /// Applies the rule to the specified input.
        /// </summary>
        /// <param name="input">The input to which the rule should be applied.</param>
        public abstract void Apply(T input);
        /// <summary>
        /// Applies the rule asynchronously.
        /// </summary>
        /// <param name="input">The input to which the rule should be applied.</param>
        /// <returns>A <see cref="Task"/> that describes the state of the application.</returns>
        public async Task ApplyAsync(T input) =>
            await ApplyAsync(input, CancellationToken.None);
        /// <summary>
        /// Applies the rule asynchronously.
        /// </summary>
        /// <param name="input">The input to which the rule should be applied.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> through which the application can be cancelled.</param>
        /// <returns>A <see cref="Task"/> that describes the state of the application.</returns>
        public async Task ApplyAsync(T input, CancellationToken cancellationToken) =>
            await Task.Run(() => Apply(input), cancellationToken);
    }
}
