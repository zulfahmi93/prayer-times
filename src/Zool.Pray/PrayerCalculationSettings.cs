using System.ComponentModel.DataAnnotations;


namespace Zool.Pray
{
    /// <summary>
    ///     Provides properties for holding information used for calculating prayer times. Provides method for searching prayer times calculation settings from given
    ///     location information.
    /// </summary>
    public class PrayerCalculationSettings
    {
        #region Constructors

        /// <summary>
        ///     Create a new instance of <see cref="PrayerCalculationSettings" /> object.
        /// </summary>
        public PrayerCalculationSettings()
        {
            ImsakParameter = new PrayerCalculationParameter(-10.0, PrayerCalculationParameterType.MinutesAdjust);
            CalculationMethod = new CalculationMethod();
            JuristicMethod = new JuristicMethod();
            HighLatitudeAdjustment = HighLatitudeAdjustment.None;
        }

        #endregion


        #region Properties

        /// <summary>
        ///     Gets or sets the calculation parameter for imsak prayer.
        /// </summary>
        [Display(Name = "Imsak Calculation Parameter")]
        public PrayerCalculationParameter ImsakParameter { get; set; }

        /// <summary>
        ///     Gets or sets the calculation method for calculating fajr, maghrib and isha prayers.
        /// </summary>
        [Display(Name = "Calculation Method")]
        public CalculationMethod CalculationMethod { get; set; }

        /// <summary>
        ///     Gets or sets the juristic method for calculating asr prayer.
        /// </summary>
        [Display(Name = "Juristic Method")]
        public JuristicMethod JuristicMethod { get; set; }

        /// <summary>
        ///     Gets or sets high latitude adjustment method for adjusting imsak, fajr, maghrib and isha prayer times at a high latitude location.
        /// </summary>
        [Display(Name = "High Latitude Adjustment")]
        public HighLatitudeAdjustment HighLatitudeAdjustment { get; set; }

        /// <summary>
        ///     Gets or sets the minute adjustment parameter for imsak prayer.
        /// </summary>
        [Display(Name = "Imsak Adjustment")]
        public int ImsakMinutesAdjustment { get; set; }

        /// <summary>
        ///     Gets or sets the minute adjustment parameter for  prayer.
        /// </summary>
        [Display(Name = "Fajr Adjustment")]
        public int FajrMinutesAdjustment { get; set; }

        /// <summary>
        ///     Gets or sets the minute adjustment parameter for sunrise prayer.
        /// </summary>
        [Display(Name = "Sunrise Adjustment")]
        public int SunriseMinutesAdjustment { get; set; }

        /// <summary>
        ///     Gets or sets the minute adjustment parameter for dhuha prayer.
        /// </summary>
        [Display(Name = "Dhuha Adjustment")]
        public int DhuhaMinutesAdjustment { get; set; }

        /// <summary>
        ///     Gets or sets the minute adjustment parameter for dhuhr prayer.
        /// </summary>
        [Display(Name = "Zuhr Adjustment")]
        public int DhuhrMinutesAdjustment { get; set; }

        /// <summary>
        ///     Gets or sets the minute adjustment parameter for asr prayer.
        /// </summary>
        [Display(Name = "Asr Adjustment")]
        public int AsrMinutesAdjustment { get; set; }

        /// <summary>
        ///     Gets or sets the minute adjustment parameter for maghrib prayer.
        /// </summary>
        [Display(Name = "Maghrib Adjustment")]
        public int MaghribMinutesAdjustment { get; set; }

        /// <summary>
        ///     Gets or sets the minute adjustment parameter for isha prayer.
        /// </summary>
        [Display(Name = "Isha Adjustment")]
        public int IshaMinutesAdjustment { get; set; }

        #endregion
    }
}
