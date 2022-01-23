using System;
using System.Collections.Generic;
using System.Text;

namespace Race_Manager.DataProcessing.NMEA
{
    /// <summary>
    /// Indicates a message that contains a latitude and longitude value
    /// </summary>
    public interface IGeographicLocation
    {
        /// <summary>
        /// Gets the latitude component of the location
        /// </summary>
        double Latitude { get; }
        string LatitudeVal { get; }
        string LatitudeCard { get; }

        /// <summary>
        /// Gets the longitude component of the location
        /// </summary>
        double Longitude { get; }
        string LongitudeVal { get; }
        string LongitudeCard { get; }
    }
}
