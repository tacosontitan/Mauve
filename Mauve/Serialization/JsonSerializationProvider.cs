using Newtonsoft.Json;

namespace Mauve.Serialization
{
    /// <summary>
    /// Represents a <see cref="SerializationProvider"/> focused on serializing and deserializing data using <see cref="SerializationMethod.Json"/>.
    /// </summary>
    /// <inheritdoc/>
    public class JsonSerializationProvider : SerializationProvider
    {

        #region Properties

        /// <summary>
        /// The <see cref="JsonSerializerSettings"/> utilized during the serialization and deserialization process.
        /// </summary>
        public JsonSerializerSettings Settings { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="JsonSerializationProvider"/>.
        /// </summary>
        public JsonSerializationProvider() : base(SerializationMethod.Json) { }

        #endregion

        #region Public Methods

        public override T Deserialize<T>(string input) => JsonConvert.DeserializeObject<T>(input, Settings);
        public override string Serialize<T>(T input) => JsonConvert.SerializeObject(input, Settings);

        #endregion

    }
}
