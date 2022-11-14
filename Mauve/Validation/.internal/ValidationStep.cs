using System;

using Mauve.Patterns;

namespace Mauve.Validation
{
    internal class ValidationStep<T> : Handler<Func<T, bool>>
    {

        #region Fields

        private readonly T _input;

        #endregion

        #region Constructor

        public ValidationStep(T input, Func<T, bool> request) :
            base(request) =>
            _input = input;
        public ValidationStep(T input, Func<T, bool> request, ValidationStep<T> nextStep) :
            base(request, nextStep) =>
            _input = input;

        #endregion

        #region Protected Methods

        protected override bool TryHandleRequest(Func<T, bool> request) =>
            request(_input);

        #endregion

    }
}
