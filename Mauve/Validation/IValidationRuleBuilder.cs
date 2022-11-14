using System;

namespace Mauve.Validation
{
    public interface IValidationRuleBuilder<T>
    {
        IValidationRuleBuilder<T> Otherwise(Action<T> action);
        IValidationRuleBuilder<T> Then(Action<T> action);
        IValidationRuleBuilder<T> Throw(Exception e);
        IValidationRuleBuilder<T> Unless(Predicate<T> predicate);
        IValidationRuleBuilder<T> When(Predicate<T> predicate);
        IValidationRuleBuilder<T> WhenEqualTo(T value);
        IValidationRuleBuilder<T> WhenIn(params T[] values);
        IValidationRuleBuilder<T> WhenNotEqualTo(T value);
        IValidationRuleBuilder<T> WhenNull();
        IValidationRuleBuilder<T> WithMessage(Func<T, string> messageQuery);
    }
}
