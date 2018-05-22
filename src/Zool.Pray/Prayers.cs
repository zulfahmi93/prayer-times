using NodaTime;

using Zool.Pray.Models;


namespace Zool.Pray
{
    /// <summary>
    ///     Prayer times data for a single day.
    /// </summary>
    public class Prayers
    {
        #region Constructors

        /// <summary>
        ///     Create new <see cref="Prayers" />.
        /// </summary>
        public Prayers(Instant imsak,
                       Instant fajr,
                       Instant sunrise,
                       Instant dhuha,
                       Instant dhuhr,
                       Instant asr,
                       Instant sunset,
                       Instant maghrib,
                       Instant isha,
                       Instant midnight)
        {
            Imsak = imsak;
            Fajr = fajr;
            Sunrise = sunrise;
            Dhuha = dhuha;
            Dhuhr = dhuhr;
            Asr = asr;
            Sunset = sunset;
            Maghrib = maghrib;
            Isha = isha;
            Midnight = midnight;
        }

        #endregion


        #region Properties

        /// <summary>
        ///     Gets the imsak prayer time.
        /// </summary>
        public Instant Imsak { get; }

        /// <summary>
        ///     Gets the fajr prayer time.
        /// </summary>
        public Instant Fajr { get; }

        /// <summary>
        ///     Gets the sunrise time.
        /// </summary>
        public Instant Sunrise { get; }

        /// <summary>
        ///     Gets the dhuha prayer time.
        /// </summary>
        public Instant Dhuha { get; }

        /// <summary>
        ///     Gets the dhuhr prayer time.
        /// </summary>
        public Instant Dhuhr { get; }

        /// <summary>
        ///     Gets the asr prayer time.
        /// </summary>
        public Instant Asr { get; }

        /// <summary>
        ///     Gets the sunset time.
        /// </summary>
        public Instant Sunset { get; }

        /// <summary>
        ///     Gets the maghrib prayer time.
        /// </summary>
        public Instant Maghrib { get; }

        /// <summary>
        ///     Gets the isha prayer time.
        /// </summary>
        public Instant Isha { get; }

        /// <summary>
        ///     Gets the midnight time.
        /// </summary>
        public Instant Midnight { get; }

        #endregion


        #region Static Methods

        /// <summary>
        ///     Get prayer times for today.
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
        ///     <see cref="Prayers" /> object containing prayer times for today.
        /// </returns>
        public static Prayers Today(PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone, IClock clock)
        {
            var now = clock.GetCurrentInstant();
            return PrayerCalculator.GetPrayerTimesForOneDay(now, settings, coordinate, timeZone);
        }

        /// <summary>
        ///     Get prayer times for given date.
        /// </summary>
        /// <param name="when">
        ///     <see cref="Instant" /> value which represents the date.
        /// </param>
        /// <param name="settings">
        ///     Settings containing parameters for calculating prayer times.
        /// </param>
        /// <param name="coordinate">
        ///     Location's coordinate.
        /// </param>
        /// <param name="timeZone">
        ///     Location's time zone.
        /// </param>
        /// <returns>
        ///     <see cref="Prayers" /> object containing prayer times for given date.
        /// </returns>
        public static Prayers On(Instant when, PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone)
        {
            return PrayerCalculator.GetPrayerTimesForOneDay(when, settings, coordinate, timeZone);
        }

        #endregion
    }
}
