namespace Zool.Pray.Maths
{
    /// <summary>
    ///     Provides constants for <see cref="double" /> comparison tolerance.
    /// </summary>
    internal static class Tolerance
    {
        #region Constants

        /// <summary>
        ///     Course tolerance constants (1e-3).
        /// </summary>
        internal const double Course = 0.001;

        /// <summary>
        ///     Medium tolerance constants (1e-6).
        /// </summary>
        internal const double Medium = 1e-06;

        /// <summary>
        ///     Fine tolerance constants (1e-9).
        /// </summary>
        internal const double Fine = 1e-09;

        /// <summary>
        ///     Super fine tolerance constants (1e-12).
        /// </summary>
        internal const double SuperFine = 1e-12;

        /// <summary>
        ///     Ultra fine tolerance constants (4.9406564584124654e-324).
        /// </summary>
        internal const double UltraFine = 4.9406564584124654e-324;

        #endregion
    }
}
