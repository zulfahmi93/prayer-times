using System.ComponentModel.DataAnnotations;


namespace Zool.Pray
{
    /// <summary>
    ///     Type of prayer.
    /// </summary>
    public enum PrayerType
    {
        /// <summary>
        ///     Imsak prayer type.
        /// </summary>
        [Display(Name = "Imsak")]
        Imsak,

        /// <summary>
        ///     Fajr prayer type.
        /// </summary>
        [Display(Name = "Fajr")]
        Fajr,

        /// <summary>
        ///     Sunrise prayer type.
        /// </summary>
        [Display(Name = "Sunrise")]
        Sunrise,

        /// <summary>
        ///     Dhuha prayer type.
        /// </summary>
        [Display(Name = "Dhuha")]
        Dhuha,

        /// <summary>
        ///     Dhuhr prayer type.
        /// </summary>
        [Display(Name = "Zuhr")]
        Dhuhr,

        /// <summary>
        ///     Asr prayer type.
        /// </summary>
        [Display(Name = "Asr")]
        Asr,

        /// <summary>
        ///     Maghrib prayer type.
        /// </summary>
        [Display(Name = "Maghrib")]
        Maghrib,

        /// <summary>
        ///     Isha prayer type.
        /// </summary>
        [Display(Name = "Isha")]
        Isha
    }
}
