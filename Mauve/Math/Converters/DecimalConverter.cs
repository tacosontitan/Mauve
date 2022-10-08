using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Math.Converters
{
    public class DecimalConverter : NumericBaseConverter
    {
        protected override string FromBinary(string input) => Convert.ToInt64(input, 2).ToString();
        protected override string FromDecimal(string input) => Convert.ToInt64(input, 10).ToString();
        protected override string FromDuodecimal(string input) => throw new NotImplementedException();
        protected override string FromHexadecimal(string input) => Convert.ToInt64(input, 16).ToString();
        protected override string FromNonary(string input) => throw new NotImplementedException();
        protected override string FromOctal(string input) => Convert.ToInt64(input, 8).ToString();
        protected override string FromQuaternary(string input) => throw new NotImplementedException();
        protected override string FromQuinary(string input) => throw new NotImplementedException();
        protected override string FromSeptenary(string input) => throw new NotImplementedException();
        protected override string FromSexagesimal(string input) => throw new NotImplementedException();
        protected override string FromTernary(string input) => throw new NotImplementedException();
        protected override string FromUndecimal(string input) => throw new NotImplementedException();
        protected override string FromVigesimal(string input) => throw new NotImplementedException();
        protected override string ToBinary(string input) => Convert.ToString(long.Parse(input), 2);
        protected override string ToDecimal(string input) => Convert.ToString(long.Parse(input), 10);
        protected override string ToDuodecimal(string input) => throw new NotImplementedException();
        protected override string ToHexadecimal(string input) => Convert.ToString(long.Parse(input), 16);
        protected override string ToNonary(string input) => throw new NotImplementedException();
        protected override string ToOctal(string input) => Convert.ToString(long.Parse(input), 8);
        protected override string ToQuaternary(string input) => throw new NotImplementedException();
        protected override string ToQuinary(string input) => throw new NotImplementedException();
        protected override string ToSeptenary(string input) => throw new NotImplementedException();
        protected override string ToSexagesimal(string input) => throw new NotImplementedException();
        protected override string ToTernary(string input) => throw new NotImplementedException();
        protected override string ToUndecimal(string input) => throw new NotImplementedException();
        protected override string ToVigesimal(string input) => throw new NotImplementedException();
    }
}
