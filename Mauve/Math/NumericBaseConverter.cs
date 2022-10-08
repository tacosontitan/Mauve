using System;

namespace Mauve.Math
{
    /// <summary>
    /// Represents a simplified interface for converting between different values of <see cref="NumericBase"/>.
    /// </summary>
    public abstract class NumericBaseConverter
    {

        #region Public Methods

        /// <summary>
        /// Converts the specified <paramref name="input"/> from the specified <see cref="NumericBase"/>.
        /// </summary>
        /// <param name="numericBase">The <see cref="NumericBase"/> to convert the specified <paramref name="input"/> from.</param>
        /// <param name="input">The input to convert.</param>
        /// <returns>Returns the specified <paramref name="input"/> converted from the specified <see cref="NumericBase"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the specified <paramref name="input"/> is null or whitespace.</exception>
        /// <exception cref="NotSupportedException">Thrown if the specified <see cref="NumericBase"/> is not supported.</exception>
        public string From(NumericBase numericBase, string input)
        {
            // Validate the input.
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("A valid input is required to convert numeric base.");

            // Convert from the specified base.
            switch (numericBase)
            {
                case NumericBase.Binary: return FromBinary(input);
                case NumericBase.Ternary: return FromTernary(input);
                case NumericBase.Quaternary: return FromQuaternary(input);
                case NumericBase.Quinary: return FromQuinary(input);
                case NumericBase.Septenary: return FromSeptenary(input);
                case NumericBase.Octal: return FromOctal(input);
                case NumericBase.Nonary: return FromNonary(input);
                case NumericBase.Decimal: return FromDecimal(input);
                case NumericBase.Undecimal: return FromUndecimal(input);
                case NumericBase.Duodecimal: return FromDuodecimal(input);
                case NumericBase.Hexadecimal: return FromHexadecimal(input);
                case NumericBase.Vigesimal: return FromVigesimal(input);
                case NumericBase.Sexagesimal: return FromSexagesimal(input);
            }

            // If we didn't convert above, then it's not supported.
            throw new NotSupportedException("The specified numeric base is not supported.");
        }
        /// <summary>
        /// Converts the specified <paramref name="input"/> to the specified <see cref="NumericBase"/>.
        /// </summary>
        /// <param name="numericBase">The <see cref="NumericBase"/> to convert the specified <paramref name="input"/> to.</param>
        /// <param name="input">The input to convert.</param>
        /// <returns>Returns the specified <paramref name="input"/> converted to the specified <see cref="NumericBase"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the specified <paramref name="input"/> is null or whitespace.</exception>
        /// <exception cref="NotSupportedException">Thrown if the specified <see cref="NumericBase"/> is not supported.</exception>
        public string To(NumericBase numericBase, string input)
        {
            // Validate the input.
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("A valid input is required to convert numeric base.");

            // Convert from the specified base.
            switch (numericBase)
            {
                case NumericBase.Binary: return ToBinary(input);
                case NumericBase.Ternary: return ToTernary(input);
                case NumericBase.Quaternary: return ToQuaternary(input);
                case NumericBase.Quinary: return ToQuinary(input);
                case NumericBase.Septenary: return ToSeptenary(input);
                case NumericBase.Octal: return ToOctal(input);
                case NumericBase.Nonary: return ToNonary(input);
                case NumericBase.Decimal: return ToDecimal(input);
                case NumericBase.Undecimal: return ToUndecimal(input);
                case NumericBase.Duodecimal: return ToDuodecimal(input);
                case NumericBase.Hexadecimal: return ToHexadecimal(input);
                case NumericBase.Vigesimal: return ToVigesimal(input);
                case NumericBase.Sexagesimal: return ToSexagesimal(input);
            }

            // If we didn't convert above, then it's not supported.
            throw new NotSupportedException("The specified numeric base is not supported.");
        }

        #endregion

        #region Protected Methods

        protected abstract string FromBinary(string input);
        protected abstract string FromTernary(string input);
        protected abstract string FromQuaternary(string input);
        protected abstract string FromQuinary(string input);
        protected abstract string FromSeptenary(string input);
        protected abstract string FromOctal(string input);
        protected abstract string FromNonary(string input);
        protected abstract string FromDecimal(string input);
        protected abstract string FromUndecimal(string input);
        protected abstract string FromDuodecimal(string input);
        protected abstract string FromHexadecimal(string input);
        protected abstract string FromVigesimal(string input);
        protected abstract string FromSexagesimal(string input);
        protected abstract string ToBinary(string input);
        protected abstract string ToTernary(string input);
        protected abstract string ToQuaternary(string input);
        protected abstract string ToQuinary(string input);
        protected abstract string ToSeptenary(string input);
        protected abstract string ToOctal(string input);
        protected abstract string ToNonary(string input);
        protected abstract string ToDecimal(string input);
        protected abstract string ToUndecimal(string input);
        protected abstract string ToDuodecimal(string input);
        protected abstract string ToHexadecimal(string input);
        protected abstract string ToVigesimal(string input);
        protected abstract string ToSexagesimal(string input);

        #endregion

    }
}
