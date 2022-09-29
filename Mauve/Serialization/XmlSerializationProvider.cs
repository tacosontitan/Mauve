using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Mauve.Serialization
{
    /// <summary>
    /// Represents a <see cref="SerializationProvider"/> focused on serializing and deserializing data using <see cref="SerializationMethod.Xml"/>.
    /// </summary>
    /// <inheritdoc/>
    public class XmlSerializationProvider : SerializationProvider
    {

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="XmlSerializationProvider"/>.
        /// </summary>
        public XmlSerializationProvider() : base(SerializationMethod.Xml) { }

        #endregion

        #region Public Methods

        public override T Deserialize<T>(string input)
        {
            using (var stringReader = new StringReader(input))
            {
                var settings = new XmlReaderSettings();
                using (var xmlReader = XmlReader.Create(stringReader, settings))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)Convert.ChangeType(serializer.Deserialize(xmlReader), typeof(T));
                }
            }
        }
        public override string Serialize<T>(T input)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true, ConformanceLevel = ConformanceLevel.Auto };
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(xmlWriter, input);
                    return textWriter.ToString();
                }
            }
        }

        #endregion

    }
}
