using System;

using JetBrains.Annotations;

using NodaTime;

using Zool.Pray.Maths;
using Zool.Pray.Models;


namespace Zool.Pray
{
    /// <summary>
    ///     Implementation of prayer times calculation that can be used worldwide.
    /// </summary>
    internal static class PrayerCalculator
    {
        #region Constants

        // private const double ImsakDefaultTime = 5.0;
        private const double FajrDefaultTime = 5.0;
        private const double SunriseDefaultTime = 6.0;
        private const double ZuhrDefaultTime = 12.0;
        private const double AsrDefaultTime = 13.0;
        private const double SunsetDefaultTime = 18.0;
        private const double MaghribDefaultTime = 18.0;
        private const double IshaDefaultTime = 18.0;

        #endregion


        #region Static Methods

        /// <summary>
        ///     Generate prayer times for one day at given date.
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
        ///     <see cref="Prayers" /> object containing prayer times for one day at given date.
        /// </returns>
        internal static Prayers GetPrayerTimesForOneDay(Instant when, [NotNull] PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var utc = when.InUtc();
            var year = utc.Year;
            var month = utc.Month;
            var day = utc.Day;
            var local = new LocalDate(year, month, day);
            var newUtc = new ZonedDateTime(local.AtMidnight(), DateTimeZone.Utc, Offset.Zero);

            var jd = newUtc.ToInstant().ToJulianDate() - (coordinate.Longitude / 360.0);
            var raw = ComputeRaw(jd, settings, coordinate.Latitude, coordinate.Altitude);
            var afterAdjustment = AdjustTime(raw, settings, coordinate.Longitude, timeZone);

            // Calculate midnight.
            var fajr = afterAdjustment.Fajr;
            var sunrise = afterAdjustment.Sunrise;
            var sunset = afterAdjustment.Sunset;
            afterAdjustment.Midnight = ComputeMidnightTime(settings.CalculationMethod.MidnightMethod, fajr, sunrise, sunset);

            // Convert.
            var converted = ConvertFromFloatingPointFormat(afterAdjustment, year, month, day, timeZone);

            // Round.
            var rounded = new Prayers(RoundPrayerTime(converted.Imsak),
                                      RoundPrayerTime(converted.Fajr),
                                      RoundPrayerTime(converted.Sunrise),
                                      RoundPrayerTime(converted.Dhuha),
                                      RoundPrayerTime(converted.Zuhr),
                                      RoundPrayerTime(converted.Asr),
                                      RoundPrayerTime(converted.Sunset),
                                      RoundPrayerTime(converted.Maghrib),
                                      RoundPrayerTime(converted.Isha),
                                      RoundPrayerTime(converted.Midnight));

            return rounded;
        }

        /// <summary>
        ///     Generate current prayer time.
        /// </summary>
        /// <param name="clock">
        ///     <see cref="IClock" /> interface object for getting current <see cref="Instant" /> value.
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
        ///     <see cref="Prayer" /> object containing current prayer time data.
        /// </returns>
        internal static Prayer GetCurrentPrayerTime(IClock clock, PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone)
        {
            var now = clock.GetCurrentInstant();
            var today = GetPrayerTimesForOneDay(now, settings, coordinate, timeZone);
            var yesterday = GetPrayerTimesForOneDay(now + Duration.FromDays(-1), settings, coordinate, timeZone);

            if (now < today.Imsak)
            {
                return new Prayer(PrayerType.Isha, yesterday.Isha);
            }

            if (now < today.Fajr)
            {
                return new Prayer(PrayerType.Imsak, today.Imsak);
            }

            if (now < today.Sunrise)
            {
                return new Prayer(PrayerType.Fajr, today.Fajr);
            }

            if (now < today.Dhuha)
            {
                return new Prayer(PrayerType.Sunrise, today.Sunrise);
            }

            if (now < today.Zuhr)
            {
                return new Prayer(PrayerType.Dhuha, today.Dhuha);
            }

            if (now < today.Asr)
            {
                return new Prayer(PrayerType.Zuhr, today.Zuhr);
            }

            if (now < today.Maghrib)
            {
                return new Prayer(PrayerType.Asr, today.Asr);
            }

            if (now < today.Isha)
            {
                return new Prayer(PrayerType.Maghrib, today.Maghrib);
            }

            return new Prayer(PrayerType.Isha, today.Isha);
        }

