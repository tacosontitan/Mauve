using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Processing
{
    internal class RuleConditionHandler<T> : Handler<Func<T, bool>>
    {

        #region Fields

        private readonly T _input;
        private readonly Action<T> _action;

        #endregion

        #region Constructors

        public RuleConditionHandler(T input, Action<T> action, Func<T, bool> request) :
            base(request)
        {
            _input = input;
            _action = action;
        }
        public RuleConditionHandler(T input, Action<T> action, Func<T, bool> request, Handler<Func<T, bool>> nextHandler) :
            base(request, nextHandler)
        {
            _input = input;
            _action = action;
        }

        #endregion

        #region Protected Methods

        protected override bool TryHandleRequest(Func<T, bool> request)
        {
            if (request(_input))
            {
                _action(_input);
                return true;
            }

            return false;
        }

        #endregion

    }
}
