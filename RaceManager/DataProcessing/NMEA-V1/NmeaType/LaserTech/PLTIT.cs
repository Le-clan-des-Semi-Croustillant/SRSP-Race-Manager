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

using RaceManager.DataProcessing.NMEA.NmeaRead;

namespace RaceManager.DataProcessing.NMEA.NmeaType
{
    /// <summary>
    /// Laser Range 
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pltit")]
    [NmeaMessageType("PLTIT")]
    public class Pltit : LaserRangeMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pltit"/> class.
        /// </summary>
        /// <param name="type">The message type</param>
        /// <param name="message">The NMEA message values.</param>
        public Pltit(string type, string[] message) : base(type, message) { }
    }
}
