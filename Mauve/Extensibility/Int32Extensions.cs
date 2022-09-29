using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mauve.Numerics;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods for <see cref="int"/> instances.
    /// </summary>
    public static class Int32Extensions
    {
        /// <summary>
        /// Converts the specified <see cref="int"/> to a <see cref="string"/> representation of the specified <see cref="NumericBase"/>.
        /// </summary>
        /// <param name="input">The <see cref="int"/> value to convert.</param>
        /// <param name="desiredBase">The desired <see cref="NumericBase"/> for the output.</param>
        /// <returns>Returns the specified <see cref="int"/> converted to the specified <see cref="NumericBase"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown when the specified <see cref="NumericBase"/> is not supported.</exception>
        public static string ToString(this int input, NumericBase desiredBase)
        {
            switch (desiredBase)
            {
                case NumericBase.Binary: return Convert.ToString(input, 2);
                case NumericBase.Octal: return Convert.ToString(input, 8);
                case NumericBase.Decimal: return Convert.ToString(input, 10);
                case NumericBase.Hexadecimal: return Convert.ToString(input, 16);
                default: throw new NotSupportedException($"The specified base `{desiredBase}` is not currently supported.");
            }
        }
    }
}
