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
        IRuleBuilder<T> Unless(Predicate<T> predicate);
        IRuleBuilder<T> When(Predicate<T> predicate);
        IRuleBuilder<T> WhenEqualTo(T value);
        IRuleBuilder<T> WhenIn(params T[] values);
        IRuleBuilder<T> WhenNotEqualTo(T value);
        IRuleBuilder<T> WhenNull();
        IRuleBuilder<T> WithMessage(Func<T, string> messageQuery);
    }
}
