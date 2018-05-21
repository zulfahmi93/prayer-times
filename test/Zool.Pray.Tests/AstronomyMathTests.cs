using System;

using Xunit;

using Zool.Pray.Maths;


namespace Zool.Pray.Tests
{
    public class AstronomyMathTests
    {
        private const double FajrAngle = 20.0; // Fajr angle of 20 degrees
        private const double IshaAngle = 18.0; // Isha angle of 18 degrees
        private const double Diff = 11.84245471252006;
        private const double Jd = 2458220.2194444444; // April 12th, 2018
        private const double Latitude = 2.0;

        [Fact(DisplayName = "Test get day fraction for imsak default time of 5.")]
        public void TestGetDayFractionForImsakDefaultTime()
        {
            Assert.Equal(0.20833333333333334, AstronomyMath.GetDayFraction(5.0));
        }

        [Fact(DisplayName = "Test get day fraction for fajr default time of 5.")]
        public void TestGetDayFractionForFajrDefaultTime()
        {
            Assert.Equal(0.20833333333333334, AstronomyMath.GetDayFraction(5.0));
        }

        [Fact(DisplayName = "Test get day fraction for sunrise default time of 6.")]
        public void TestGetDayFractionForSunriseDefaultTime()
        {
            Assert.Equal(0.25, AstronomyMath.GetDayFraction(6.0));
        }

        [Fact(DisplayName = "Test get day fraction for dhuhr default time of 12.")]
        public void TestGetDayFractionForDhuhrDefaultTime()
        {
            Assert.Equal(0.5, AstronomyMath.GetDayFraction(12.0));
        }

        [Fact(DisplayName = "Test get day fraction for asr default time of 13.")]
        public void TestGetDayFractionForAsrDefaultTime()
        {
            Assert.Equal(0.5416666666666666, AstronomyMath.GetDayFraction(13.0));
        }

        [Fact(DisplayName = "Test get day fraction for sunset default time of 18.")]
        public void TestGetDayFractionForSunsetDefaultTime()
        {
            Assert.Equal(0.75, AstronomyMath.GetDayFraction(18.0));
        }

        [Fact(DisplayName = "Test get day fraction for maghrib default time of 18.")]
        public void TestGetDayFractionForMaghribDefaultTime()
        {
            Assert.Equal(0.75, AstronomyMath.GetDayFraction(18.0));
        }

        [Fact(DisplayName = "Test get day fraction for isha default time of 18.")]
        public void TestGetDayFractionForIshaDefaultTime()
        {
            Assert.Equal(0.75, AstronomyMath.GetDayFraction(18.0));
        }

        [Fact(DisplayName = "Test get night fraction for high latitude adjustment of none should throw error.")]
        public void TestGetNightFractionForHighLatitudeAdjustmentOfNoneShouldThrow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => AstronomyMath.GetNightFraction(HighLatitudeAdjustment.None, FajrAngle, Diff));
        }

        [Fact(DisplayName = "Test get night fraction for high latitude adjustment of middle of night with diff 11.84245471252006 should equals 5.92122735626003.")]
        public void TestGetNightFractionForHighLatitudeAdjustmentOfMiddleOfNight()
        {
            Assert.Equal(5.92122735626003, AstronomyMath.GetNightFraction(HighLatitudeAdjustment.MiddleOfNight, FajrAngle, Diff));
        }

        [Fact(DisplayName = "Test get night fraction for high latitude adjustment of 1/7 of night with diff 11.84245471252006 should equals 1.691779244645723.")]
        public void TestGetNightFractionForHighLatitudeAdjustmentOfOneSeventhOfNight()
        {
            Assert.Equal(1.691779244645723, AstronomyMath.GetNightFraction(HighLatitudeAdjustment.OneSeventhOfNight, FajrAngle, Diff));
        }

        [Fact(DisplayName = "Test get night fraction for high latitude adjustment ofangle-based with angle 20 and diff 11.84245471252006 should equals 3.9474849041733533.")]
        public void TestGetNightFractionForHighLatitudeAdjustmentOfAngleBased()
        {
            Assert.Equal(3.9474849041733533, AstronomyMath.GetNightFraction(HighLatitudeAdjustment.AngleBased, FajrAngle, Diff));
        }

        [Fact(DisplayName = "Test compute solar time for fajr on April 12th, 2018.")]
        // ReSharper disable once InconsistentNaming
        public void TestComputeSolarTimeForFajrPrayerOnApril12th2018()
        {
            var st = AstronomyMath.ComputeSolarTime(Jd, 0.20833333333333334, FajrAngle, Latitude, Direction.CounterClockwise);
            Assert.Equal(4.644572520441736, st);
        }

        [Fact(DisplayName = "Test compute solar time for isha on April 12th, 2018.")]
        // ReSharper disable once InconsistentNaming
        public void TestComputeSolarTimeForIshaPrayerOnApril12th2018()
        {
            var st = AstronomyMath.ComputeSolarTime(Jd, 0.75, IshaAngle, Latitude, Direction.Clockwise);
            Assert.Equal(19.250576300230424, st);
        }

        [Fact(DisplayName = "Test compute sun declination on April 12th, 2018.")]
        // ReSharper disable once InconsistentNaming
        public void TestComputeSunDeclinationOnApril12th2018()
        {
            var sd = AstronomyMath.ComputeSunDeclination(Jd + 0.5416666666666666);
            Assert.Equal(8.680557660849296, sd);
        }

        [Fact(DisplayName = "Test compute mid day on April 12th, 2018.")]
        // ReSharper disable once InconsistentNaming
        public void TestComputeMidDayOnApril12th2018()
        {
            var mid = AstronomyMath.ComputeMidDay(Jd, 0.5);
            Assert.Equal(12.014588571149947, mid);
        }

        [Fact(DisplayName = "Test compute sunrise/sunset angle at elevation of 2 metres.")]
        public void TestComputeSunriseAngleAt2MetresAltitude()
        {
            var sa = AstronomyMath.ComputeSunriseAngle(2.0);
            Assert.Equal(0.8820732106143464, sa);
        }
    }
}
