namespace Mauve.Math
{
    /// <summary>
    /// Represents a <see cref="NumericBase"/> for specification of base.
    /// </summary>
    public enum NumericBase : int
    {
        /// <summary>
        /// Represents an unspecified or unsupported <see cref="NumericBase"/>.
        /// </summary>
        None = 0,
        /// <summary>
        /// A method of mathematical expression which uses only two symbols, typically <c>[0,1]</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Binary_number">Learn more.</see></remarks>
        Binary = 2,
        /// <summary>
        /// A method of mathematical expression which uses only three symbols, typically <c>[0,1,2]</c>. However, <c>[-1,0,1]</c> is also common.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Ternary_numeral_system">Learn more.</see></remarks>
        Ternary = 3,
        /// <summary>
        /// A method of mathematical expression which uses only four symbols: <c>[0,1,2,3]</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Quaternary_numeral_system">Learn more.</see></remarks>
        Quaternary = 4,
        /// <summary>
        /// A method of mathematical expression which uses only five symbols: <c>[0,1,2,3,4]</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Quinary">Learn more.</see></remarks>
        Quinary = 5,
        /// <summary>
        /// A method of mathematical expression which uses only six symbols: <c>[0,1,2,3,4,5]</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Senary">Learn more.</see></remarks>
        Senary = 6,
        /// <summary>
        /// A method of mathematical expression which uses only seven symbols: <c>[0,1,2,3,4,5,6]</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Septenary">Learn more.</see></remarks>
        Septenary = 7,
        /// <summary>
        /// A method of mathematical expression which uses only eight symbols: <c>[0,1,2,3,4,5,6,7]</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Octal">Learn more.</see></remarks>
        Octal = 8,
        /// <summary>
        /// A method of mathematical expression which uses only nine symbols: <c>[0,1,2,3,4,5,6,7,8]</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Ternary_numeral_system#Compact_ternary_representation:_base_9_and_27">Learn more.</see></remarks>
        Nonary = 9,
        /// <summary>
        /// The standard system for denoting integer and non-integer numbers. It contains ten symbols: <c>[0,1,2,3,4,5,6,7,8,9]</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Decimal">Learn more.</see></remarks>
        Decimal = 10,
        /// <summary>
        /// A method of mathematical expression which uses eleven symbols: <c>[0,1,2,3,4,5,6,7,8,9,a]</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Undecimal">Learn more.</see></remarks>
        Undecimal = 11,
        /// <summary>
        /// A method of mathematical expression which uses twelve symbols: <c>[0,1,2,3,4,5,6,7,8,9,a,b]</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Duodecimal">Learn more.</see></remarks>
        Duodecimal = 12,
        /// <summary>
        /// A method of mathematical expression which uses sixteen symbols: <c>[0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f]</c>. Typically expressed with a prefix of <c>0x</c>, for example <c>0x01a4</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Hexadecimal">Learn more.</see></remarks>
        Hexadecimal = 16,
        /// <summary>
        /// A method of mathematical expression which uses twenty symbols: <c>[0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,j,k]</c>. The letter <c>i</c> is typically excluded due to looking similar to <c>1</c>.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Vigesimal">Learn more.</see></remarks>
        Vigesimal = 20,
        /// <summary>
        /// A method of mathematical expression which uses sixty symbols: <c>[0-59]</c>. Commonly used in a modified form for measuring time, angles, and geographic coordinates.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Sexagesimal">Learn more.</see></remarks>
        Sexagesimal = 60
    }
}
