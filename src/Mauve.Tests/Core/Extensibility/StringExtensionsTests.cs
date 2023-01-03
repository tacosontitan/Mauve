using Mauve.Extensibility;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Extensibility
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        [DataRow("this-is-a-test", "THIS-IS-A-TEST", false, false)]
        [DataRow("this-is-a-test", "THIS-IS-A-TEST", true, true)]
        [DataRow("this-is-a-test", null, true, false)]
        [DataRow(null, "THIS-IS-A-TEST", true, false)]
        [DataRow(null, null, true, false)]
        public void EqualsTest(string first, string second, bool ignoreCase, bool expected)
        {
            bool result = first.Equals(second, ignoreCase);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [DataRow("this-is-a-test", "TEST", false, false)]
        [DataRow("this-is-a-test", "TEST", true, true)]
        [DataRow("this-is-a-test", null, true, false)]
        [DataRow(null, "THIS-IS-A-TEST", true, false)]
        [DataRow(null, null, true, false)]
        public void ContainsTest(string first, string second, bool ignoreCase, bool expected)
        {
            bool result = first.Contains(second, ignoreCase);
            Assert.AreEqual(expected, result);
        }
    }
}