        /// <summary>
        ///     Generate next prayer time.
        /// </summary>
        /// <param name="clock">
        ///     <see cref="IClock" /> interface object for getting next <see cref="Instant" /> value.
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
        ///     <see cref="Prayer" /> object containing next prayer time data.
        /// </returns>
        internal static Prayer GetNextPrayerTime(IClock clock, PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone)
        {
            var now = clock.GetCurrentInstant();
            var today = GetPrayerTimesForOneDay(now, settings, coordinate, timeZone);
            var tomorrow = GetPrayerTimesForOneDay(now + Duration.FromDays(1), settings, coordinate, timeZone);

            if (now < today.Imsak)
            {
                return new Prayer(PrayerType.Imsak, today.Imsak);
            }

            if (now < today.Fajr)
            {
                return new Prayer(PrayerType.Fajr, today.Fajr);
            }

            if (now < today.Sunrise)
            {
                return new Prayer(PrayerType.Sunrise, today.Sunrise);
            }

            if (now < today.Dhuha)
            {
                return new Prayer(PrayerType.Dhuha, today.Dhuha);
            }

            if (now < today.Zuhr)
            {
                return new Prayer(PrayerType.Zuhr, today.Zuhr);
            }

            if (now < today.Asr)
            {
                return new Prayer(PrayerType.Asr, today.Asr);
            }

            if (now < today.Maghrib)
            {
                return new Prayer(PrayerType.Maghrib, today.Maghrib);
            }

            if (now < today.Isha)
            {
                return new Prayer(PrayerType.Isha, today.Isha);
            }

            return new Prayer(PrayerType.Imsak, tomorrow.Imsak);
        }

        /// <summary>
        ///     Generate later prayer time.
        /// </summary>
        /// <param name="clock">
        ///     <see cref="IClock" /> interface object for getting later <see cref="Instant" /> value.
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
        ///     <see cref="Prayer" /> object containing later prayer time data.
        /// </returns>
        internal static Prayer GetLaterPrayerTime(IClock clock, PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone)
        {
            var now = clock.GetCurrentInstant();
            var today = GetPrayerTimesForOneDay(now, settings, coordinate, timeZone);
            var tomorrow = GetPrayerTimesForOneDay(now + Duration.FromDays(1), settings, coordinate, timeZone);

            if (now < today.Imsak)
            {
                return new Prayer(PrayerType.Fajr, today.Fajr);
            }

            if (now < today.Fajr)
            {
                return new Prayer(PrayerType.Sunrise, today.Sunrise);
            }

            if (now < today.Sunrise)
            {
                return new Prayer(PrayerType.Dhuha, today.Dhuha);
            }

            if (now < today.Dhuha)
            {
                return new Prayer(PrayerType.Zuhr, today.Zuhr);
            }

            if (now < today.Zuhr)
            {
                return new Prayer(PrayerType.Asr, today.Asr);
            }

            if (now < today.Asr)
            {
                return new Prayer(PrayerType.Maghrib, today.Maghrib);
            }

            if (now < today.Maghrib)
            {
                return new Prayer(PrayerType.Isha, today.Isha);
            }

            if (now < today.Isha)
            {
                return new Prayer(PrayerType.Imsak, tomorrow.Imsak);
            }

            return new Prayer(PrayerType.Fajr, tomorrow.Fajr);
        }

