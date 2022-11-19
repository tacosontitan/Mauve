using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Processing
{
    internal interface IRuleBuilder<T> : IBuilder<Rule>
    {
        /// <summary>
        /// Defines an action that should be executed when the previous condition fails.
        /// </summary>
        /// <param name="action">The action to be executed.</param>
        /// <returns>The current <see cref="IRuleBuilder{T}"/> instance.</returns>
        IRuleBuilder<T> Otherwise(Action<T> action);
        /// <summary>
        /// Defines an action that should be executed when the current condition succeeds.
        /// </summary>
        /// <param name="action">The action to be executed.</param>
        /// <returns>The current <see cref="IRuleBuilder{T}"/> instance.</returns>
        IRuleBuilder<T> Then(Action<T> action);
        /// <summary>
        /// Throws an exception when the current condition succeeds.
        /// </summary>
        /// <param name="e">The exception to be thrown.</param>
        /// <returns>The current <see cref="IRuleBuilder{T}"/> instance.</returns>
        IRuleBuilder<T> Throw(Exception e);
        /// <summary>
        /// Specifies a condition that overrides the previous condition.
        /// </summary>
        /// <param name="predicate">The conditional expression.</param>
        /// <returns>The current <see cref="IRuleBuilder{T}"/> instance.</returns>
        IRuleBuilder<T> Unless(Predicate<T> predicate);
        /// <summary>
        /// Specifies a condition that must be met prior to executing an upcoming action.
        /// </summary>
        /// <param name="predicate">The conditional expression.</param>
        /// <returns>The current <see cref="IRuleBuilder{T}"/> instance.</returns>
        IRuleBuilder<T> When(Predicate<T> predicate);
        /// <summary>
        /// Specifies that the input value must be equal to a specified value.
        /// </summary>
        /// <param name="value">The value the input should be compared to.</param>
        /// <returns>The current <see cref="IRuleBuilder{T}"/> instance.</returns>
        IRuleBuilder<T> WhenEqualTo(T value);
        /// <summary>
        /// Specifies that the input value must be equal to one of the specified values.
        /// </summary>
        /// <param name="values">The values to compare the input to.</param>
        /// <returns>The current <see cref="IRuleBuilder{T}"/> instance.</returns>
        IRuleBuilder<T> WhenIn(params T[] values);
        IRuleBuilder<T> WhenNotEqualTo(T value);
        IRuleBuilder<T> WhenNull();
        IRuleBuilder<T> WithMessage(Func<T, string> messageQuery);
    }
}
