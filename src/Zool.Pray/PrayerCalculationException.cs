using System;


namespace Zool.Pray
{
    /// <summary>
    ///     Contains error information thrown by prayer times calculator methods.
    /// </summary>
    public class PrayerCalculationException : Exception
    {
        #region Constructors

        /// <summary>
        ///     Create new <see cref="PrayerCalculationException" />.
        /// </summary>
        /// <param name="message">
        ///     Error message.
        /// </param>
        public PrayerCalculationException(string message) : base(message) { }

        #endregion
    }
}
