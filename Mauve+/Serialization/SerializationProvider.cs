namespace Mauve.Serialization
{
    /// <summary>
    /// Represents an <see cref="ISerializationProvider"/> for the serialization and deserialization of data.
    /// </summary>
    public abstract class SerializationProvider
    {

        #region Properties

        /// <summary>
        /// The <see cref="Mauve.SerializationMethod"/> utilized for the serialization and deserialization of data.
        /// </summary>
        public SerializationMethod SerializationMethod { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="SerializationProvider"/> with the specified <see cref="Mauve.SerializationMethod"/>.
        /// </summary>
        /// <param name="serializationMethod">The <see cref="Mauve.SerializationMethod"/> that should be utilized for the serialization and deserialization of data.</param>
        public SerializationProvider(SerializationMethod serializationMethod) =>
            SerializationMethod = serializationMethod;

        #endregion

        #region Public Methods

        /// <summary>
        /// Deserializes the input string utilizing the current serialization configuration.
        /// </summary>
        /// <typeparam name="T">The type to convert the deserialized data to.</typeparam>
        /// <param name="input">zthe input string containing the serialized data.</param>
        /// <returns>Returns the input string deserialized using the specified <see cref="Mauve.SerializationMethod"/>.</returns>
        public abstract T Deserialize<T>(string input);
        /// <summary>
        /// Serializes the input data utilizing the current serialization configuration.
        /// </summary>
        /// <typeparam name="T">The type of the data to be serialized.</typeparam>
        /// <param name="input">The data to be serialized.</param>
        /// <returns>Returns the input data serialized using the specified <see cref="Mauve.SerializationMethod"/>.</returns>
        public abstract string Serialize<T>(T input);

        #endregion

    }
}
