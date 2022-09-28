using System.Runtime.Serialization.Formatters.Binary;

namespace Mauve
{
    /// <summary>
    /// Represents a <see cref="SerializationMethod"/> for the serialization and deserialization of data.
    /// </summary>
    public enum SerializationMethod
    {
        /// <summary>
        /// Represents an unspecified or unsupported serialization method.
        /// </summary>
        None = 0,
        /// <summary>
        /// Represents binary serialization which utilizes the public and private fields of the object and the name of the class, including the assembly containing the class. Binary serialization allows modifying private members inside an object and therefore changing the state of it. Because of this, other serialization frameworks, like <see href="https://www.newtonsoft.com/json">Newtonsoft.Json</see>, that operate on the public API surface are recommended. <see href="https://learn.microsoft.com/en-us/dotnet/standard/serialization/binary-serialization">Learn more</see>.
        /// </summary>
        /// <remarks>Binary serialization can be dangerous. For more information, see the <see href="https://learn.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-security-guide">security guide</see> for <see cref="BinaryFormatter"/>.</remarks>
        Binary = 1,
        /// <summary>
        /// <see href="https://en.wikipedia.org/wiki/XML">Extensible Markup Language</see> is a markup language and file format for storing, transmitting, and reconstructing arbitrary data.
        /// </summary>
        Xml = 2,
        /// <summary>
        /// JavaScript Object Notation is an open standard file format and data interchange format that uses human-readable text to store and transmit data objects consisting of attribute–value pairs and arrays (or other serializable values).
        /// </summary>
        /// <remarks>Mauve utilizes <see href="https://www.newtonsoft.com/json">Newtonsoft.Json</see> for handling JSON.</remarks>
        /// <see href="https://en.wikipedia.org/wiki/JSON"/>
        Json = 3,
        /// <summary>
        /// <see href="https://en.wikipedia.org/wiki/YAML">YAML Ain't Markup Language</see> is a human-readable data-serialization language. It is commonly used for configuration files and in applications where data is being stored or transmitted.
        /// </summary>
        Yaml = 4
    }
}