        /// <summary>
        ///     Generate after later prayer time.
        /// </summary>
        /// <param name="clock">
        ///     <see cref="IClock" /> interface object for getting after later <see cref="Instant" /> value.
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
        ///     <see cref="Prayer" /> object containing after later prayer time data.
        /// </returns>
        internal static Prayer GetAfterLaterPrayerTime(IClock clock, PrayerCalculationSettings settings, Geocoordinate coordinate, double timeZone)
        {
            var now = clock.GetCurrentInstant();
            var today = GetPrayerTimesForOneDay(now, settings, coordinate, timeZone);
            var tomorrow = GetPrayerTimesForOneDay(now + Duration.FromDays(1), settings, coordinate, timeZone);

            if (now < today.Imsak)
            {
                return new Prayer(PrayerType.Sunrise, today.Sunrise);
            }

            if (now < today.Fajr)
            {
                return new Prayer(PrayerType.Dhuha, today.Dhuha);
            }

            if (now < today.Sunrise)
            {
                return new Prayer(PrayerType.Zuhr, today.Zuhr);
            }

            if (now < today.Dhuha)
            {
                return new Prayer(PrayerType.Asr, today.Asr);
            }

            if (now < today.Zuhr)
            {
                return new Prayer(PrayerType.Maghrib, today.Maghrib);
            }

            if (now < today.Asr)
            {
                return new Prayer(PrayerType.Isha, today.Isha);
            }

            if (now < today.Maghrib)
            {
                return new Prayer(PrayerType.Imsak, today.Imsak);
            }

            if (now < today.Isha)
            {
                return new Prayer(PrayerType.Fajr, tomorrow.Fajr);
            }

            return new Prayer(PrayerType.Sunrise, tomorrow.Sunrise);
        }

        /// <summary>
        /// Compute all prayer times at given Julian Date and return the raw results.
        /// </summary>
        private static PrayersInDouble ComputeRaw(double jd, PrayerCalculationSettings settings, double latitude, double altitude)
        {
            var raw = new PrayersInDouble();

            // Compute imsak.
            if (settings.ImsakParameter.Type == PrayerCalculationParameterType.Angle) {
                // raw.imsak = _computeImsakTime(jd, settings.imsakParameter.value, latitude);
                // NOTE: Do imsak time can be calculated using angle parameter?
                throw new PrayerCalculationException("Imsak calculation parameter type must be the type of minute adjust.");
            }

            // Check fajr parameter type.
            if (settings.CalculationMethod.FajrParameter.Type == PrayerCalculationParameterType.MinutesAdjust) {
                throw new PrayerCalculationException("Fajr calculation parameter type must be the type of angle.");
            }

            // Compute fajr, sunrise, dhuha, zuhr, asr and sunset.
            raw.Fajr = ComputeFajrTime(jd, settings.CalculationMethod.FajrParameter.Value, latitude);
            raw.Sunrise = ComputeSunriseTime(jd, latitude, altitude);
            raw.Dhuha = ComputeDhuhaTime(raw.Fajr, raw.Sunrise);
            raw.Zuhr = ComputeZuhrTime(jd);
            raw.Asr = ComputeAsrTime(jd, settings.JuristicMethod.TimeOfShadow, latitude);
            raw.Sunset = ComputeSunsetTime(jd, latitude, altitude);

            // Compute maghrib.
            if (settings.CalculationMethod.MaghribParameter.Type == PrayerCalculationParameterType.Angle) {
                raw.Maghrib = ComputeMaghribTime(jd, settings.CalculationMethod.MaghribParameter.Value, latitude);
            }

            // Compute isha.
            if (settings.CalculationMethod.IshaParameter.Type == PrayerCalculationParameterType.Angle) {
                raw.Isha = ComputeIshaTime(jd, settings.CalculationMethod.IshaParameter.Value, latitude);
            }

            return raw;
        }

        // /// <summary>
        // /// Calculate prayer time for imsak.
        // /// </summary>
        // // NOTE: Do imsak time can be calculated using angle parameter?
        // private static double ComputeImsakTime(double jd, double imsakParameterValue, double latitude)
        // {
        //     var dayFraction = AstronomyMath.GetDayFraction(ImsakDefaultTime);
        //     var imsakTime = AstronomyMath.ComputeSolarTime(jd, dayFraction, imsakParameterValue, latitude, Direction.CounterClockwise);
        //
        //     return imsakTime;
        // }

