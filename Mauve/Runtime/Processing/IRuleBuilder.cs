using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Processing
{
    internal interface IRuleBuilder<T> : IBuilder<Rule>
    {
        IRuleBuilder<T> Otherwise(Action<T> action);
        IRuleBuilder<T> Then(Action<T> action);
        IRuleBuilder<T> Throw(Exception e);
        IRuleBuilder<T> Unless(Predicate<T> predicate);
        IRuleBuilder<T> When(Predicate<T> predicate);
        IRuleBuilder<T> WhenEqualTo(T value);
        IRuleBuilder<T> WhenIn(params T[] values);
        IRuleBuilder<T> WhenNotEqualTo(T value);
        IRuleBuilder<T> WhenNull();
        IRuleBuilder<T> WithMessage(Func<T, string> messageQuery);
    }
}
