using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Mauve.Serialization
{
    /// <summary>
    /// Represents a <see cref="SerializationProvider"/> focused on serializing and deserializing data using <see cref="SerializationMethod.Binary"/>.
    /// </summary>
    /// <inheritdoc/>
    public class BinarySerializationProvider : SerializationProvider
    {

        #region Properties

        /// <summary>
        /// The <see cref="System.Text.Encoding"/> the data should be serialized and deserialized with.
        /// </summary>
        public Encoding Encoding { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="BinarySerializationProvider"/> using <see cref="System.Text.Encoding.Unicode"/>.
        /// </summary>
        public BinarySerializationProvider() : this(Encoding.Unicode) { }
        /// <summary>
        /// Creates a new instance of <see cref="BinarySerializationProvider"/> using the specified <see cref="System.Text.Encoding"/>.
        /// </summary>
        public BinarySerializationProvider(Encoding encoding) :
            base(SerializationMethod.Binary) =>
                Encoding = encoding;

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public override T Deserialize<T>(string input)
        {
            byte[] decodedInput = Encoding.GetBytes(input);
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                stream.Write(decodedInput, 0, decodedInput.Length);
                _ = stream.Seek(0, SeekOrigin.Begin);
                object deserializedObject = formatter.Deserialize(stream);
                return (T)Convert.ChangeType(deserializedObject, typeof(T));
            }
        }
        /// <inheritdoc/>
        public override string Serialize<T>(T input)
        {
            byte[] serializedBytes = null;
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, input);
                serializedBytes = stream.ToArray();
            }

            return Encoding.GetString(serializedBytes);
        }

        #endregion

    }
}
