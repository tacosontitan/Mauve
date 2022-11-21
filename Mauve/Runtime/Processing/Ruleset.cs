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

        public void Add(IRule<T> rule) => _rules.Add(rule);
        public void Apply(T input) =>
            _rules?.ForEach(rule => rule.Apply(input));
        public async Task ApplyAsync(T input) =>
            await ApplyAsync(input, CancellationToken.None);
        public async Task ApplyAsync(T input, CancellationToken cancellationToken) =>
            await Task.Run(() => Apply(input), cancellationToken);
        public void Clear() => _rules.Clear();
        public void Remove(IRule<T> rule) => _rules.Remove(rule);

        #endregion

    }
}
