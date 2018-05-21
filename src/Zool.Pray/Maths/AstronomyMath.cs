using System;


namespace Zool.Pray.Maths
{
    /// <summary>
    ///     Provides methods for astronomic related computations.
    /// </summary>
    internal static class AstronomyMath
    {
        #region Static Methods

        /// <summary>
        ///     Compute day fraction value for given hour.
        /// </summary>
        /// <param name="hours">
        ///     Hour in floating point.
        /// </param>
        /// <returns>
        ///     Day fraction value of given hour.
        /// </returns>
        internal static double GetDayFraction(double hours)
        {
            return hours / 24.0;
        }

        /// <summary>
        ///     Compute night fraction value for given high latitude method, angle and sunset/sunrise difference.
        /// </summary>
        /// <param name="method">
        ///     <see cref="HighLatitudeAdjustment" /> method to use to get the night fraction.
        /// </param>
        /// <param name="angle">
        ///     Sun's angle value to get the night fraction. Only required when <paramref name="method" /> is set to <see cref="HighLatitudeAdjustment.AngleBased" />
        ///     method.
        /// </param>
        /// <param name="diff">
        ///     Difference hour between sunrise to sunset in floating point.
        /// </param>
        /// <returns>
        ///     Night fraction value for given high latitude method, angle and sunset/sunrise difference.
        /// </returns>
        internal static double GetNightFraction(HighLatitudeAdjustment method, double angle, double diff)
        {
            // Default value to middle of the night method.
            double nightFraction;

            switch (method)
            {
                case HighLatitudeAdjustment.MiddleOfNight:
                    nightFraction = 0.5;
                    break;

                case HighLatitudeAdjustment.OneSeventhOfNight:
                    nightFraction = 0.14285714285714285;
                    break;

                case HighLatitudeAdjustment.AngleBased:
                    nightFraction = 0.016666666666666667 * angle;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(method));
            }

            return nightFraction * diff;
        }

        /// <summary>
        ///     Compute solar time for given julian date, time fraction, angle, latitude and direction.
        /// </summary>
        /// <param name="julianDate">
        ///     Julian date of solar time to be computed.
        /// </param>
        /// <param name="timeFraction">
        ///     Time fraction of the day of solar time to be computed.
        /// </param>
        /// <param name="angle">
        ///     Sun's angle of solar time to be computed.
        /// </param>
        /// <param name="latitude">
        ///     Location's latitude.
        /// </param>
        /// <param name="direction">
        ///     <see cref="Direction" /> value which determine whether sun is before or after mid day.
        /// </param>
        /// <returns>
        ///     Solar time for given julian date, time fraction, angle, latitude and direction.
        /// </returns>
        internal static double ComputeSolarTime(double julianDate, double timeFraction, double angle, double latitude, Direction direction)
        {
            var sunDeclination = ComputeSunDeclination(julianDate + timeFraction);
            var midDay = ComputeMidDay(julianDate, timeFraction);

            var solarTime = 0.0666666666666667 *
                            AngleMath.InverseCosineInDegree((-AngleMath.SineOfDegree(angle) -
                                                             (AngleMath.SineOfDegree(sunDeclination) * AngleMath.SineOfDegree(latitude))) /
                                                            (AngleMath.CosineOfDegree(sunDeclination) * AngleMath.CosineOfDegree(latitude)));

            return midDay + (direction == Direction.CounterClockwise ? -solarTime : solarTime);
        }

        /// <summary>
        ///     Compute sun declination for given julian date.
        /// </summary>
        /// <param name="julianDate">
        ///     Julian date of sun declination to be computed.
        /// </param>
        /// <returns>
        ///     Sun declination for given julian date.
        /// </returns>
        internal static double ComputeSunDeclination(double julianDate)
        {
            var epochDaysFraction = ComputeEpochDaysFraction(julianDate);
            var sunMeanAnomaly = ComputeSunMeanAnomaly(epochDaysFraction);
            var sunMeanLongitude = ComputeSunMeanLongitude(epochDaysFraction);
            var sunEclipticLongitude = ComputeSunEclipticLongitude(sunMeanLongitude, sunMeanAnomaly);
            var eclipticMeanObliquity = ComputeEclipticMeanObliquity(epochDaysFraction);

            return AngleMath.InverseSineInDegree(AngleMath.SineOfDegree(eclipticMeanObliquity) * AngleMath.SineOfDegree(sunEclipticLongitude));
        }

