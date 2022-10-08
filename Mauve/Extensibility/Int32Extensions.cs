using System;

using Mauve.Math;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods for <see cref="int"/> instances.
    /// </summary>
    public static class Int32Extensions
    {

        #region Public Methods

        /// <summary>
        /// Converts the specified <see cref="int"/> to a <see cref="string"/> representation of the specified <see cref="NumericBase"/>.
        /// </summary>
        /// <param name="input">The <see cref="int"/> value to convert.</param>
        /// <param name="desiredBase">The desired <see cref="NumericBase"/> for the output.</param>
        /// <returns>Returns the specified <see cref="int"/> converted to the specified <see cref="NumericBase"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown when the specified <see cref="NumericBase"/> is not supported.</exception>
        public static string ToString(this int input, NumericBase desiredBase)
        {
            var converter = new NumericBaseConverter();
            return converter.Convert(input.ToString(), NumericBase.Decimal, desiredBase);
        }

        #endregion

    }
}