        /// <summary>
        /// Calculate prayer time for fajr.
        /// </summary>
        private static double ComputeFajrTime(double jd, double fajrParameterValue, double latitude)
        {
            var dayFraction = AstronomyMath.GetDayFraction(FajrDefaultTime);
            var fajrTime = AstronomyMath.ComputeSolarTime(jd, dayFraction, fajrParameterValue, latitude, Direction.CounterClockwise);

            return fajrTime;
        }

        /// <summary>
        /// Calculate prayer time for sunrise.
        /// </summary>
        private static double ComputeSunriseTime(double jd, double latitude, double altitude)
        {
            var dayFraction = AstronomyMath.GetDayFraction(SunriseDefaultTime);
            var sunriseAngle = AstronomyMath.ComputeSunriseAngle(altitude);
            var sunriseTime = AstronomyMath.ComputeSolarTime(jd, dayFraction, sunriseAngle, latitude, Direction.CounterClockwise);

            return sunriseTime;
        }

        /// <summary>
        /// Calculate prayer time for dhuha.
        /// </summary>
        private static double ComputeDhuhaTime(double fajr, double sunrise)
        {
            var dhuhaTime = sunrise + ((sunrise - fajr) / 3.0);
            return dhuhaTime;
        }

        /// <summary>
        /// Calculate prayer time for zuhr.
        /// </summary>
        private static double ComputeZuhrTime(double jd)
        {
            var dayFraction = AstronomyMath.GetDayFraction(ZuhrDefaultTime);
            var midDay = AstronomyMath.ComputeMidDay(jd, dayFraction);

            // The fiqh method which states that zuhr is when the sun's disk comes out
            // of its zenith line, which is a line between the observer and the center
            // of the sun when it is at the highest point is used here. Thus,
            // additional 65 seconds is added to the mid day time, which corresponds
            // to the formula t = arctan(r/d) / 2π × 24 × 60 × 60, where r is the
            // radius of the sun (r = 695,000km), d is the sun-earth distance
            // (d = 147,098,074km at minimum and d = 152,097,701km at maximum).
            // When, d is at maximum, t evaluates to ~62 seconds and ~65 seconds when
            // d is at minimum. Converting 65 seconds to hour yields a value of
            // 0.018055555555555554.
            var zuhrTime = midDay + 0.018055555555555554;
            return zuhrTime;
        }

        /// <summary>
        /// Calculate prayer time for asr.
        /// </summary>
        private static double ComputeAsrTime(double jd, int juristicTimeOfShadow, double latitude)
        {
            var dayFraction = AstronomyMath.GetDayFraction(AsrDefaultTime);
            var sunDeclination = AstronomyMath.ComputeSunDeclination(jd + dayFraction);
            var angle = -AngleMath.InverseCotangentInDegree(juristicTimeOfShadow + AngleMath.TangentOfDegree(Math.Abs(latitude - sunDeclination)));
            var asrTime = AstronomyMath.ComputeSolarTime(jd, dayFraction, angle, latitude, Direction.Clockwise);

            return asrTime;
        }

        /// <summary>
        /// Calculate prayer time for sunset.
        /// </summary>
        private static double ComputeSunsetTime(double jd, double latitude, double altitude)
        {
            var dayFraction = AstronomyMath.GetDayFraction(SunsetDefaultTime);
            var sunriseAngle = AstronomyMath.ComputeSunriseAngle(altitude);
            var sunsetTime = AstronomyMath.ComputeSolarTime(jd, dayFraction, sunriseAngle, latitude, Direction.Clockwise);

            return sunsetTime;
        }

        /// <summary>
        /// Calculate prayer time for maghrib.
        /// </summary>
        private static double ComputeMaghribTime(double jd, double maghribParameterValue, double latitude)
        {
            var dayFraction = AstronomyMath.GetDayFraction(MaghribDefaultTime);
            var maghribTime = AstronomyMath.ComputeSolarTime(jd, dayFraction, maghribParameterValue, latitude, Direction.Clockwise);

            return maghribTime;
        }

        /// <summary>
        /// Calculate prayer time for isha.
        /// </summary>
        private static double ComputeIshaTime(double jd, double ishaParameterValue, double latitude)
        {
            var dayFraction = AstronomyMath.GetDayFraction(IshaDefaultTime);
            var ishaTime = AstronomyMath.ComputeSolarTime(jd, dayFraction, ishaParameterValue, latitude, Direction.Clockwise);

            return ishaTime;
        }

