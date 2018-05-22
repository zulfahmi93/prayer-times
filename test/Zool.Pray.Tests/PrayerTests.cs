using System;

using NodaTime;

using Xunit;

using Zool.Pray.Models;


namespace Zool.Pray.Tests
{
    public class PrayerTests
    {
        private class MockClock : IClock
        {
            public Instant GetCurrentInstant()
            {
                return Instant.FromDateTimeUtc(new DateTime(2018, 4, 12, 0, 0, 0, DateTimeKind.Utc));
            }
        }

        private const double TimeZone = 8.0; // UTC+08:00
        private readonly Instant _instant; // April 12th, 2018 08:00 at UTC
        private readonly Geocoordinate _coordinate; // [2, 101, 2]
        private readonly PrayerCalculationSettings _settings;
        private readonly IClock _mockClock;

        public PrayerTests()
        {
            var date = new DateTime(2018, 4, 12, 8, 0, 0, DateTimeKind.Utc);
            _instant = Instant.FromDateTimeUtc(date);
            _coordinate = new Geocoordinate(2.0, 101.0, 2.0);
            _settings = new PrayerCalculationSettings();
            _settings.CalculationMethod.SetCalculationMethodPreset(_instant, CalculationMethodPreset.DepartmentOfIslamicAdvancementOfMalaysia);
            _mockClock = new MockClock();
        }

        private static void AssertEqualInstant(Instant expected, Instant actual)
        {
            var expectedUtc = expected.InUtc();
            var expectedYear = expectedUtc.Year;
            var expectedMonth = expectedUtc.Month;
            var expectedDay = expectedUtc.Day;
            var expectedHour = expectedUtc.Hour;
            var expectedMinute = expectedUtc.Minute;

            var actualUtc = actual.InUtc();
            var actualYear = actualUtc.Year;
            var actualMonth = actualUtc.Month;
            var actualDay = actualUtc.Day;
            var actualHour = actualUtc.Hour;
            var actualMinute = actualUtc.Minute;

            Assert.Equal(expectedYear, actualYear);
            Assert.Equal(expectedMonth, actualMonth);
            Assert.Equal(expectedDay, actualDay);
            Assert.Equal(expectedHour, actualHour);
            Assert.Equal(expectedMinute, actualMinute);
        }

