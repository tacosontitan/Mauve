using System;
using System.Collections.Generic;

using Mauve.Extensibility;

namespace Mauve.Runtime.Processing
{
    public class RuleBuilder<T> : IDynamicRuleBuilder<T>
    {

        #region Fields

        private readonly List<Func<T, bool>> _functions;

        #endregion

        #region Constructor

        public RuleBuilder() =>
            _functions = new List<Func<T, bool>>();

        #endregion

        #region Public Methods

        public DynamicRule<T> Build() =>
            new DynamicRule<T>(_functions);
        public IDynamicRuleBuilder<T> Then(Action<T> action)
        {
            _functions.Add(input =>
            {
                action(input);
                return true;
            });
            return this;
        }
        public IDynamicRuleBuilder<T> When(Predicate<T> predicate)
        {
            _functions.Add(input => predicate(input));
            return this;
        }
        public IDynamicRuleBuilder<T> WhenEqualTo(T value) =>
            When(input => input.Equals(value));
        public IDynamicRuleBuilder<T> WhenIn(params T[] values) =>
            When(input => input.In(values));
        public IDynamicRuleBuilder<T> WhenNotEqualTo(T value) =>
            When(input => !input.Equals(value));
        public IDynamicRuleBuilder<T> WhenNotIn(params T[] values) =>
            When(input => !input.In(values));
        public IDynamicRuleBuilder<T> WhenNull() =>
            When(input => input == null);

        #endregion

    }
}
