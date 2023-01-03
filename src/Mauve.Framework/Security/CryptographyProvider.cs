using System;

namespace Mauve.Security
{
    /// <summary>
    /// Represents a <see cref="CryptographyProvider"/> to be utilized for simplified encryption and decryption of data.
    /// </summary>
    public abstract class CryptographyProvider : IDisposable
    {

        #region Public Methods

        /// <summary>
        /// Disposes of the <see cref="CryptographyProvider"/> instance and its resources.
        /// </summary>
        public abstract void Dispose();
        /// <summary>
        /// Encrypts the specified data based on the current configuration.
        /// </summary>
        /// <typeparam name="T">The type of the data being encrypted.</typeparam>
        /// <param name="input">The data to encrypt.</param>
        /// <returns>Returns the data encrypted and encoded using the current configuration.</returns>
        public abstract string Encrypt<T>(T input);
        /// <summary>
        /// Decrypts the specified data based on the current configuration.
        /// </summary>
        /// <typeparam name="T">The type of the data being decrypted.</typeparam>
        /// <param name="input">The data to decrypt.</param>
        /// <returns>Returns the data decrypted using the current configuration.</returns>
        public abstract T Decrypt<T>(string input);

        #endregion

    }
}