        /// <summary>
        /// Calculate time for midnight.
        /// </summary>
        private static double ComputeMidnightTime(Midnight method, double fajr, double sunrise, double sunset)
        {
            var duration = method == Midnight.Jafari ? DateTimeMath.ComputeDuration(fajr, sunset) : DateTimeMath.ComputeDuration(sunrise, sunset);
            var midnightTime = sunset + (duration / 2.0);

            return midnightTime;
        }

        /// <summary>
        /// Apply adjustments to given calculated prayer time.
        /// </summary>
        private static PrayersInDouble AdjustTime(PrayersInDouble raw, PrayerCalculationSettings settings, double longitude, double timeZone)
        {
            // Adjust imsak if minute adjustment parameter is used.
            if (settings.ImsakParameter.Type == PrayerCalculationParameterType.MinutesAdjust) {
                raw.Imsak = raw.Fajr + (settings.ImsakParameter.Value / 60.0);
            }

            // Adjust maghrib if minute adjustment parameter is used.
            // This is Sunni method which maghrib equals to sunset. As precaution, this
            // library add 1 minute to the sunset time.
            if (settings.CalculationMethod.MaghribParameter.Type == PrayerCalculationParameterType.MinutesAdjust) {
                raw.Maghrib = raw.Sunset + 0.016666666666666667 + (settings.CalculationMethod.MaghribParameter.Value / 60.0);
            }

            // Adjust isha if minute adjustment parameter is used.
            if (settings.CalculationMethod.IshaParameter.Type == PrayerCalculationParameterType.MinutesAdjust) {
                raw.Isha = raw.Maghrib + (settings.CalculationMethod.IshaParameter.Value / 60.0);
            }

            // Adjust to time zone.
            raw = AdjustAllToTimeZone(raw, longitude, timeZone);
            raw = AdjustAllForHighLatitude(raw, settings);
            raw = MinuteAdjustAll(raw, settings);
            return raw;
        }

        /// <summary>
        /// Apply time zone adjustment to given calculated prayer time.
        /// </summary>
        private static PrayersInDouble AdjustAllToTimeZone(PrayersInDouble raw, double longitude, double timeZone)
        {
            var adjustment = timeZone - (longitude / 15.0);
            raw.Imsak = raw.Imsak + adjustment;
            raw.Fajr = raw.Fajr + adjustment;
            raw.Sunrise = raw.Sunrise + adjustment;
            raw.Dhuha = raw.Dhuha + adjustment;
            raw.Zuhr = raw.Zuhr + adjustment;
            raw.Asr = raw.Asr + adjustment;
            raw.Sunset = raw.Sunset + adjustment;
            raw.Maghrib = raw.Maghrib + adjustment;
            raw.Isha = raw.Isha + adjustment;

            return raw;
        }

        /// <summary>
        /// Adjust calculated imsak, fajr, maghrib and isha prayer times to high latitude adjustment.
        /// </summary>
        private static PrayersInDouble AdjustAllForHighLatitude(PrayersInDouble raw, PrayerCalculationSettings settings)
        {
            //
            // Do not apply adjustment if none option is specified.
            if (settings.HighLatitudeAdjustment == HighLatitudeAdjustment.None) {
                return raw;
            }

            // Copy reference.
            var method = settings.HighLatitudeAdjustment;
            var imsak = raw.Imsak;
            var fajr = raw.Fajr;
            var sunrise = raw.Sunrise;
            var sunset = raw.Sunset;
            var maghrib = raw.Maghrib;
            var isha = raw.Isha;
            var imsakParameterValue = settings.ImsakParameter.Value;
            var fajrParameterValue = settings.CalculationMethod.FajrParameter.Value;
            var maghribParameterValue = settings.CalculationMethod.MaghribParameter.Value;
            var ishaParameterValue = settings.CalculationMethod.IshaParameter.Value;

            // Compute sunrise to sunset difference.
            var diff = DateTimeMath.ComputeDuration(raw.Sunrise, raw.Sunset);

            // Adjust.
            raw.Imsak = AdjustForHighLatitude(method, imsak, sunrise, imsakParameterValue, diff, Direction.CounterClockwise);
            raw.Fajr = AdjustForHighLatitude(method, fajr, sunrise, fajrParameterValue, diff, Direction.CounterClockwise);
            raw.Maghrib = AdjustForHighLatitude(method, maghrib, sunset, maghribParameterValue, diff, Direction.Clockwise);
            raw.Isha = AdjustForHighLatitude(method, isha, sunset, ishaParameterValue, diff, Direction.Clockwise);

            return raw;
        }