        [Fact(DisplayName = "Test get 1-day prayer times at [2, 101, 2] using JAKIM on April 12th, 2018.")]
        // ReSharper disable once InconsistentNaming
        public void TestGetPrayerTimesForApril12th2018()
        {
            var imsakExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 5, 45, 0, TimeSpan.FromHours(8.0)));
            var fajrExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 5, 55, 0, TimeSpan.FromHours(8.0)));
            var sunriseExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 7, 13, 0, TimeSpan.FromHours(8.0)));
            var dhuhaExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 7, 38, 0, TimeSpan.FromHours(8.0)));
            var dhuhrExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 13, 18, 0, TimeSpan.FromHours(8.0)));
            var asrExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 16, 29, 0, TimeSpan.FromHours(8.0)));
            var sunsetExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 19, 22, 0, TimeSpan.FromHours(8.0)));
            var maghribExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 19, 23, 0, TimeSpan.FromHours(8.0)));
            var ishaExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 20, 32, 0, TimeSpan.FromHours(8.0)));
            var midnightExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 13, 1, 17, 0, TimeSpan.FromHours(8.0)));

            var prayers = Prayers.On(_instant, _settings, _coordinate, TimeZone);
            AssertEqualInstant(imsakExpected, prayers.Imsak);
            AssertEqualInstant(fajrExpected, prayers.Fajr);
            AssertEqualInstant(sunriseExpected, prayers.Sunrise);
            AssertEqualInstant(dhuhaExpected, prayers.Dhuha);
            AssertEqualInstant(dhuhrExpected, prayers.Dhuhr);
            AssertEqualInstant(asrExpected, prayers.Asr);
            AssertEqualInstant(sunsetExpected, prayers.Sunset);
            AssertEqualInstant(maghribExpected, prayers.Maghrib);
            AssertEqualInstant(ishaExpected, prayers.Isha);
            AssertEqualInstant(midnightExpected, prayers.Midnight);
        }

        [Fact(DisplayName = "Test get today (mocked for April 12th, 2018) prayer times at [2, 101, 2] using JAKIM.")]
        public void TestGetPrayerTimesForToday()
        {
            var imsakExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 5, 45, 0, TimeSpan.FromHours(8.0)));
            var fajrExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 5, 55, 0, TimeSpan.FromHours(8.0)));
            var sunriseExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 7, 13, 0, TimeSpan.FromHours(8.0)));
            var dhuhaExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 7, 38, 0, TimeSpan.FromHours(8.0)));
            var dhuhrExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 13, 18, 0, TimeSpan.FromHours(8.0)));
            var asrExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 16, 29, 0, TimeSpan.FromHours(8.0)));
            var sunsetExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 19, 22, 0, TimeSpan.FromHours(8.0)));
            var maghribExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 19, 23, 0, TimeSpan.FromHours(8.0)));
            var ishaExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 20, 32, 0, TimeSpan.FromHours(8.0)));
            var midnightExpected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 13, 1, 17, 0, TimeSpan.FromHours(8.0)));

            var prayers = Prayers.Today(_settings, _coordinate, TimeZone, _mockClock);
            AssertEqualInstant(imsakExpected, prayers.Imsak);
            AssertEqualInstant(fajrExpected, prayers.Fajr);
            AssertEqualInstant(sunriseExpected, prayers.Sunrise);
            AssertEqualInstant(dhuhaExpected, prayers.Dhuha);
            AssertEqualInstant(dhuhrExpected, prayers.Dhuhr);
            AssertEqualInstant(asrExpected, prayers.Asr);
            AssertEqualInstant(sunsetExpected, prayers.Sunset);
            AssertEqualInstant(maghribExpected, prayers.Maghrib);
            AssertEqualInstant(ishaExpected, prayers.Isha);
            AssertEqualInstant(midnightExpected, prayers.Midnight);
        }

        [Fact(DisplayName = "Test get current (mocked for April 12th, 2018) prayer time at [2, 101, 2] using JAKIM.")]
        public void TestGetCurrentPrayerTime()
        {
            var expected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 7, 38, 0, TimeSpan.FromHours(8.0)));
            var prayer = Prayer.Now(_settings, _coordinate, TimeZone, _mockClock);
            AssertEqualInstant(expected, prayer.Time);
            Assert.Equal(PrayerType.Dhuha, prayer.Type);
        }

        [Fact(DisplayName = "Test get next (mocked for April 12th, 2018) prayer time at [2, 101, 2] using JAKIM.")]
        public void TestGetNextPrayerTime()
        {
            var expected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 13, 18, 0, TimeSpan.FromHours(8.0)));
            var prayer = Prayer.Next(_settings, _coordinate, TimeZone, _mockClock);
            AssertEqualInstant(expected, prayer.Time);
            Assert.Equal(PrayerType.Dhuhr, prayer.Type);
        }

        [Fact(DisplayName = "Test get later (mocked for April 12th, 2018) prayer time at [2, 101, 2] using JAKIM.")]
        public void TestGetLaterPrayerTime()
        {
            var expected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 16, 29, 0, TimeSpan.FromHours(8.0)));
            var prayer = Prayer.Later(_settings, _coordinate, TimeZone, _mockClock);
            AssertEqualInstant(expected, prayer.Time);
            Assert.Equal(PrayerType.Asr, prayer.Type);
        }

        [Fact(DisplayName = "Test get after later (mocked for April 12th, 2018) prayer time at [2, 101, 2] using JAKIM.")]
        public void TestGetAfterLaterPrayerTime()
        {
            var expected = Instant.FromDateTimeOffset(new DateTimeOffset(2018, 4, 12, 19, 23, 0, TimeSpan.FromHours(8.0)));
            var prayer = Prayer.AfterLater(_settings, _coordinate, TimeZone, _mockClock);
            AssertEqualInstant(expected, prayer.Time);
            Assert.Equal(PrayerType.Maghrib, prayer.Type);
        }
    }
}
