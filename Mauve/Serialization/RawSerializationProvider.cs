using System;

namespace Mauve.Serialization
{
    /// <summary>
    /// Represents a <see cref="SerializationProvider"/> focused on serializing and deserializing data using <see cref="SerializationMethod.None"/>.
    /// </summary>
    /// <inheritdoc/>
    internal class RawSerializationProvider : SerializationProvider
    {

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="RawSerializationProvider"/>.
        /// </summary>
        public RawSerializationProvider() : base(SerializationMethod.None) { }

        #endregion

        #region Public Methods

        public override T Deserialize<T>(string input) => (T)Convert.ChangeType(input, typeof(T));
        public override string Serialize<T>(T input) => input.ToString();

        #endregion

    }
}
