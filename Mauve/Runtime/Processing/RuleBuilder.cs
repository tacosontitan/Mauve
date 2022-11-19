using System;

using Mauve.Extensibility;

namespace Mauve.Runtime.Processing
{
    public class RuleBuilder<T> : IRuleBuilder<T>
    {

        #region Fields

        private RuleHandler<T> _handler;
        private Predicate<T> _previousCondition;

        #endregion

        public Rule<T> Build() =>
            new Rule<T>(_handler);
        public IRuleBuilder<T> Otherwise(Action<T> action) => throw new NotSupportedException("The otherwise method is not currently supported.");
        public IRuleBuilder<T> Then(Action<T> action)
        {
            if (_previousCondition is null)
                throw new InvalidOperationException("Cannot execute an action without a preceding condition.");

            var handler = new RuleHandler<T>(input =>
            {
                action(input);
                return true;
            });
            _handler.SetNextHandler(handler);
            return this;
        }
        public IRuleBuilder<T> Throw(Exception e)
        {
            if (_previousCondition is null)
                throw new InvalidOperationException("Cannot execute an action without a preceding condition.");

            _handler.SetNextHandler(new RuleHandler<T>(input => throw e));
            return this;
        }
        public IRuleBuilder<T> Unless(Predicate<T> predicate)
        {
            _handler = _previousCondition is null
                ? throw new InvalidOperationException("Cannot precede an unspecified condition.")
                : new RuleHandler<T>(input => predicate(input), _handler);

            _previousCondition = predicate;
            return this;
        }
        public IRuleBuilder<T> When(Predicate<T> predicate)
        {
            var handler = new RuleHandler<T>(input => predicate(input));
            if (_handler is null)
                _handler = handler;
            else
                _handler.SetNextHandler(handler);

            _previousCondition = predicate;
            return this;
        }
        public IRuleBuilder<T> WhenEqualTo(T value) =>
            When(input => input.Equals(value));
        public IRuleBuilder<T> WhenIn(params T[] values) =>
            When(input => input.In(values));
        public IRuleBuilder<T> WhenNotEqualTo(T value) =>
            When(input => !input.Equals(value));
        public IRuleBuilder<T> WhenNotIn(params T[] values) =>
            When(input => !input.In(values));
        public IRuleBuilder<T> WhenNull() =>
            When(input => input == null);
    }
}