        /// <summary>
        ///     Compute mid day hours for given julian date and time fraction.
        /// </summary>
        /// <param name="julianDate">
        ///     Julian date of mid day hours to be computed.
        /// </param>
        /// <param name="timeFraction">
        ///     Time fraction of the day of mid day hours to be computed.
        /// </param>
        /// <returns>
        ///     Mid day hours for given julian date and time fraction.
        /// </returns>
        internal static double ComputeMidDay(double julianDate, double timeFraction)
        {
            var equationOfTime = ComputeEquationOfTime(julianDate + timeFraction);
            return DateTimeMath.FixHour(12.0 - equationOfTime);
        }

        /// <summary>
        ///     Compute sunrise angle for given elevation in metres.
        /// </summary>
        /// <param name="altitude">
        ///     Location's elevation in metres.
        /// </param>
        /// <returns>
        ///     Sunrise angle for given elevation in metres.
        /// </returns>
        internal static double ComputeSunriseAngle(double altitude)
        {
            return 0.833 + (0.0347 * Math.Sqrt(altitude));
        }

        /// <summary>
        ///     Compute days and fraction from J2000 epoch for given julian date.
        /// </summary>
        private static double ComputeEpochDaysFraction(double when)
        {
            return when - 2451545.0;
        }

        /// <summary>
        ///     Compute sun's mean anomaly for given J2000 epoch days and fraction.
        /// </summary>
        private static double ComputeSunMeanAnomaly(double epochDaysFraction)
        {
            return AngleMath.FixDegreesAngle(357.529 + (0.98560028 * epochDaysFraction));
        }

        /// <summary>
        ///     Compute sun's mean longitude for given J2000 epoch days and fraction.
        /// </summary>
        private static double ComputeSunMeanLongitude(double epochDaysFraction)
        {
            return AngleMath.FixDegreesAngle(280.459 + (0.98564736 * epochDaysFraction));
        }

        /// <summary>
        ///     Compute sun's ecliptic longitude for given mean longitude and mean anomaly.
        /// </summary>
        private static double ComputeSunEclipticLongitude(double sunMeanLongitude, double sunMeanAnomaly)
        {
            return AngleMath.FixDegreesAngle(sunMeanLongitude +
                                             (1.915 * AngleMath.SineOfDegree(sunMeanAnomaly)) +
                                             (0.02 * AngleMath.SineOfDegree(2.0 * sunMeanAnomaly)));
        }

        /// <summary>
        ///     Compute the sun's ecliptic mean obliquity for given J2000 epoch days and fraction.
        /// </summary>
        private static double ComputeEclipticMeanObliquity(double epochDaysFraction)
        {
            return 23.439 - (3.6E-07 * epochDaysFraction);
        }

        /// <summary>
        ///     Compute equation of time for given julian date.
        /// </summary>
        private static double ComputeEquationOfTime(double julianDate)
        {
            var epochDaysFraction = ComputeEpochDaysFraction(julianDate);
            var sunMeanAnomaly = ComputeSunMeanAnomaly(epochDaysFraction);
            var sunMeanLongitude = ComputeSunMeanLongitude(epochDaysFraction);
            var sunEclipticLongitude = ComputeSunEclipticLongitude(sunMeanLongitude, sunMeanAnomaly);
            var eclipticMeanObliquity = ComputeEclipticMeanObliquity(epochDaysFraction);
            var sunRightAscension = ComputeSunRightAscension(eclipticMeanObliquity, sunEclipticLongitude);
            return (sunMeanLongitude / 15.0) - DateTimeMath.FixHour(sunRightAscension);
        }

        /// <summary>
        ///     Compute sun's right ascension for given mean obliquity and ecliptic longitude.
        /// </summary>
        private static double ComputeSunRightAscension(double eclipticMeanObliquity, double sunEclipticLongitude)
        {
            return AngleMath.InverseTangent2InDegree(AngleMath.CosineOfDegree(eclipticMeanObliquity) * AngleMath.SineOfDegree(sunEclipticLongitude),
                                                     AngleMath.CosineOfDegree(sunEclipticLongitude)) /
                   15.0;
        }

        #endregion
    }
}
