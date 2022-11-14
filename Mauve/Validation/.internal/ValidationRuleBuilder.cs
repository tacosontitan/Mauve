using System;

namespace Mauve.Validation
{
    internal class ValidationRuleBuilder<T> : IValidationRuleBuilder<T>
    {
        public IValidationRuleBuilder<T> Otherwise(Action<T> action) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> Then(Action<T> action) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> Throw(Exception e) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> Unless(Predicate<T> predicate) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> When(Predicate<T> predicate) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> WhenEqualTo(T value) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> WhenIn(params T[] values) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> WhenNotEqualTo(T value) => throw new NotImplementedException();
        public IValidationRuleBuilder<T> WhenNull() => throw new NotImplementedException();
        public IValidationRuleBuilder<T> WithMessage(Func<T, string> messageQuery) => throw new NotImplementedException();
    }
}
