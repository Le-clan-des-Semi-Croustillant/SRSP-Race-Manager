﻿//  *******************************************************************************
//  *  Copyright (c) 2014 Morten Nielsen
//  *  Modifications copyright (C) 2022 Sky-CSC
//  *  Licensed under the Apache License, Version 2.0 (the "License");
//  *  you may not use this file except in compliance with the License.
//  *  You may obtain a copy of the License at
//  *
//  *  http://www.apache.org/licenses/LICENSE-2.0
//  *
//  *   Unless required by applicable law or agreed to in writing, software
//  *   distributed under the License is distributed on an "AS IS" BASIS,
//  *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  *   See the License for the specific language governing permissions and
//  *   limitations under the License.
//  ******************************************************************************

using System;
using RaceManager.DataProcessing.NMEA.NmeaRead;

namespace RaceManager.DataProcessing.NMEA.NmeaType
{
    /// <summary>
    /// Geographic position, latitude / longitude.
    /// </summary>
    /// <remarks>
    /// Latitude and Longitude of vessel position, time of position fix and status.
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gll")]
    [NmeaMessageType("--GLL")]
    public class Gll : NmeaMessage, ITimestampedMessage, IGeographicLocation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gll"/> class.
        /// </summary>
        /// <param name="type">The message type</param>
        /// <param name="message">The NMEA message values.</param>
        public Gll(string type, string[] message) : base(type, message)
        {
            if (message == null || message.Length < 4)
                throw new ArgumentException("Invalid GLL", "message");
            Latitude = NmeaMessage.StringToLatitude(message[0], message[1]);
            LatitudeVal = message[0];
            LatitudeCard = message[1];
            Longitude = NmeaMessage.StringToLongitude(message[2], message[3]);
            LongitudeVal = message[2];
            LongitudeCard = message[3];
            if (message.Length >= 5) //Some older GPS doesn't broadcast fix time
            {
                FixTime = StringToTimeSpan(message[4]);
            }
            DataActive = (message.Length < 6 || message[5] == "A");
            ModeIndicator = DataActive ? Mode.Autonomous : Mode.DataNotValid;
            if (message.Length > 6)
            {
                switch (message[6])
                {
                    case "A": ModeIndicator = Mode.Autonomous; break;
                    case "D": ModeIndicator = Mode.DataNotValid; break;
                    case "E": ModeIndicator = Mode.EstimatedDeadReckoning; break;
                    case "M": ModeIndicator = Mode.Manual; break;
                    case "S": ModeIndicator = Mode.Simulator; break;
                    case "N": ModeIndicator = Mode.DataNotValid; break;
                }
            }
        }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; }
        public string LatitudeVal { get; }
        public string LatitudeCard { get; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; }
        public string LongitudeVal { get; }
        public string LongitudeCard { get; }

        /// <summary>
        /// Time since last DGPS update
        /// </summary>
        public TimeSpan FixTime { get; }

        /// <summary>
        /// Gets a value indicating whether data is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if data is active; otherwise, <c>false</c>.
        /// </value>
        public bool DataActive { get; }

        /// <summary>
        /// Positioning system Mode Indicator
        /// </summary>
        public Mode ModeIndicator { get; }

        TimeSpan ITimestampedMessage.Timestamp => FixTime;

        /// <summary>
        /// Positioning system Mode Indicator
        /// </summary>
        /// <seealso cref="Gll.ModeIndicator"/>
        public enum Mode
        {
            /// <summary>
            /// Autonomous mode
            /// </summary>
            Autonomous,
            /// <summary>
            ///  Differential mode
            /// </summary>
            Differential,
            /// <summary>
            ///  Estimated (dead reckoning) mode
            /// </summary>
            EstimatedDeadReckoning,
            /// <summary>
            /// Manual input mode
            /// </summary>
            Manual,
            /// <summary>
            /// Simulator mode
            /// </summary>
            Simulator,
            /// <summary>
            /// Data not valid
            /// </summary>
            DataNotValid
        }
    }
}
