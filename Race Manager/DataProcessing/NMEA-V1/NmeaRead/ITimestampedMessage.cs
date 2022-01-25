using System;
using System.Collections.Generic;
using System.Text;

namespace RaceManager.DataProcessing.NMEA.NmeaRead
{
    /// <summary>
    /// Indicates this message has a time stamp
    /// </summary>
    public interface ITimestampedMessage
    {
        /// <summary>
        /// Gets the time of day for the message
        /// </summary>
        TimeSpan Timestamp { get; }
    }
}
