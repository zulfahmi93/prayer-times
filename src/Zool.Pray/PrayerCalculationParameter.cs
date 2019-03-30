using System.ComponentModel.DataAnnotations;


namespace Zool.Pray
{
    /// <summary>
    ///     Holds the calculation parameter used for prayer times calculation.
    /// </summary>
    public class PrayerCalculationParameter
    {
        #region Constructors

        /// <summary>
        ///     Create new <see cref="PrayerCalculationParameter" />.
        /// </summary>
        public PrayerCalculationParameter(double value, PrayerCalculationParameterType type)
        {
            Value = value;
            Type = type;
        }

        #endregion


        #region Properties

        /// <summary>
        ///     Gets the value of the prayer times calculation parameter.
        /// </summary>
        [Display(Name = "Calculation Value")]
        public double Value { get; internal set; }

        /// <summary>
        ///     Gets the type of the prayer times calculation parameter.
        /// </summary>
        [Display(Name = "Calculation Parameter Type")]
        public PrayerCalculationParameterType Type { get; internal set; }

        #endregion
    }
}
