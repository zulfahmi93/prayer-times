using System.ComponentModel.DataAnnotations;

using NodaTime;

using Zool.Pray.Models;


namespace Zool.Pray
{
    /// <summary>
    ///     Data for a particular prayer.
    /// </summary>
    public class Prayer
    {
        #region Constructors

        /// <summary>
        ///     Create new <see cref="Prayer" />.
        /// </summary>
        public Prayer(PrayerType type, Instant time)
        {
            Type = type;
            Time = time;
        }

        #endregion


        #region Properties

        /// <summary>
        ///     Gets the type of this prayer.
        /// </summary>
        [Display(Name = "Type of Prayer")]
        public PrayerType Type { get; }

        /// <summary>
        ///     Gets the time of this prayer.
        /// </summary>
        [Display(Name = "Time of Prayer")]
        public Instant Time { get; }

        #endregion


        #region Static Methods

        /// <summary>
        ///     Get current prayer time.
        /// </summary>
        /// <param name="settings">
        ///     Settings containing parameters for calculating prayer times.
        /// </param>
        /// <param name="coordinate">
        ///     Location's coordinate.
        /// </param>
        /// <param name="timeZone">
        ///     Location's time zone.
        /// </param>
        /// <param name="clock">
        ///     <see cref="IClock" /> interface object for getting current <see cref="Instant" /> value.
        /// </param>
        /// <returns>
        ///     <see cref="Prayer" /> object containing current prayer time data.
        /// </returns>
        public static Prayer Now(PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone, IClock clock)
        {
            return PrayerCalculator.GetCurrentPrayerTime(clock, settings, coordinate, timeZone);
        }

        /// <summary>
        ///     Get next prayer time.
        /// </summary>
        /// <param name="settings">
        ///     Settings containing parameters for calculating prayer times.
        /// </param>
        /// <param name="coordinate">
        ///     Location's coordinate.
        /// </param>
        /// <param name="timeZone">
        ///     Location's time zone.
        /// </param>
        /// <param name="clock">
        ///     <see cref="IClock" /> interface object for getting current <see cref="Instant" /> value.
        /// </param>
        /// <returns>
        ///     <see cref="Prayer" /> object containing next prayer time data.
        /// </returns>
        public static Prayer Next(PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone, IClock clock)
        {
            return PrayerCalculator.GetNextPrayerTime(clock, settings, coordinate, timeZone);
        }

        /// <summary>
        ///     Get later prayer time.
        /// </summary>
        /// <param name="settings">
        ///     Settings containing parameters for calculating prayer times.
        /// </param>
        /// <param name="coordinate">
        ///     Location's coordinate.
        /// </param>
        /// <param name="timeZone">
        ///     Location's time zone.
        /// </param>
        /// <param name="clock">
        ///     <see cref="IClock" /> interface object for getting current <see cref="Instant" /> value.
        /// </param>
        /// <returns>
        ///     <see cref="Prayer" /> object containing later prayer time data.
        /// </returns>
        public static Prayer Later(PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone, IClock clock)
        {
            return PrayerCalculator.GetLaterPrayerTime(clock, settings, coordinate, timeZone);
        }

        /// <summary>
        ///     Get after later prayer time.
        /// </summary>
        /// <param name="settings">
        ///     Settings containing parameters for calculating prayer times.
        /// </param>
        /// <param name="coordinate">
        ///     Location's coordinate.
        /// </param>
        /// <param name="timeZone">
        ///     Location's time zone.
        /// </param>
        /// <param name="clock">
        ///     <see cref="IClock" /> interface object for getting current <see cref="Instant" /> value.
        /// </param>
        /// <returns>
        ///     <see cref="Prayer" /> object containing after later prayer time data.
        /// </returns>
        public static Prayer AfterLater(PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone, IClock clock)
        {
            return PrayerCalculator.GetAfterLaterPrayerTime(clock, settings, coordinate, timeZone);
        }

        #endregion
    }
}
