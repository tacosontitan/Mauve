using System;
using System.Collections.Generic;

using Mauve.Extensibility;

namespace Mauve.Runtime.Processing
{
    public class RuleBuilder<T> : IRuleBuilder<T>
    {

        #region Fields

        private readonly List<Func<T, bool>> _functions;

        #endregion

        #region Constructor

        public RuleBuilder() =>
            _functions = new List<Func<T, bool>>();

        #endregion

        #region Public Methods

        public Rule<T> Build() =>
            new Rule<T>(_functions);
        public IRuleBuilder<T> Then(Action<T> action)
        {
            _functions.Add(input =>
            {
                action(input);
                return true;
            });
            return this;
        }
        public IRuleBuilder<T> When(Predicate<T> predicate)
        {
            _functions.Add(input => predicate(input));
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

        #endregion

    }
}
