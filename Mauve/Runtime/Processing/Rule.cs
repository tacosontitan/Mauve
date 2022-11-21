using System;
using System.Collections.Generic;
using System.Linq;

using Mauve.Extensibility;

namespace Mauve.Runtime.Processing
{
    /// <summary>
    /// Represents a rule which can be applied to a specific type.
    /// </summary>
    /// <typeparam name="T">Specifies the type which the rule applies to.</typeparam>
    public class Rule<T>
    {

        #region Fields

        private readonly List<Func<T, bool>> _functions;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="Rule{T}"/> instance.
        /// </summary>
        /// <param name="functions">The functions the rule should apply.</param>
        public Rule(IEnumerable<Func<T, bool>> functions) =>
             _functions = new List<Func<T, bool>>(functions);
        /// <summary>
        /// Creates a new <see cref="Rule{T}"/> instance.
        /// </summary>
        /// <param name="functions">The functions the rule should apply.</param>
        public Rule(params Func<T, bool>[] functions) =>
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
