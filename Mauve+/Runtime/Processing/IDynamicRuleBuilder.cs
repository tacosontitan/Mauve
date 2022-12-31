using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Processing
{
    /// <summary>
    /// Represents an <see cref="IBuilder{T}"/> which creates <see cref="Rule"/> instances.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data the rule builder works with.</typeparam>
    public interface IDynamicRuleBuilder<T> : IBuilder<DynamicRule<T>>
    {
        /// <summary>
        /// Defines an action that should be executed when the current condition succeeds.
        /// </summary>
        /// <param name="action">The action to be executed.</param>
        /// <returns>The current <see cref="IDynamicRuleBuilder{T}"/> instance.</returns>
        IDynamicRuleBuilder<T> Then(Action<T> action);
        /// <summary>
        /// Specifies a condition that must be met prior to executing an upcoming action.
        /// </summary>
        /// <param name="predicate">The conditional expression.</param>
        /// <returns>The current <see cref="IDynamicRuleBuilder{T}"/> instance.</returns>
        IDynamicRuleBuilder<T> When(Predicate<T> predicate);
        /// <summary>
        /// Specifies that the input value must be equal to a specified value.
        /// </summary>
        /// <param name="value">The value the input should be compared to.</param>
        /// <returns>The current <see cref="IDynamicRuleBuilder{T}"/> instance.</returns>
        IDynamicRuleBuilder<T> WhenEqualTo(T value);
        /// <summary>
        /// Specifies that the input value must be equal to one of the specified values.
        /// </summary>
        /// <param name="values">The values to compare the input to.</param>
        /// <returns>The current <see cref="IDynamicRuleBuilder{T}"/> instance.</returns>
        IDynamicRuleBuilder<T> WhenIn(params T[] values);
        /// <summary>
        /// Specifies that the input value must not be one of the specified values.
        /// </summary>
        /// <param name="values">The values to compare the input to.</param>
        /// <returns>The current <see cref="IDynamicRuleBuilder{T}"/> instance.</returns>
        IDynamicRuleBuilder<T> WhenNotIn(params T[] values);
        /// <summary>
        /// Specifies that the input value must not be equal to a specified value.
        /// </summary>
        /// <param name="value">The value to compare the input to.</param>
        /// <returns>The current <see cref="IDynamicRuleBuilder{T}"/> instance.</returns>
        IDynamicRuleBuilder<T> WhenNotEqualTo(T value);
        /// <summary>
        /// Specifies that the input value must be null.
        /// </summary>
        /// <returns>The current <see cref="IDynamicRuleBuilder{T}"/> instance.</returns>
        IDynamicRuleBuilder<T> WhenNull();
    }
}
