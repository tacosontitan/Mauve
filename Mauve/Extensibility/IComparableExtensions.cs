using System;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods for <see cref="IComparable"/> instances.
    /// </summary>
    public static class IComparableExtensions
    {
        /// <summary>
        /// Constrains an input value to a specified range.
        /// </summary>
        /// <typeparam name="T">The type of data to constrain.</typeparam>
        /// <param name="input">The input value to constrain.</param>
        /// <param name="lowerBound">The lower bound of the constraint.</param>
        /// <param name="upperBound">The upper bound of the constraint.</param>
        /// <returns>Returns the input if it falls on or between the lower and upper bounds, otherwise the exceeded bound is returned in its place.</returns>
        public static T Constrain<T>(this T input, T lowerBound, T upperBound) where T : IComparable
        {
            if (input.CompareTo(lowerBound) < 0)
                input = lowerBound;
            else if (input.CompareTo(upperBound) > 0)
                input = upperBound;

            return input;
        }
        /// <summary>
        /// Determines if the calling object's value is equal to or greater than the specified minimum value, while remaining less than or equal to the specified maximum value.
        /// </summary>
        /// <param name="value">The calling object's value.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>Returns true if the calling object's value is equal to or greater than the specified minimum value, while remaining less than or equal to the specified maximum value, otherwise false.</returns>
        public static bool WithinRange(this IComparable value, IComparable min, IComparable max) => value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }
}
