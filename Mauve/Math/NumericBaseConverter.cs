using System.Linq;

namespace Mauve.Math
{
    public class NumericBaseConverter
    {

        #region Constants

        private const string CharacterSet = @"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        #endregion

        #region Public Methods

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
