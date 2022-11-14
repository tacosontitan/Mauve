using System;

using Mauve.Security;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Security
{
    [TestClass]
    public class RijndaelCryptographyProviderTests
    {
        [TestMethod]
        [DataRow("this is a test", false)]
        [DataRow(32, false)]
        [DataRow(23L, false)]
        [DataRow(3.14, false)]
        [DataRow(3.14f, false)]
        [DataRow(false, false)]
        public void Encryption(object input, bool expectedResult)
        {
            try
            {
                using (var rijndael = new RijndaelCryptographyProvider())
                {
                    object encryptionResult = rijndael.Encrypt(input);
                    bool result = input.Equals(encryptionResult);
                    Assert.AreEqual(expectedResult, result);
                }
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        [DataRow("this is a test", true)]
        [DataRow(32, true)]
        [DataRow(23L, true)]
        [DataRow(3.14, true)]
        [DataRow(3.14f, true)]
        [DataRow(false, true)]
        public void Decryption(object input, bool expectedResult)
        {
            try
            {
                using (var rijndael = new RijndaelCryptographyProvider())
                {
                    string encryptionResult = rijndael.Encrypt(input);
                    object decryptionResult = input is int
                            ? rijndael.Decrypt<int>(encryptionResult)
                            : rijndael.Decrypt<object>(encryptionResult);
                    bool result = input.Equals(decryptionResult);
                    Assert.AreEqual(expectedResult, result);
                }
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [TestMethod]
        [DataRow("this is a test", true)]
        [DataRow(32, true)]
        [DataRow(23L, true)]
        [DataRow(3.14, true)]
        [DataRow(3.14f, true)]
        [DataRow(false, true)]
        public void DelayedDecryption(object input, bool expectedResult)
        {
            try
            {
                byte[] iv = null;
                byte[] key = null;
                string encryptedValue = string.Empty;
                using (var rijndael = new RijndaelCryptographyProvider())
                {
                    iv = rijndael.InitializationVector;
                    key = rijndael.Key;
                    encryptedValue = rijndael.Encrypt(input);
                    Assert.AreNotEqual(input, encryptedValue);
                }

                using (var rijndael = new RijndaelCryptographyProvider(key, iv))
                {
                    object decryptionResult = input is int
                            ? rijndael.Decrypt<int>(encryptedValue)
                            : rijndael.Decrypt<object>(encryptedValue);

                    bool result = input.Equals(decryptionResult);
                    Assert.AreEqual(expectedResult, result);
                }
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
