using System;
using System.Collections.Generic;

namespace Mauve.Validation
{
    internal class ValidationRuleBuilder<T> : IValidationRuleBuilder<T>
    {

        #region Fields

        private readonly T _input;
        private readonly ValidationRuleset _ruleset;
        private readonly List<Func<T, bool>> _steps;

        #endregion

        #region Constructor

        public ValidationRuleBuilder(T input, ValidationRuleset ruleset)
        {
            _input = input;
            _ruleset = ruleset;
            _steps = new List<Func<T, bool>>();
        }

        #endregion

        public ValidationRuleset Build()
        {

        }
        public IValidationRuleBuilder<T> Otherwise(Action<T> action)
        {

        }
        public IValidationRuleBuilder<T> Then(Action<T> action) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> Throw(Exception e) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> Unless(Predicate<T> predicate) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> When(Predicate<T> predicate)
        {

        }
        public IValidationRuleBuilder<T> WhenEqualTo(T value) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> WhenIn(params T[] values) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> WhenNotEqualTo(T value) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> WhenNull() => throw new NotImplementedException();
        public IValidationRuleBuilder<T> WithMessage(Func<T, string> messageQuery) => throw new NotImplementedException();
    }
}
