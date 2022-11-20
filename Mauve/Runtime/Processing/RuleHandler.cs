using System;

namespace Mauve.Runtime.Processing
{
    public class RuleHandler<T>
    {

        #region Fields

        private RuleHandler<T> _nextHandler;
        private readonly Func<T, bool> _function;

        #endregion

        #region Constructor

        public RuleHandler(Func<T, bool> function) =>
            _function = function;
        public RuleHandler(Func<T, bool> function, RuleHandler<T> next)
        {
            _function = function;
            _nextHandler = next;
        }

        #endregion

        #region Public Methods

        public void Execute(T input)
        {
            if (!_function(input))
                _nextHandler?.Execute(input);
        }
        public void SetNextHandler(RuleHandler<T> next) =>
            _nextHandler = next;

        #endregion

    }
}
