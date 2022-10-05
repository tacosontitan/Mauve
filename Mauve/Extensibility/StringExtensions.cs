using System;

using Mauve.Serialization;
using Mauve.Text;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods for <see cref="string"/> instances.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks whether this string contains an input string. A parameter specifies if case should be ignored.
        /// </summary>
        /// <param name="input">The input string used to check.</param>
        /// <param name="target">The target to search for within the input string.</param>
        /// <param name="ignoreCase">Should character case be ignored?</param>
        /// <returns>Returns <see langword="true"/> if the <c>input</c> contains the <c>target</c>, with respect to the <c>ignoreCase</c> specification, otherwise <see langword="false"/>.</returns>
        public static bool Contains(this string input, string target, bool ignoreCase)
        {
            // Create a comparison type based on whether or not we should ignore case.
            StringComparison comparisonType = ignoreCase ?
                StringComparison.InvariantCultureIgnoreCase :
                StringComparison.InvariantCulture;

            // Return whether or not the input string contains comparison string, with respect to the comparison type.
            return !(target is null) && input?.IndexOf(target, comparisonType) >= 0;
        }
        /// <summary>
        /// Deserializes the specified input utilizing the specified <see cref="SerializationMethod"/>.
        /// </summary>
        /// <typeparam name="T">The type of the data to be deserialized.</typeparam>
        /// <param name="input">The serialized data to be deserialized.</param>
        /// <param name="serializationMethod">The <see cref="SerializationMethod"/> that should be utilized for deserialization.</param>
        /// <returns>Returns the input deserialized using the specified <see cref="SerializationMethod"/>.</returns>
        public static T Deserialize<T>(this string input, SerializationMethod serializationMethod)
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

            return serializationProvider.Deserialize<T>(input);
        }
        /// <summary>
        /// Checks whether this string and an input string have the same value. A parameter specifies if case should be ignored.
        /// </summary>
        /// <param name="input">The input string used to check equality with.</param>
        /// <param name="target">The target of the equality check.</param>
        /// <param name="ignoreCase">Should character case be ignored?</param>
        /// <returns>Returns <see langword="true"/> if the <c>input</c> and <c>target</c>, are equal, with respect to the <c>ignoreCase</c> specification, otherwise <see langword="false"/>.</returns>
        public static bool Equals(this string input, string target, bool ignoreCase)
        {
            // Create a comparison type based on whether or not we should ignore case.
            StringComparison comparisonType = ignoreCase ?
                StringComparison.InvariantCultureIgnoreCase :
                StringComparison.InvariantCulture;

            // Return whether or not the input string is equal to the comparison string, with respect to the comparison type.
            return input?.Equals(target, comparisonType) == true;
        }
        /// <summary>
        /// Replaces <see cref="Lexicon"/> instances within an input string.
        /// </summary>
        /// <param name="input">The input string to replace lexicons in.</param>
        /// <param name="lexicons">The lexicons to replace.</param>
        /// <returns>Returns the input string with all present <see cref="Lexicon"/> tokens replaced with their values.</returns>
        public static string Replace(this string input, params Lexicon[] lexicons)
        {
            string result = input;
            foreach (Lexicon lexicon in lexicons)
                result = result.Replace(lexicon.Token, lexicon.Value.ToString());

            return result;
        }
    }
}
