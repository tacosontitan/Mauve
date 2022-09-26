using System;

using Mauve.Extensibility;
using Mauve.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Extensibility
{
    [TestClass]
    public class DateTimeExtensionTests
    {
        [TestMethod("Test Common Formats")]
        [DataRow(DateFormat.Iso8601, 2)]
        [DataRow(DateFormat.Rfc3339, 3)]
        [DataRow(DateFormat.MsSql, 2)]
        public void CommonFormatTest(DateFormat format, int millisecondLength)
        {
            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;
            string millisecond = now.Millisecond.ToString().Substring(0, millisecondLength);
            string nowFormatted = now.ToString(format);

            // Use SubstringQueue to quickly parse the individual chunks.
            // ISO8601: yyyy-MM-ddTHH:mm:ss.ffK
            // RFC3339: yyyy-MM-dd'T'HH:mm:ss.fffK
            // MSSQL:   yyyy-MM-dd HH:mm:ss.fff
            //
            // During testing, RFC3339's 'T' value was presented as simply T which allowed to be considered a common format.
            var queue = new SubstringQueue(nowFormatted);
            queue.Next(4, out int parsedYear)
                 .Skip(1)
                 .Next(2, out int parsedMonth)
                 .Skip(1)
                 .Next(2, out int parsedDay)
                 .Skip(1) // 
                 .Next(2, out int parsedHour)
                 .Skip(1)
                 .Next(2, out int parsedMinute)
                 .Skip(1)
                 .Next(2, out int parsedSecond)
                 .Skip(1)
                 .Next(millisecondLength, out string parsedMillisecond)
                 .Remainder(out string _);

            Assert.AreEqual(year, parsedYear);
            Assert.AreEqual(month, parsedMonth);
            Assert.AreEqual(day, parsedDay);
            Assert.AreEqual(hour, parsedHour);
            Assert.AreEqual(minute, parsedMinute);
            Assert.AreEqual(second, parsedSecond);
            Assert.AreEqual(millisecond, parsedMillisecond);
        }
    }
}
