using System;

using Mauve.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Text
{
    [TestClass]
    public class SubstringQueueTests
    {

        #region Constants

        public const string TestString = "this23true3.14159test:09/15/2022";

        #endregion

        #region Tests

        /// <summary>
        /// Tests the complete parsing of the test string.
        /// </summary>
        [TestMethod("Full Parse")]
        public void FullParse()
        {
            var queue = new SubstringQueue(TestString);

            try
            {
                // Parse the first string.
                _ = queue.Next(4, out string firstString);
                Assert.AreEqual("this", firstString);

                // Parse the integer.
                _ = queue.Next(2, out int integer);
                Assert.AreEqual(23, integer);

                // Parse the boolean.
                _ = queue.Next(4, out bool boolean);
                Assert.AreEqual(true, boolean);

                // Parse PI.
                _ = queue.Next(7, out double pi);
                Assert.AreEqual(3.14159, pi);

                // Parse the second string.
                _ = queue.Next(4, out string secondString);
                Assert.AreEqual("test", secondString);

                // Skip the next character, this test doesn't use it.
                _ = queue.Skip(1);

                // Parse the date using remaining.
                queue.Remainder(out DateTime date);
                Assert.AreEqual(new DateTime(2022, 9, 15), date);
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion

    }
}
