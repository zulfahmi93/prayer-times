namespace Zool.Pray.Models
{
    /// <summary>
    ///     Represents the point of a location on this earth.
    /// </summary>
    public class Geocoordinate
    {
        #region Constructors

        /// <summary>
        ///     Create new <see cref="Geocoordinate" />.
        /// </summary>
        public Geocoordinate(double latitude, double longitude, double altitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        #endregion


        #region Properties

        /// <summary>
        ///     Gets the latitude of this coordinate.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        ///     Gets the longitude of this coordinate.
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        ///     Gets the altitude of this coordinate.
        /// </summary>
        public double Altitude { get; }

        #endregion
    }
}
