namespace Mauve.Text
{
    /// <summary>
    /// A lexicon is the vocabulary of a language or branch of knowledge (such as nautical or medical).
    /// </summary>
    public class Lexicon
    {

        #region Properties

        /// <summary>
        /// The vocabulary used to represent this <see cref="Lexicon"/>.
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// The value represented by the vocabulary of this <see cref="Lexicon"/>.
        /// </summary>
        public object Value { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="Lexicon"/>.
        /// </summary>
        public Lexicon() { }
        /// <summary>
        /// Creates a new <see cref="Lexicon"/> with the specified token.
        /// </summary>
        /// <param name="token">The vocabulary used to represent this <see cref="Lexicon"/>.</param>
        public Lexicon(string token) => Token = token;
        /// <summary>
        /// Creates a new <see cref="Lexicon"/> with the specified token and value.
        /// </summary>
        /// <param name="token">The vocabulary used to represent this <see cref="Lexicon"/>.</param>
        /// <param name="value">The value represented by the vocabulary of this <see cref="Lexicon"/>.</param>
        public Lexicon(string token, object value) : this(token) => Value = value;

        #endregion

    }
}
