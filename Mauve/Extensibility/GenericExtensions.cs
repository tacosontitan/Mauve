
using System;
using System.Security.Cryptography;
using System.Text;

using Mauve.Math;
using Mauve.Security;
using Mauve.Serialization;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods that are applicable to all types utilizing generics for type safety.
    /// </summary>
    public static class GenericExtensions
    {

        #region Public Methods

        /// <summary>
        /// Gets the hash code of the input in the specified <see cref="NumericBase"/>.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <param name="input">The input to get the hash code of.</param>
        /// <param name="numericBase">The <see cref="NumericBase"/> to return the hash code in.</param>
        /// <returns>Returns the hash code of the specified input in the specified <see cref="NumericBase"/>.</returns>
        public static string GetHashCode<T>(this T input, NumericBase numericBase) =>
            input.GetHashCode().ToString(numericBase);
        /// <summary>
        /// Gets the hash code of the input using the specified <see cref="HashType"/>, <see cref="Encoding"/>, and <see cref="SerializationMethod"/>.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <param name="input">The input to get the hash code of.</param>
        /// <param name="hashType">The <see cref="HashType"/> that should be used to compute the hash of the input.</param>
        /// <param name="serializationMethod">The <see cref="SerializationMethod"/> that should be used to serialize the input prior to hashing.</param>
        /// <returns>Returns the hash code of the specified input.</returns>
        /// <remarks>Defaults to <see cref="object.GetHashCode()"/></remarks>
        public static string GetHashCode<T>(this T input, HashType hashType, Encoding encoding, SerializationMethod serializationMethod)
        {
            string serializedInput = input.Serialize(serializationMethod);
            HashAlgorithm hashAlgorithm;
            switch (hashType)
            {
                case HashType.Md5: hashAlgorithm = new MD5CryptoServiceProvider(); break;
                case HashType.Sha256: hashAlgorithm = new SHA256CryptoServiceProvider(); break;
                case HashType.Sha384: hashAlgorithm = new SHA384CryptoServiceProvider(); break;
                case HashType.Sha512: hashAlgorithm = new SHA512CryptoServiceProvider(); break;
                case HashType.RipeMd: hashAlgorithm = new RIPEMD160Managed(); break;
                default: return input.GetHashCode().ToString();
            }

            byte[] data = encoding.GetBytes(serializedInput);
            byte[] hash = hashAlgorithm.ComputeHash(data);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
        /// <summary>
        /// Serializes the current state of the specified input utilizing the specified <see cref="SerializationMethod"/>.
        /// </summary>
        /// <typeparam name="T">The type of the data to be serialized.</typeparam>
        /// <param name="input">The data to be serialized.</param>
        /// <param name="serializationMethod">The <see cref="SerializationMethod"/> that should be utilized for serialization.</param>
        /// <returns>Returns the input data serialized using the specified <see cref="SerializationMethod"/>.</returns>
        public static string Serialize<T>(this T input, SerializationMethod serializationMethod)
        {
            SerializationProvider serializationProvider;
            switch (serializationMethod)
            {
                case SerializationMethod.Binary: serializationProvider = new BinarySerializationProvider(); break;
                case SerializationMethod.Xml: serializationProvider = new XmlSerializationProvider(); break;
                case SerializationMethod.Json: serializationProvider = new JsonSerializationProvider(); break;
                case SerializationMethod.Yaml: serializationProvider = new YamlSerializationProvider(); break;
                default: serializationProvider = new RawSerializationProvider(); break;
            }

            return serializationProvider.Serialize(input);
        }

        #endregion

    }
}
