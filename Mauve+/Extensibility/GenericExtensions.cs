
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Mauve.Math;
using Mauve.Patterns;
using Mauve.Security;
using Mauve.Serialization;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods that are applicable to all types utilizing generics for type safety.
    /// </summary>
    public static class GenericExtensions
    {

        #region Get Hash Code

        /// <summary>
        /// Gets the hash code of the input in the specified <see cref="NumericBase"/>.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <param name="input">The input to get the hash code of.</param>
        /// <param name="numericBase">The <see cref="NumericBase"/> to return the hash code in.</param>
        /// <returns>Returns the hash code of the specified input in the specified <see cref="NumericBase"/>.</returns>
        public static string GetHashCode<T>(this T input, NumericBase numericBase) =>
            GetHashCode(input, HashType.None, numericBase, Encoding.Unicode, SerializationMethod.Json);
        /// <summary>
        /// Gets the hash code of the input using <see cref="Encoding.Unicode"/> and <see cref="SerializationMethod.Json"/> along with the specified <see cref="HashType"/>.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <param name="input">The input to get the hash code of.</param>
        /// <param name="hashType">The <see cref="HashType"/> that should be used to compute the hash of the input.</param>
        /// <returns>Returns the hash code of the specified input.</returns>
        /// <remarks>Defaults to <see cref="object.GetHashCode()"/></remarks>
        public static string GetHashCode<T>(this T input, HashType hashType) =>
            GetHashCode(input, hashType, NumericBase.Hexadecimal, Encoding.Unicode, SerializationMethod.Json);
        /// <summary>
        /// Gets the hash code of the input using <see cref="SerializationMethod.Json"/> along with the specified <see cref="HashType"/> and <see cref="Encoding"/>.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <param name="input">The input to get the hash code of.</param>
        /// <param name="hashType">The <see cref="HashType"/> that should be used to compute the hash of the input.</param>
        /// <param name="encoding">The <see cref="Encoding"/> that should be used to encode the serialized input.</param>
        /// <returns>Returns the hash code of the specified input.</returns>
        /// <remarks>Defaults to <see cref="object.GetHashCode()"/></remarks>
        public static string GetHashCode<T>(this T input, HashType hashType, Encoding encoding) =>
            GetHashCode(input, hashType, NumericBase.Hexadecimal, encoding, SerializationMethod.Json);
        /// <summary>
        /// Gets the hash code of the input using <see cref="Encoding.Unicode"/> along with the specified <see cref="HashType"/> and <see cref="SerializationMethod"/>.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <param name="input">The input to get the hash code of.</param>
        /// <param name="hashType">The <see cref="HashType"/> that should be used to compute the hash of the input.</param>
        /// <param name="serializationMethod">The <see cref="SerializationMethod"/> that should be used to serialize the input prior to hashing.</param>
        /// <returns>Returns the hash code of the specified input.</returns>
        /// <remarks>Defaults to <see cref="object.GetHashCode()"/></remarks>
        public static string GetHashCode<T>(this T input, HashType hashType, SerializationMethod serializationMethod) =>
            GetHashCode(input, hashType, NumericBase.Hexadecimal, Encoding.Unicode, serializationMethod);
        /// <summary>
        /// Gets the hash code of the input using the specified <see cref="HashType"/>, <see cref="Encoding"/>, and <see cref="SerializationMethod"/>.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <param name="input">The input to get the hash code of.</param>
        /// <param name="hashType">The <see cref="HashType"/> that should be used to compute the hash of the input.</param>
        /// <param name="numericBase">The desired <see cref="NumericBase"/> of the output.</param>
        /// <param name="encoding">The <see cref="Encoding"/> that should be used to encode the serialized input.</param>
        /// <param name="serializationMethod">The <see cref="SerializationMethod"/> that should be used to serialize the input prior to hashing.</param>
        /// <returns>Returns the hash code of the specified input.</returns>
        /// <remarks>Defaults to <see cref="object.GetHashCode()"/></remarks>
        public static string GetHashCode<T>(this T input, HashType hashType, NumericBase numericBase, Encoding encoding, SerializationMethod serializationMethod)
        {
            // Serialize the input and determine the hashing algorithm to use.
            string serializedInput = input.Serialize(serializationMethod);
            HashAlgorithm hashAlgorithm = null;
            switch (hashType)
            {
                case HashType.Md5: hashAlgorithm = new MD5CryptoServiceProvider(); break;
                case HashType.Sha256: hashAlgorithm = new SHA256CryptoServiceProvider(); break;
                case HashType.Sha384: hashAlgorithm = new SHA384CryptoServiceProvider(); break;
                case HashType.Sha512: hashAlgorithm = new SHA512CryptoServiceProvider(); break;
            }

            // Create a variable for storing the result.
            string result;

            // Compute the hash and convert it to hexadecimal.
            if (hashAlgorithm is null)
                result = serializedInput.GetHashCode().ToString("x");
            else
            {
                byte[] data = encoding.GetBytes(serializedInput);
                byte[] hash = hashAlgorithm.ComputeHash(data);
                result = BitConverter.ToString(hash).Replace("-", "").ToLower();
            }

            // If the desired base is hexadecimal, we're done.
            if (numericBase.Equals(NumericBase.Hexadecimal))
                return result;

            // If a different base was specified, then convert to it and return the result.
            var converter = new NumericBaseConverter();
            return converter.Convert(result, NumericBase.Hexadecimal, numericBase);
        }

        #endregion

        #region In

        /// <summary>
        /// Determines if a specified value is present in a specified collection using a specified equality comparer.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data in the collection.</typeparam>
        /// <param name="input">The value to search the collection for.</param>
        /// <param name="collection">The collection to look through.</param>
        /// <returns><see langword="true"/> if the specified collection contains the specified input, otherwise <see langword="false"/>.</returns>
        public static bool In<T>(this T input, params T[] collection) =>
            collection?.Any(a => a.Equals(input)) == true;
        /// <summary>
        /// Determines if a specified value is present in a specified collection using a specified equality comparer.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data in the collection.</typeparam>
        /// <param name="input">The value to search the collection for.</param>
        /// <param name="equalityComparer">The comparer that should be used to check equality.</param>
        /// <param name="collection">The collection to look through.</param>
        /// <returns><see langword="true"/> if the specified collection contains the specified input, otherwise <see langword="false"/>.</returns>
        public static bool In<T>(this T input, IEqualityComparer<T> equalityComparer, params T[] collection) =>
            collection?.Any(a => equalityComparer.Equals(a, input)) == true;

        #endregion

        #region Other Methods

        /// <summary>
        /// Translates the specified input to a specified output type using a <see cref="BasicAdapter{T1, T2}"/>.
        /// </summary>
        /// <typeparam name="TIn">Specifies the type of input.</typeparam>
        /// <typeparam name="TOut">Specifies the type of output expected.</typeparam>
        /// <param name="input">The input to translate.</param>
        /// <returns>Returns the input translated to the specified output type.</returns>
        public static TOut Translate<TIn, TOut>(this TIn input) =>
            Translate(input, new BasicAdapter<TIn, TOut>());
        /// <summary>
        /// Translates the specified input to a specified output type using a specified <see cref="IAdapter{T1, T2}"/>.
        /// </summary>
        /// <typeparam name="TIn">Specifies the type of input.</typeparam>
        /// <typeparam name="TOut">Specifies the type of output expected.</typeparam>
        /// <param name="input">The input to translate.</param>
        /// <param name="adapter">The adapter to perform the translation with.</param>
        /// <returns>Returns the input translated to the specified output type.</returns>
        public static TOut Translate<TIn, TOut>(this TIn input, IAdapter<TIn, TOut> adapter) =>
            adapter.Convert(input);
        /// <summary>
        /// Translates the specified input to a specified output type using a specified <see cref="IAdapter{T1, T2}"/>.
        /// </summary>
        /// <typeparam name="TIn">Specifies the type of input.</typeparam>
        /// <typeparam name="TOut">Specifies the type of output expected.</typeparam>
        /// <param name="input">The input to translate.</param>
        /// <param name="adapter">The adapter to perform the translation with.</param>
        /// <returns>Returns the input translated to the specified output type.</returns>
        public static TOut Translate<TIn, TOut>(this TIn input, IAdapter<TOut, TIn> adapter) =>
            adapter.Convert(input);
        /// <summary>
        /// Serializes the current state of the specified input utilizing the specified <see cref="SerializationMethod"/>.
        /// </summary>
        /// <typeparam name="T">The type of the data to be serialized.</typeparam>
        /// <param name="input">The data to be serialized.</param>
        /// <param name="serializationMethod">The <see cref="SerializationMethod"/> that should be utilized for serialization.</param>
        /// <returns>Returns the input data serialized using the specified <see cref="SerializationMethod"/>.</returns>
        public static string Serialize<T>(this T input, SerializationMethod serializationMethod)
        {
            SerializationProvider serializationProvider = serializationMethod switch
            {
                SerializationMethod.Binary => new BinarySerializationProvider(),
                SerializationMethod.Xml => new XmlSerializationProvider(),
                SerializationMethod.Json => new JsonSerializationProvider(),
                SerializationMethod.Yaml => new YamlSerializationProvider(),
                _ => new RawSerializationProvider(),
            };
            return serializationProvider.Serialize(input);
        }

        #endregion

    }
}
