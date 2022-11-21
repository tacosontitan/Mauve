using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Runtime.Processing
{
    /// <summary>
    /// Represents a collection of rules that should be applied in FIFO order.
    /// </summary>
    public class Ruleset<T> : IRule<T>
    {

        #region Fields

        private readonly List<IRule<T>> _rules;

        #endregion

        #region Properties

        /// <summary>
        /// The rules which this <see cref="Ruleset"/> applies.
        /// </summary>
        public IReadOnlyCollection<IRule<T>> Rules => _rules.AsReadOnly();

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a new <see cref="IRule{T}"/> to the <see cref="Ruleset{T}"/>.
        /// </summary>
        /// <param name="rule">The <see cref="IRule{T}"/> to add.</param>
        public void Add(IRule<T> rule) => _rules.Add(rule);
        /// <summary>
        /// Applies the <see cref="Ruleset{T}"/> to the specified input.
        /// </summary>
        /// <param name="input">The input to apply this <see cref="Ruleset{T}"/> to.</param>
        public void Apply(T input) =>
            _rules?.ForEach(rule => rule.Apply(input));
        /// <summary>
        /// Applies the <see cref="Ruleset{T}"/> to the specified input.
        /// </summary>
        /// <param name="input">The input to apply this <see cref="Ruleset{T}"/> to.</param>
        /// <returns>A <see cref="Task"/> describing the state of the application.</returns>
        public async Task ApplyAsync(T input) =>
            await ApplyAsync(input, CancellationToken.None);
        /// <summary>
        /// Applies the <see cref="Ruleset{T}"/> to the specified input.
        /// </summary>
        /// <param name="input">The input to apply this <see cref="Ruleset{T}"/> to.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> through which the application can be cancelled.</param>
        /// <returns>A <see cref="Task"/> describing the state of the application.</returns>
        public async Task ApplyAsync(T input, CancellationToken cancellationToken) =>
            await Task.Run(() => Apply(input), cancellationToken);
        /// <summary>
        /// Clears the <see cref="Ruleset{T}"/> of all contained <see cref="IRule{T}"/> instances.
        /// </summary>
        public void Clear() => _rules.Clear();
        /// <summary>
        /// Removes the specified <see cref="IRule{T}"/> from the <see cref="Ruleset{T}"/>.
        /// </summary>
        /// <param name="rule">The <see cref="IRule{T}"/> to remove.</param>
        public void Remove(IRule<T> rule) => _rules.Remove(rule);

        #endregion

    }
}
