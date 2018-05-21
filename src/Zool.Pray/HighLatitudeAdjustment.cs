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
        None,

        /// <summary>
        ///     Use middle of the night adjustment method.
        /// </summary>
        MiddleOfNight,

        /// <summary>
        ///     Use 1/7th of the night adjustment method.
        /// </summary>
        OneSeventhOfNight,

        /// <summary>
        ///     Use angle-based adjustment method.
        /// </summary>
        AngleBased
    }
}
