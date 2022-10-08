using System.Linq;

namespace Mauve.Math
{
    /// <summary>
    /// Represents a <see langword="class"/> capable of converting between different <see cref="NumericBase"/> values. 
    /// </summary>
    public class NumericBaseConverter
    {

        #region Constants

        private const string CharacterSet = @"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        #endregion

        #region Public Methods

        /// <summary>
        /// Converts the specified input between the specified <paramref name="from"/> <see cref="NumericBase"/> and <paramref name="to"/> <see cref="NumericBase"/>.
        /// </summary>
        /// <param name="input">The input to convert.</param>
        /// <param name="from">The <see cref="NumericBase"/> to convert from.</param>
        /// <param name="to">The <see cref="NumericBase"/> to convert to.</param>
        /// <returns>The input converted from the specified <paramref name="from"/> <see cref="NumericBase"/> to the <paramref name="to"/> <see cref="NumericBase"/>.</returns>
        public string Convert(string input, NumericBase from, NumericBase to)
        {
            char[] fromSet = CharacterSet.Take((int)from).ToArray();
            char[] toSet = CharacterSet.Take((int)to).ToArray();
            int decimalValue = ToDecimal(input, fromSet);
            return FromDecimal(decimalValue, toSet);
        }

        #endregion

        #region Private Methods

        private string FromDecimal(int input, char[] characters)
        {
            string result = string.Empty;
            int targetBase = characters.Length;
            do
            {
                result = characters[input % targetBase] + result;
                input /= targetBase;
            }
            while (input > 0);
            return result;
        }
        private int ToDecimal(string input, char[] characters)
        {
            int result = 0;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                int j;
                char next = input[i];
                for (j = 0; j < characters.Length; j++)
                    if (characters[j] == next)
                        break;

                result += (int)System.Math.Pow(characters.Length, input.Length - 1 - i) * j;
            }

            return result;
        }

        #endregion

    }
}
