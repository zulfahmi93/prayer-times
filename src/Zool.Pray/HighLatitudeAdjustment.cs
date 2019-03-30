using System.ComponentModel.DataAnnotations;


namespace Zool.Pray
{
    /// <summary>
    ///     Represents the high latitude adjustment method used for calculating prayer times at high latitude place/location.
    /// </summary>
    public enum HighLatitudeAdjustment
    {
        /// <summary>
        ///     No adjustment applied.
        /// </summary>
        [Display(Name = "None")]
        None,

        /// <summary>
        ///     Use middle of the night adjustment method.
        /// </summary>
        [Display(Name = "Middle of Night")]
        MiddleOfNight,

        /// <summary>
        ///     Use 1/7th of the night adjustment method.
        /// </summary>
        [Display(Name = "1/7th of Night")]
        OneSeventhOfNight,

        /// <summary>
        ///     Use angle-based adjustment method.
        /// </summary>
        [Display(Name = "Angle-Based")]
        AngleBased
    }
}
