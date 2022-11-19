using System;

namespace Mauve.Runtime.Processing
{
    public class Rule<T>
    {

        #region Fields

        private readonly Action<T> _action;

        #endregion

        #region Constructor

        public Rule(Action<T> action) =>
            _action = action;

        #endregion

        #region Public Methods

        public void Apply(T input) =>
            _action?.Invoke(input);

        #endregion

    }
}