        /// <summary>
        /// Adjust calculated prayer time to high latitude adjustment.
        /// </summary>
        private static double AdjustForHighLatitude(HighLatitudeAdjustment method, double time, double baseTime, double angle, double diff, Direction direction)
        {
            // Compute night fraction and duration.
            var nightFraction = AstronomyMath.GetNightFraction(method, angle, diff);
            var duration = direction == Direction.Clockwise
                               ? DateTimeMath.ComputeDuration(time, baseTime)
                               : DateTimeMath.ComputeDuration(baseTime, time);

            // Copy reference;
            var newTime = time;
            if (duration > nightFraction) {
                var adjustment = direction == Direction.Clockwise ? nightFraction : -nightFraction;
                newTime = baseTime + adjustment;
            }

            return newTime;
        }

        /// <summary>
        /// Apply time zone adjustment to given calculated prayer time.
        /// </summary>
        private static PrayersInDouble MinuteAdjustAll(PrayersInDouble raw, PrayerCalculationSettings settings)
        {
            raw.Imsak = raw.Imsak + (settings.ImsakMinutesAdjustment / 60.0);
            raw.Fajr = raw.Fajr + (settings.FajrMinutesAdjustment / 60.0);
            raw.Sunrise = raw.Sunrise + (settings.SunriseMinutesAdjustment / 60.0);
            raw.Dhuha = raw.Dhuha + (settings.DhuhaMinutesAdjustment / 60.0);
            raw.Zuhr = raw.Zuhr + (settings.ZuhrMinutesAdjustment / 60.0);
            raw.Asr = raw.Asr + (settings.AsrMinutesAdjustment / 60.0);
            raw.Maghrib = raw.Maghrib + (settings.MaghribMinutesAdjustment / 60.0);
            raw.Isha = raw.Isha + (settings.IshaMinutesAdjustment / 60.0);

            return raw;
        }

        /// <summary>
        /// Convert <see cref="PrayersInDouble"/> into <see cref="Prayers"/>.
        /// </summary>
        private static Prayers ConvertFromFloatingPointFormat(PrayersInDouble prayers, int year, int month, int day, double timeZone)
        {
            var local = new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.FromHours(timeZone));
            var instant = Instant.FromDateTimeOffset(local);

            return new Prayers(instant + Duration.FromHours(prayers.Imsak),
                               instant + Duration.FromHours(prayers.Fajr),
                               instant + Duration.FromHours(prayers.Sunrise),
                               instant + Duration.FromHours(prayers.Dhuha),
                               instant + Duration.FromHours(prayers.Zuhr),
                               instant + Duration.FromHours(prayers.Asr),
                               instant + Duration.FromHours(prayers.Sunset),
                               instant + Duration.FromHours(prayers.Maghrib),
                               instant + Duration.FromHours(prayers.Isha),
                               instant + Duration.FromHours(prayers.Midnight));
        }

        /// <summary>
        /// If given <see cref="Instant"/> value of parameter <paramref name="calculatedTime"/> has second component larger than zero, the second component is resetted to zero and minute component is added with one.
        /// </summary>
        private static Instant RoundPrayerTime(Instant calculatedTime)
        {
            var utc = calculatedTime.InUtc();
            if (utc.Second > 0)
            {
                calculatedTime = calculatedTime + Duration.FromSeconds(60 - utc.Second);
            }

            return calculatedTime;
        }

        #endregion
    }
}
