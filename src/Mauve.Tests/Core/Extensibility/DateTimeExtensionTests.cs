using System;

using Mauve.Extensibility;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Extensibility
{
    [TestClass]
    public class DateTimeExtensionTests
    {
        [TestMethod()]
        [DataRow(DateFormat.Iso8601, "1592-03-14T03:14:15.92Z")] // yyyy-MM-ddTHH:mm:ss.ffK
        [DataRow(DateFormat.Rfc3339, "1592-03-14T03:14:15.926Z")] // yyyy-MM-dd'T'HH:mm:ss.fffK
        [DataRow(DateFormat.MsSql, "1592-03-14 03:14:15.926")] // yyyy-MM-dd HH:mm:ss.fff
        [DataRow(DateFormat.UnixMilliseconds, "-11922237944074")]
        public void FormatTest(DateFormat format, string expectedResult)
        {
            // Set the test date to 3/14/1592 3:14:15.926.
            var testDate = new DateTime(1592, 3, 14, 3, 14, 15, 926, DateTimeKind.Utc);
            string result = testDate.ToString(format);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
