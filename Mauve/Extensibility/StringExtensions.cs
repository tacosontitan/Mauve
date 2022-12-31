using System;
using System.Linq;

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
            // Validate the input parameters.
            string[] inputs = new string[] { input, target };
            if (inputs.Any(string.IsNullOrWhiteSpace))
                return false;

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
            // Validate the input parameters.
            if (string.IsNullOrWhiteSpace(input))
                return default;

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
            // Validate the input parameters.
            if (string.IsNullOrWhiteSpace(input))
                return default;

            // Create a comparison type based on whether or not we should ignore case.
            StringComparison comparisonType = ignoreCase ?
                StringComparison.InvariantCultureIgnoreCase :
                StringComparison.InvariantCulture;

            // Return whether or not the input string is equal to the comparison string, with respect to the comparison type.
            return !(target is null) && input?.Equals(target, comparisonType) == true;
        }
        /// <summary>
        /// Removes specified values from the input ignoring case.
        /// </summary>
        /// <param name="input">The input string to remove values from.</param>
        /// <param name="values">The values to remove.</param>
        /// <returns>The input string with all specified values removed.</returns>
        public static string Remove(this string input, params string[] values)
        {
            // Validate the input parameters.
            if (string.IsNullOrWhiteSpace(input) || values?.Any() != true)
                return input;

            string output = input;
            foreach (string value in values)
                output = value is null
                    ? output
                    : output.Replace(value, string.Empty);

            return output;
        }
        /// <summary>
        /// Removes specified values from the input ignoring case.
        /// </summary>
        /// <param name="input">The input string to remove values from.</param>
        /// <param name="values">The values to remove.</param>
        /// <returns>The input string with all specified values removed.</returns>
        public static string Remove(this string input, params char[] values)
        {
            // Validate the input parameters.
            if (string.IsNullOrWhiteSpace(input) || values?.Any() != true)
                return input;

            string output = input;
            foreach (char value in values)
                output = output.Replace(value.ToString(), string.Empty);

            return output;
        }
        /// <summary>
        /// Removes specified values from the input ignoring case.
        /// </summary>
        /// <param name="input">The input string to remove values from.</param>
        /// <param name="ignoreCase">Should casing be respected or not?</param>
        /// <param name="values">The values to remove.</param>
        /// <returns>The input string with all specified values removed.</returns>
        public static string Remove(this string input, bool ignoreCase, params string[] values)
        {
            // Validate the input parameters.
            if (string.IsNullOrWhiteSpace(input) || values?.Any() != true)
                return input;

            string output = input;
            foreach (string value in values)
                output = value is null
                    ? output
                    : output.Replace(value, string.Empty, ignoreCase);

            return output;
        }
        /// <summary>
        /// Replaces <see cref="Lexicon"/> instances within an input string.
        /// </summary>
        /// <param name="input">The input string to replace lexicons in.</param>
        /// <param name="lexicons">The lexicons to replace.</param>
        /// <returns>Returns the input string with all present <see cref="Lexicon"/> tokens replaced with their values.</returns>
        public static string Replace(this string input, params Lexicon[] lexicons)
        {
            // Validate the input parameters.
            if (string.IsNullOrWhiteSpace(input) || lexicons?.Any() != true)
                return input;

            string result = input;
            foreach (Lexicon lexicon in lexicons)
                result = result.Replace(lexicon.Token, lexicon.Value.ToString());

            return result;
        }
        /// <summary>
        /// Replaces all instances of a specified value with another value.
        /// </summary>
        /// <param name="input">The input string to replace values in.</param>
        /// <param name="searchValue">The value to replace.</param>
        /// <param name="replacement">The value to replace the search value with.</param>
        /// <param name="ignoreCase">Should casing be respected or not?</param>
        /// <returns>The input string with all instances of the search value replaced with the specified replacement.</returns>
        public static string Replace(this string input, string searchValue, string replacement, bool ignoreCase)
        {
            // Validate the input parameters.
            string[] inputs = new string[] { input, searchValue, replacement };
            if (inputs.Any(string.IsNullOrWhiteSpace))
                return input;

            // Capture the input and the length of the search value.
            string output = input;
            int length = searchValue.Length;

            // Create a comparison type based on whether or not we should ignore case.
            StringComparison comparisonType = ignoreCase ?
                    StringComparison.InvariantCultureIgnoreCase :
                    StringComparison.InvariantCulture;

            // While we find the search value, replace it with the replacement value.
            int nextIndex;
            while ((nextIndex = input.IndexOf(searchValue, comparisonType)) >= 0)
            {
                output = output.Remove(nextIndex, length);
                output = output.Insert(nextIndex, replacement);
            }

            return output;
        }
        /// <summary>
        /// Takes the specified input from the first identified instance of a specified search value.
        /// </summary>
        /// <param name="input">The input to search.</param>
        /// <param name="ignoreCase">Should casing be ignored?</param>
        /// <param name="searchValues">The values to search for.</param>
        /// <returns>Returns the input string from the first identified search value or, the beginning of the input when no values are found.</returns>
        public static string TakeAfter(this string input, params string[] searchValues) =>
            TakeAfter(input, ignoreCase: false, searchValues);
        /// <summary>
        /// Takes the specified input from directly after the first identified instance of a specified search value.
        /// </summary>
        /// <param name="input">The input to search.</param>
        /// <param name="ignoreCase">Should casing be ignored?</param>
        /// <param name="searchValues">The values to search for.</param>
        /// <returns>Returns the input string from directly after the first identified search value or, the beginning of the input when no values are found.</returns>
        public static string TakeAfter(this string input, bool ignoreCase, params string[] searchValues)
        {
            // Validate the input parameters.
            if (string.IsNullOrWhiteSpace(input) || searchValues?.Any() != true)
                return input;

            // Determine which comparison should be used.
            StringComparison comparison = ignoreCase
                ? StringComparison.InvariantCultureIgnoreCase
                : StringComparison.InvariantCulture;

            // Search for the specified values.
            foreach (string searchValue in searchValues)
            {
                // If a specified value is found, return the input up to that value.
                int index = input.IndexOf(searchValue, comparison);
                if (index >= 0)
                {
                    int startIndex = index + searchValue.Length;
                    return startIndex > input.Length
                        ? string.Empty
                        : input.Substring(startIndex);
                }
            }

            // Return the input if no values were found.
            return input;
        }
        /// <summary>
        /// Takes the specified input from the first identified instance of a specified search value.
        /// </summary>
        /// <param name="input">The input to search.</param>
        /// <param name="ignoreCase">Should casing be ignored?</param>
        /// <param name="searchValues">The values to search for.</param>
        /// <returns>Returns the input string from the first identified search value or, the beginning of the input when no values are found.</returns>
        public static string TakeFrom(this string input, params string[] searchValues) =>
            TakeFrom(input, ignoreCase: false, searchValues);
        /// <summary>
        /// Takes the specified input from the first identified instance of a specified search value.
        /// </summary>
        /// <param name="input">The input to search.</param>
        /// <param name="ignoreCase">Should casing be ignored?</param>
        /// <param name="searchValues">The values to search for.</param>
        /// <returns>Returns the input string from the first identified search value or, the beginning of the input when no values are found.</returns>
        public static string TakeFrom(this string input, bool ignoreCase, params string[] searchValues)
        {
            // Validate the input parameters.
            if (string.IsNullOrWhiteSpace(input) || searchValues?.Any() != true)
                return input;

            // Determine which comparison should be used.
            StringComparison comparison = ignoreCase
                ? StringComparison.InvariantCultureIgnoreCase
                : StringComparison.InvariantCulture;

            // Search for the specified values.
            foreach (string searchValue in searchValues)
            {
                // If a specified value is found, return the input up to that value.
                int index = input.IndexOf(searchValue, comparison);
                if (index >= 0)
                    return input.Substring(index);
            }

            // Return the input if no values were found.
            return input;
        }
        /// <summary>
        /// Takes from the input until a specified value is found.
        /// </summary>
        /// <param name="input">The input to search.</param>
        /// <param name="searchValues">The values to search for.</param>
        /// <returns>Returns the input string up to the first identified search value or, the end of the input when no values are found.</returns>
        public static string TakeTo(this string input, params string[] searchValues) =>
            TakeTo(input, ignoreCase: false, searchValues);
        /// <summary>
        /// Takes from the input until a specified value is found.
        /// </summary>
        /// <param name="input">The input to search.</param>
        /// <param name="ignoreCase">Should casing be ignored?</param>
        /// <param name="searchValues">The values to search for.</param>
        /// <returns>Returns the input string up to the first identified search value or, the end of the input when no values are found.</returns>
        public static string TakeTo(this string input, bool ignoreCase, params string[] searchValues)
        {
            // Validate the input parameters.
            if (string.IsNullOrWhiteSpace(input) || searchValues?.Any() != true)
                return input;

            // Determine which comparison should be used.
            StringComparison comparison = ignoreCase
                ? StringComparison.InvariantCultureIgnoreCase
                : StringComparison.InvariantCulture;

            // Search for the specified values.
            foreach (string searchValue in searchValues)
            {
                // If a specified value is found, return the input up to that value.
                int index = input.IndexOf(searchValue, comparison);
                if (index >= 0)
                    return index == 0
                        ? string.Empty
                        : input.Substring(0, index - 1);
            }

            // Return the input if no values were found.
            return input;
        }
    }
}
