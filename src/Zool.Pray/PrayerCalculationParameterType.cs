using System.ComponentModel.DataAnnotations;


namespace Zool.Pray
{
    /// <summary>
    ///     Represents the type of prayer times calculation parameter.
    /// </summary>
    public enum PrayerCalculationParameterType
    {
        /// <summary>
        ///     Represents parameter which uses minute adjustment.
        /// </summary>
        [Display(Name = "Minutes Adjustment")]
        MinutesAdjust,

        /// <summary>
        ///     Represents parameter which calculate prayer time using angle value.
        /// </summary>
        [Display(Name = "Angle")]
        Angle
    }
}
