using System;
using System.Collections.Generic;

namespace Mauve.Runtime.Processing
{
    internal class RuleBuilder<T> : IRuleBuilder<T>
    {

        #region Fields

        private readonly List<RuleConditionHandler<T>> _handlers;

        #endregion

        #region Constructor

        public RuleBuilder() =>
            _handlers = new List<RuleConditionHandler<T>>();

        #endregion

        public Rule<T> Build() => throw new NotImplementedException();
        public IRuleBuilder<T> Otherwise(Action<T> action) => throw new NotImplementedException();
        public IRuleBuilder<T> Then(Action<T> action) => throw new NotImplementedException();
        public IRuleBuilder<T> Throw(Exception e) => throw new NotImplementedException();
        public IRuleBuilder<T> Unless(Predicate<T> predicate) => throw new NotImplementedException();
        public IRuleBuilder<T> When(Predicate<T> predicate) => throw new NotImplementedException();
        public IRuleBuilder<T> WhenEqualTo(T value) => throw new NotImplementedException();
        public IRuleBuilder<T> WhenIn(params T[] values) => throw new NotImplementedException();
        public IRuleBuilder<T> WhenNotEqualTo(T value) => throw new NotImplementedException();
        public IRuleBuilder<T> WhenNotIn(params T[] values) => throw new NotImplementedException();
        public IRuleBuilder<T> WhenNull() => throw new NotImplementedException();
        public IRuleBuilder<T> WithMessage(string message) => throw new NotImplementedException();
    }
}
