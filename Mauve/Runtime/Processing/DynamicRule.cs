using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Mauve.Extensibility;

namespace Mauve.Runtime.Processing
{
    /// <summary>
    /// Represents a rule which can be applied to a specific type.
    /// </summary>
    /// <typeparam name="T">Specifies the type which the rule applies to.</typeparam>
    public class DynamicRule<T> : IRule<T>
    {

        #region Fields

        private readonly List<Func<T, bool>> _functions;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="DynamicRule{T}"/> instance.
        /// </summary>
        /// <param name="functions">The functions the rule should apply.</param>
        public DynamicRule(IEnumerable<Func<T, bool>> functions) =>
             _functions = new List<Func<T, bool>>(functions);
        /// <summary>
        /// Creates a new <see cref="DynamicRule{T}"/> instance.
        /// </summary>
        /// <param name="functions">The functions the rule should apply.</param>
        public DynamicRule(params Func<T, bool>[] functions) =>
            _functions = new List<Func<T, bool>>(functions);

        #endregion

        #region Public Methods

        /// <summary>
        /// Applies the rule to the specified input.
        /// </summary>
        /// <param name="input">The input to apply the rule to.</param>
        public void Apply(T input)
        {
            Func<T, bool> firstFunction = _functions.FirstOrDefault();
            Func<T, bool> secondFunction = _functions.NextOrDefault(firstFunction);
            ApplyRecursive(input, firstFunction, secondFunction);
        }
        /// <summary>
        /// Applies the rule asynchronously.
        /// </summary>
        /// <param name="input">The input to which the rule should be applied.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> through which the application can be cancelled.</param>
        /// <returns>A <see cref="Task"/> that describes the state of the application.</returns>
        public async Task Apply(T input, CancellationToken cancellationToken) =>
            await Task.Run(() => Apply(input), cancellationToken);

        #endregion

        #region Private Methods

        private void ApplyRecursive(T input, Func<T, bool> currentFunction, Func<T, bool> nextFunction)
        {
            if (currentFunction?.Invoke(input) == true)
            {
                if (nextFunction is null)
                    return;

                ApplyRecursive(input, nextFunction, _functions.NextOrDefault(nextFunction));
            }
        }

        #endregion

    }
}
