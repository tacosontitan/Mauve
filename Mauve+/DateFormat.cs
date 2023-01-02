using System;

using Mauve.Extensibility;

namespace Mauve
{
    /// <summary>
    /// Represents a <see cref="DateFormat"/> for creating <see cref="string"/> representations of <see cref="DateTime"/> instances.
    /// </summary>
    public enum DateFormat
    {
        /// <summary>
        /// No format specified.
        /// </summary>
        /// <remarks>Calls to <see cref="DateTimeExtensions.Format(DateTime, DateFormat)"/> will simply invoke <see cref="DateTime.ToString()"/>.</remarks>
        None = 0,
        /// <summary>
        /// ISO 8601 is an international standard covering the worldwide exchange and communication of date and time-related data.
        /// </summary>
        /// <remarks>Calls to <see cref="DateTimeExtensions.Format(DateTime, DateFormat)"/> will use the format: <c>yyyy-MM-ddTHH:mm:ss.ffK</c>.</remarks>
        /// <see href="https://en.wikipedia.org/wiki/ISO_8601"/>
        Iso8601 = 1,
        /// <summary>
        /// RFC 3339 deviates from ISO 8601 in allowing a zero time zone offset to be specified as "-00:00", which ISO 8601 forbids.
        /// </summary>
        /// <remarks>Calls to <see cref="DateTimeExtensions.Format(DateTime, DateFormat)"/> will use the format: <c>yyyy-MM-dd'T'HH:mm:ss.fffK</c>.</remarks>
        /// <see href="https://en.wikipedia.org/wiki/ISO_8601#RFCs"/>
        Rfc3339 = 2,
        /// <summary>
        /// The number of milliseconds that have elapsed since the Unix epoch, excluding leap seconds. The Unix epoch is 00:00:00 UTC on 1 January 1970.
        /// </summary>
        UnixMilliseconds = 3,
        /// <summary>
        /// Defines a date that is combined with a time of day with fractional seconds that is based on a 24-hour clock.
        /// </summary>
        /// <remarks>Calls to <see cref="DateTimeExtensions.Format(DateTime, DateFormat)"/> will use the format: <c>yyyy-MM-dd HH:mm:ss.fff</c>.</remarks>
        /// <see href="https://learn.microsoft.com/en-us/sql/t-sql/functions/date-and-time-data-types-and-functions-transact-sql?view=sql-server-ver16"/>
        MsSql = 4
    }
}
