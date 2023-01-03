using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Mauve.Serialization
{
    /// <summary>
    /// Represents a <see cref="SerializationProvider"/> focused on serializing and deserializing data using <see cref="SerializationMethod.Yaml"/>.
    /// </summary>
    /// <inheritdoc/>
    internal class YamlSerializationProvider : SerializationProvider
    {

        #region Fields

        private readonly IDeserializer _deserializer;
        private readonly ISerializer _serializer;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="JsonSerializationProvider"/>.
        /// </summary>
        public YamlSerializationProvider() : base(SerializationMethod.Yaml)
        {
            _serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            // Create a deserializer.
            _deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
        }

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public override T Deserialize<T>(string input) => _deserializer.Deserialize<T>(input);
        /// <inheritdoc/>
        public override string Serialize<T>(T input) => _serializer.Serialize(input);

        #endregion

    }
}
