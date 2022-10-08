using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Math.Converters
{
    public class BinaryConverter : NumericBaseConverter
    {

        #region Binary

        protected override string FromBinary(string input) => input;
        protected override string ToBinary(string input) => input;

        #endregion

        #region From

        protected override string FromDecimal(string input) => throw new NotImplementedException();
        protected override string FromDuodecimal(string input) => throw new NotImplementedException();
        protected override string FromHexadecimal(string input) => throw new NotImplementedException();
        protected override string FromNonary(string input) => throw new NotImplementedException();
        protected override string FromOctal(string input)
        {
            long octalValue = Convert.ToInt64(input, 8);
            return Convert.ToString(octalValue, 2);
        }
        protected override string FromQuaternary(string input) => throw new NotImplementedException();
        protected override string FromQuinary(string input) => throw new NotImplementedException();
        protected override string FromSeptenary(string input) => throw new NotImplementedException();
        protected override string FromSexagesimal(string input) => throw new NotImplementedException();
        protected override string FromTernary(string input) => throw new NotImplementedException();
        protected override string FromUndecimal(string input) => throw new NotImplementedException();
        protected override string FromVigesimal(string input) => throw new NotImplementedException();

        #endregion

        #region To

        protected override string ToDecimal(string input) => Convert.ToInt64(input, 2).ToString();
        protected override string ToDuodecimal(string input) => throw new NotImplementedException();
        protected override string ToHexadecimal(string input)
        {
            long decimalValue = Convert.ToInt64(input, 2);
            return Convert.ToString(decimalValue, 16);
        }
        protected override string ToNonary(string input) => throw new NotImplementedException();
        protected override string ToOctal(string input)
        {
            long decimalValue = Convert.ToInt64(input, 8);
            return Convert.ToString(decimalValue, 2);
        }
        protected override string ToQuaternary(string input) => throw new NotImplementedException();
        protected override string ToQuinary(string input) => throw new NotImplementedException();
        protected override string ToSeptenary(string input) => throw new NotImplementedException();
        protected override string ToSexagesimal(string input) => throw new NotImplementedException();
        protected override string ToTernary(string input) => throw new NotImplementedException();
        protected override string ToUndecimal(string input) => throw new NotImplementedException();
        protected override string ToVigesimal(string input) => throw new NotImplementedException();

        #endregion

        #region Private Methods

        #endregion

    }
}
