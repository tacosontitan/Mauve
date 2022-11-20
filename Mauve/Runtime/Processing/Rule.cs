using System;
using System.Collections.Generic;
using System.Linq;

using Mauve.Extensibility;

namespace Mauve.Runtime.Processing
{
    public class Rule<T>
    {

        #region Fields

        private readonly List<Func<T, bool>> _functions;

        #endregion

        #region Constructor

        public Rule(IEnumerable<Func<T, bool>> functions) =>
             _functions = new List<Func<T, bool>>(functions);
        public Rule(params Func<T, bool>[] functions) =>
            _functions = new List<Func<T, bool>>(functions);

        #endregion

        #region Public Methods

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
