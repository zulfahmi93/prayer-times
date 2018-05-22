using System;
using System.Globalization;

using NodaTime;
using Zool.Pray.Models;


namespace Zool.Pray.Example
{
    class Program
    {
        private const int Year = 2018;
        private const int Month = 4;
        private const int Day = 12;
        private const double TimeZone = 8.0;
        
        static void Main()
        {
            // Use April 12th, 2018.
            var when = Instant.FromUtc(Year, Month, Day, 0, 0);
            
            // Init settings.
            var settings = new PrayerCalculationSettings();

            // Set calculation method to JAKIM (Fajr: 18.0 and Isha: 20.0).
            settings.CalculationMethod.SetCalculationMethodPreset(when, CalculationMethodPreset.DepartmentOfIslamicAdvancementOfMalaysia);

            // Init location info.
            var geo = new Geocoordinate(2.0, 101.0, 2.0);

            // Generate prayer times for one day on April 12th, 2018.
            var prayer = Prayers.On(when, settings, geo, TimeZone);
            Console.WriteLine($"Prayer Times at [{geo.Latitude}, {geo.Longitude}, {geo.Altitude}] for April 12th, 2018:");
            Console.WriteLine($"Imsak: {GetPrayerTimeString(prayer.Imsak)}");
            Console.WriteLine($"Fajr: {GetPrayerTimeString(prayer.Fajr)}");
            Console.WriteLine($"Sunrise: {GetPrayerTimeString(prayer.Sunrise)}");
            Console.WriteLine($"Dhuha: {GetPrayerTimeString(prayer.Dhuha)}");
            Console.WriteLine($"Dhuhr: {GetPrayerTimeString(prayer.Dhuhr)}");
            Console.WriteLine($"Asr: {GetPrayerTimeString(prayer.Asr)}");
            Console.WriteLine($"Sunset: {GetPrayerTimeString(prayer.Sunset)}");
            Console.WriteLine($"Maghrib: {GetPrayerTimeString(prayer.Maghrib)}");
            Console.WriteLine($"Isha: {GetPrayerTimeString(prayer.Isha)}");
            Console.WriteLine($"Midnight: {GetPrayerTimeString(prayer.Midnight)}");

            // Generate current prayer time
            var current = Prayer.Now(settings, geo, TimeZone, SystemClock.Instance);
            Console.WriteLine($"Current prayer at [{geo.Latitude}, {geo.Longitude}, {geo.Altitude}] for April 12th, 2018:");
            Console.WriteLine($"{current.Type} - {GetPrayerTimeString(current.Time)}");

            // Generate next prayer time
            var next = Prayer.Next(settings, geo, TimeZone, SystemClock.Instance);
            Console.WriteLine($"Next prayer at [{geo.Latitude}, {geo.Longitude}, {geo.Altitude}] for April 12th, 2018:");
            Console.WriteLine($"{next.Type} - {GetPrayerTimeString(next.Time)}");

            // Generate later prayer time
            var later = Prayer.Later(settings, geo, TimeZone, SystemClock.Instance);
            Console.WriteLine($"Later prayer at [{geo.Latitude}, {geo.Longitude}, {geo.Altitude}] for April 12th, 2018:");
            Console.WriteLine($"{later.Type} - {GetPrayerTimeString(later.Time)}");

            // Generate after later prayer time
            var afterLater = Prayer.AfterLater(settings, geo, TimeZone, SystemClock.Instance);
            Console.WriteLine($"After later prayer at [{geo.Latitude}, {geo.Longitude}, {geo.Altitude}] for April 12th, 2018:");
            Console.WriteLine($"{afterLater.Type} - {GetPrayerTimeString(afterLater.Time)}");
        }

        static string GetPrayerTimeString(Instant instant)
        {
            var zoned = instant.InZone(DateTimeZone.ForOffset(Offset.FromTimeSpan(TimeSpan.FromHours(TimeZone))));
            return zoned.ToString("HH:mm", CultureInfo.InvariantCulture);
        }
    }
}
