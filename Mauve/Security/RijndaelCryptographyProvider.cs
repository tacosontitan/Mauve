using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using Mauve.Extensibility;
using Mauve.Serialization;

namespace Mauve.Security
{
    /// <summary>
    /// Represents a <see cref="CryptographyProvider"/> providing simplified access to the managed version of the <see cref="Rijndael"/> algorithm.
    /// </summary>
    /// <inheritdoc/>
    public class RijndaelCryptographyProvider : CryptographyProvider
    {

        #region Fields

        private ICryptoTransform _encryptionTransform;
        private ICryptoTransform _decryptionTransform;
        private RijndaelManaged _managedRijndael;

        #endregion

        #region Properties

        /// <summary>
        /// Specifies whether or not the <see cref="InitializationVector"/> should be appended to the output stream.
        /// </summary>
        public bool AppendIv { get; set; }
        /// <summary>
        /// The encoding that is used during the encryption and decryption process.
        /// </summary>
        public Encoding Encoding { get; private set; }
        /// <summary>
        /// The initialization vector for the symmetric algorithm.
        /// </summary>
        public byte[] InitializationVector { get; private set; }
        /// <summary>
        /// The secret key to be utilized by the symmetric algorithm to encrypt and decrypt data.
        /// </summary>
        public byte[] Key { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="RijndaelCryptographyProvider"/> using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/>, <see cref="PaddingMode.PKCS7"/>, and randomly generated symmetric algorithm parameters.
        /// </summary>
        /// <inheritdoc/>
        public RijndaelCryptographyProvider() :
            this(key: null, string.Empty, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// reates a new instance of the <see cref="RijndaelCryptographyProvider"/> using <see cref="CipherMode.CBC"/>, <see cref="PaddingMode.PKCS7"/>, and the specified <see cref="System.Text.Encoding"/> along with randomly generated symmetric algorithm parameters.
        /// </summary>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        public RijndaelCryptographyProvider(Encoding encoding) :
            this(key: null, string.Empty, encoding, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// reates a new instance of the <see cref="RijndaelCryptographyProvider"/> using <see cref="Encoding.Unicode"/>, <see cref="PaddingMode.PKCS7"/>, and the specified <see cref="CipherMode"/> along with randomly generated symmetric algorithm parameters.
        /// </summary>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(CipherMode cipherMode) :
            this(key: null, string.Empty, Encoding.Unicode, cipherMode, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/>, and the specified <see cref="PaddingMode"/> along with randomly generated symmetric algorithm parameters.
        /// </summary>
        /// <param name="paddingMode">The <see cref="PaddingMode"/> used in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(PaddingMode paddingMode) :
            this(key: null, string.Empty, Encoding.Unicode, CipherMode.CBC, paddingMode)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using <see cref="Encoding.Unicode"/>, the specified <see cref="CipherMode"/> and <see cref="PaddingMode"/> along with randomly generated symmetric algorithm parameters.
        /// </summary>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        /// <param name="paddingMode">The <see cref="PaddingMode"/> used in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(CipherMode cipherMode, PaddingMode paddingMode) :
            this(key: null, string.Empty, Encoding.Unicode, cipherMode, paddingMode)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using <see cref="CipherMode.CBC"/> the specified <see cref="System.Text.Encoding"/> and <see cref="PaddingMode"/> along with randomly generated symmetric algorithm parameters.
        /// </summary>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="paddingMode">The <see cref="PaddingMode"/> used in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(Encoding encoding, PaddingMode paddingMode) :
            this(key: null, string.Empty, encoding, CipherMode.CBC, paddingMode)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using <see cref="PaddingMode.PKCS7"/>, the specified <see cref="System.Text.Encoding"/> and <see cref="CipherMode"/> along with randomly generated symmetric algorithm parameters.
        /// </summary>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(Encoding encoding, CipherMode cipherMode) :
            this(key: null, string.Empty, encoding, cipherMode, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified <see cref="System.Text.Encoding"/>, <see cref="CipherMode"/>, and <see cref="PaddingMode"/> along with randomly generated symmetric algorithm parameters.
        /// </summary>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        /// <param name="paddingMode">The <see cref="PaddingMode"/> used in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(Encoding encoding, CipherMode cipherMode, PaddingMode paddingMode) :
            this(key: null, string.Empty, encoding, cipherMode, paddingMode)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters and a randomly generated initialization vector while using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="key"></param>
        public RijndaelCryptographyProvider(byte[] key) :
            this(key, string.Empty, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(byte[] key, byte[] initializationVector) :
            this(key, initializationVector, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(byte[] key, string initializationVector) :
            this(key, initializationVector, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        public RijndaelCryptographyProvider(byte[] key, byte[] initializationVector, Encoding encoding) :
            this(key, initializationVector, encoding, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        public RijndaelCryptographyProvider(byte[] key, string initializationVector, Encoding encoding) :
            this(key, initializationVector, encoding, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(byte[] key, byte[] initializationVector, Encoding encoding, CipherMode cipherMode) :
            this(key, initializationVector, encoding, cipherMode, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(byte[] key, string initializationVector, Encoding encoding, CipherMode cipherMode) :
            this(key, initializationVector, encoding, cipherMode, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        /// <param name="paddingMode">The <see cref="PaddingMode"/> used in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(byte[] key, string initializationVector, Encoding encoding, CipherMode cipherMode, PaddingMode paddingMode) :
            this(key, string.IsNullOrWhiteSpace(initializationVector) ? null : encoding.GetBytes(initializationVector), encoding, cipherMode, paddingMode)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        /// <param name="paddingMode">The <see cref="PaddingMode"/> used in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(byte[] key, byte[] initializationVector, Encoding encoding, CipherMode cipherMode, PaddingMode paddingMode) =>
            Initialize(key, initializationVector, encoding, cipherMode, paddingMode);
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters and a randomly generated initialization vector while using 32 pseudo-generated bytes for the key, <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password) :
            this(password, salt: string.Empty, 32, initializationVector: string.Empty, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters and a randomly generated initialization vector while using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        public RijndaelCryptographyProvider(string password, int pseudoByteCount) :
            this(password, salt: string.Empty, pseudoByteCount, initializationVector: string.Empty, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, int pseudoByteCount, byte[] initializationVector) :
            this(password, null, pseudoByteCount, initializationVector, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, int pseudoByteCount, string initializationVector) :
            this(password, null, pseudoByteCount, initializationVector, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        public RijndaelCryptographyProvider(string password, int pseudoByteCount, byte[] initializationVector, Encoding encoding) :
            this(password, null, pseudoByteCount, initializationVector, encoding, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        public RijndaelCryptographyProvider(string password, int pseudoByteCount, string initializationVector, Encoding encoding) :
            this(password, null, pseudoByteCount, initializationVector, encoding, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, int pseudoByteCount, byte[] initializationVector, Encoding encoding, CipherMode cipherMode) :
            this(password, null, pseudoByteCount, initializationVector, encoding, cipherMode, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, int pseudoByteCount, string initializationVector, Encoding encoding, CipherMode cipherMode) :
            this(password, null, pseudoByteCount, initializationVector, encoding, cipherMode, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        /// <param name="paddingMode">The <see cref="PaddingMode"/> used in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, int pseudoByteCount, byte[] initializationVector, Encoding encoding, CipherMode cipherMode, PaddingMode paddingMode) :
            this(password, null, pseudoByteCount, initializationVector, encoding, cipherMode, paddingMode)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        /// <param name="paddingMode">The <see cref="PaddingMode"/> used in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, int pseudoByteCount, string initializationVector, Encoding encoding, CipherMode cipherMode, PaddingMode paddingMode) :
            this(password, null, pseudoByteCount, initializationVector, encoding, cipherMode, paddingMode)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters and a randomly generated initialization vector while using 32 pseudo-generated bytes for the key, <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, byte[] salt) :
            this(password, salt, 32, null, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters and a randomly generated initialization vector while using 32 pseudo-generated bytes for the key, <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, string salt) :
            this(password, salt, 32, null, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters and a randomly generated initialization vector while using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        public RijndaelCryptographyProvider(string password, byte[] salt, int pseudoByteCount) :
            this(password, salt, pseudoByteCount, null, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters and a randomly generated initialization vector while using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        public RijndaelCryptographyProvider(string password, string salt, int pseudoByteCount) :
            this(password, salt, pseudoByteCount, null, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, byte[] salt, int pseudoByteCount, byte[] initializationVector) :
            this(password, salt, pseudoByteCount, initializationVector, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="Encoding.Unicode"/>, <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, string salt, int pseudoByteCount, string initializationVector) :
            this(password, salt, pseudoByteCount, initializationVector, Encoding.Unicode, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        public RijndaelCryptographyProvider(string password, byte[] salt, int pseudoByteCount, byte[] initializationVector, Encoding encoding) :
            this(password, salt, pseudoByteCount, initializationVector, encoding, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="CipherMode.CBC"/> and <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        public RijndaelCryptographyProvider(string password, string salt, int pseudoByteCount, string initializationVector, Encoding encoding) :
            this(password, salt, pseudoByteCount, initializationVector, encoding, CipherMode.CBC, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, byte[] salt, int pseudoByteCount, byte[] initializationVector, Encoding encoding, CipherMode cipherMode) :
            this(password, salt, pseudoByteCount, initializationVector, encoding, cipherMode, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters while using <see cref="PaddingMode.PKCS7"/>.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, string salt, int pseudoByteCount, string initializationVector, Encoding encoding, CipherMode cipherMode) :
            this(password, salt, pseudoByteCount, initializationVector, encoding, cipherMode, PaddingMode.PKCS7)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        /// <param name="paddingMode">The <see cref="PaddingMode"/> used in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, string salt, int pseudoByteCount, string initializationVector, Encoding encoding, CipherMode cipherMode, PaddingMode paddingMode) :
            this(password,
                 salt: string.IsNullOrWhiteSpace(salt) ? null : encoding.GetBytes(salt),
                 pseudoByteCount,
                 initializationVector: string.IsNullOrWhiteSpace(initializationVector) ? null : encoding.GetBytes(initializationVector),
                 encoding,
                 cipherMode,
                 paddingMode)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="RijndaelCryptographyProvider"/> using the specified parameters.
        /// </summary>
        /// <param name="password">The password used to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="salt">The salt used in conjunction with the password to generate a secret key for use in the symmetric algorithm.</param>
        /// <param name="pseudoByteCount">The number of pseudo-random bytes the key should contain.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        /// <param name="paddingMode">The <see cref="PaddingMode"/> used in the symmetric algorithm.</param>
        public RijndaelCryptographyProvider(string password, byte[] salt, int pseudoByteCount, byte[] initializationVector, Encoding encoding, CipherMode cipherMode, PaddingMode paddingMode)
        {
            using (var pdb = new PasswordDeriveBytes(password, salt))
                Initialize(pdb.GetBytes(pseudoByteCount), initializationVector, encoding, cipherMode, paddingMode);
        }

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public override void Dispose()
        {
            _decryptionTransform.Dispose();
            _encryptionTransform.Dispose();
            _managedRijndael.Dispose();
        }
        /// <inheritdoc/>
        public override T Decrypt<T>(string input)
        {
            string decryptedData = string.Empty;
            byte[] encodedData = Convert.FromBase64String(input);
            using (var memoryStream = new MemoryStream(encodedData))
            {
                // Read the initialization vector from the stream.
                byte[] iv = new byte[16];
                int offset = 0;
                while (offset < iv.Length)
                    offset += memoryStream.Read(iv, offset, iv.Length - offset);

                // Set the initialization vector and key.
                using (var cryptoStream = new CryptoStream(memoryStream, _managedRijndael.CreateDecryptor(Key, iv), CryptoStreamMode.Read))
                using (var streamReader = new StreamReader(cryptoStream, Encoding))
                    decryptedData = streamReader.ReadToEnd();
            }

            return decryptedData.Deserialize<T>(SerializationMethod.Json);
        }
        /// <inheritdoc/>
        public override string Encrypt<T>(T input)
        {
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(InitializationVector, 0, InitializationVector.Length);
                using (var cryptoStream = new CryptoStream(memoryStream, _encryptionTransform, CryptoStreamMode.Write))
                {
                    // Get the raw data and write it to the stream.
                    string serializedData = input.Serialize(SerializationMethod.Json);
                    using (var streamWriter = new StreamWriter(cryptoStream, Encoding))
                        streamWriter.Write(serializedData);

                    // Capture the result and return it to the consumer.
                    byte[] encryptedData = memoryStream.ToArray();
                    return Convert.ToBase64String(encryptedData);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes the <see cref="RijndaelCryptographyProvider"/>.
        /// </summary>
        /// <param name="key">The secret key to be utilized by the symmetric algorithm to encrypt and decrypt data.</param>
        /// <param name="initializationVector">The initialization vector for the symmetric algorithm.</param>
        /// <param name="encoding">The encoding that is used during the encryption and decryption process.</param>
        /// <param name="cipherMode">The <see cref="CipherMode"/> for operation of the symmetric algorithm.</param>
        private void Initialize(byte[] key, byte[] initializationVector, Encoding encoding, CipherMode cipherMode, PaddingMode paddingMode)
        {
            Encoding = encoding;
            _managedRijndael = new RijndaelManaged
            {
                Mode = cipherMode,
                Padding = paddingMode,
            };

            // If we need a key, generate it.
            if (key is null)
                _managedRijndael.GenerateKey();
            else
                _managedRijndael.Key = key;

            // If we need an initialization vector, generate it.
            if (initializationVector is null)
                _managedRijndael.GenerateIV();
            else
                _managedRijndael.IV = initializationVector;

            // Set the stored key and initialization vector.
            Key = key ?? _managedRijndael.Key;
            InitializationVector = initializationVector ?? _managedRijndael.IV;

            // Create the encryption and decryption transforms.
            _encryptionTransform = _managedRijndael.CreateEncryptor(Key, InitializationVector);
            _decryptionTransform = _managedRijndael.CreateDecryptor(Key, InitializationVector);

            // Utilize unicode as the default encoding.
            Encoding = Encoding.Unicode;
        }

        #endregion

    }
}
