using System;
using System.Collections.Generic;

using NodaTime;

using Xunit;


namespace Zool.Pray.Tests
{
    public class CalculationMethodTests
    {
        public static IEnumerable<object[]> UmmQuraTestData =>
            new[]
            {
                new object[] { new DateTime(2004, 2, 22, 0, 0, 0, DateTimeKind.Utc) },
                new object[] { new DateTime(2004, 10, 15, 0, 0, 0, DateTimeKind.Utc) },
                new object[] { new DateTime(2013, 11, 5, 0, 0, 0, DateTimeKind.Utc) },
                new object[] { new DateTime(2014, 6, 29, 0, 0, 0, DateTimeKind.Utc) }
            };

        [Fact(DisplayName = "Test get Egyptian General Authority of Survey CalculationMethod preset.")]
        public void TestGetEgyptianGeneralAuthorityOfSurveyPreset()
        {
            var method = new CalculationMethod();
            method.SetCustomCalculationMethod(19.5,
                                              0.0,
                                              PrayerCalculationParameterType.MinutesAdjust,
                                              17.5,
                                              PrayerCalculationParameterType.Angle,
                                              Midnight.Standard);

            Assert.Equal(CalculationMethodPreset.EgyptianGeneralAuthorityOfSurvey, method.GetCalculationMethodPreset());
        }

        [Fact(DisplayName = "Test get Institute of Geophysics, University of Tehran CalculationMethod preset.")]
        public void TestGetInstituteOfGeophysicsUniversityOfTehranPreset()
        {
            var method = new CalculationMethod();
            method.SetCustomCalculationMethod(17.7,
                                              4.5,
                                              PrayerCalculationParameterType.Angle,
                                              14.0,
                                              PrayerCalculationParameterType.Angle,
                                              Midnight.Jafari);

            Assert.Equal(CalculationMethodPreset.InstituteOfGeophysicsUniversityOfTehran, method.GetCalculationMethodPreset());
        }

        [Fact(DisplayName = "Test get Islamic Society of North America CalculationMethod preset.")]
        public void TestGetIslamicSocietyOfNorthAmericaPreset()
        {
            var method = new CalculationMethod();
            method.SetCustomCalculationMethod(15.0,
                                              0.0,
                                              PrayerCalculationParameterType.MinutesAdjust,
                                              15.0,
                                              PrayerCalculationParameterType.Angle,
                                              Midnight.Standard);

            Assert.Equal(CalculationMethodPreset.IslamicSocietyOfNorthAmerica, method.GetCalculationMethodPreset());
        }

        [Fact(DisplayName = "Test get Ithna Ashari CalculationMethod preset.")]
        public void TestGetIthnaAshariPreset()
        {
            var method = new CalculationMethod();
            method.SetCustomCalculationMethod(16.0,
                                              4.0,
                                              PrayerCalculationParameterType.Angle,
                                              14.0,
                                              PrayerCalculationParameterType.Angle,
                                              Midnight.Jafari);

            Assert.Equal(CalculationMethodPreset.IthnaAshari, method.GetCalculationMethodPreset());
        }

        [Fact(DisplayName = "Test get Majlis Ugama Islam Singapura CalculationMethod preset.")]
        public void TestGetMajlisUgamaIslamSingapuraPreset()
        {
            var method = new CalculationMethod();
            method.SetCustomCalculationMethod(20.0,
                                              0.0,
                                              PrayerCalculationParameterType.MinutesAdjust,
                                              18.0,
                                              PrayerCalculationParameterType.Angle,
                                              Midnight.Standard);

            Assert.Equal(CalculationMethodPreset.MajlisUgamaIslamSingapura, method.GetCalculationMethodPreset());
        }

        [Fact(DisplayName = "Test get Muslim World League CalculationMethod preset.")]
        public void TestGetMuslimWorldLeaguePreset()
        {
            var method = new CalculationMethod();
            method.SetCustomCalculationMethod(18.0,
                                              0.0,
                                              PrayerCalculationParameterType.MinutesAdjust,
                                              17.0,
                                              PrayerCalculationParameterType.Angle,
                                              Midnight.Standard);

            Assert.Equal(CalculationMethodPreset.MuslimWorldLeague, method.GetCalculationMethodPreset());
        }

        [Fact(DisplayName = "Test get Umm Al-Qura University, Makkah CalculationMethod preset.")]
        public void TestGetUmmAlQuraUniversityPreset()
        {
            var method1 = new CalculationMethod();
            var method2 = new CalculationMethod();
            var method3 = new CalculationMethod();
            var method4 = new CalculationMethod();

            method1.SetCustomCalculationMethod(19.0,
                                               0.0,
                                               PrayerCalculationParameterType.MinutesAdjust,
                                               90.0,
                                               PrayerCalculationParameterType.MinutesAdjust,
                                               Midnight.Standard);
            method2.SetCustomCalculationMethod(19.0,
                                               0.0,
                                               PrayerCalculationParameterType.MinutesAdjust,
                                               120.0,
                                               PrayerCalculationParameterType.MinutesAdjust,
                                               Midnight.Standard);
            method3.SetCustomCalculationMethod(18.5,
                                               0.0,
                                               PrayerCalculationParameterType.MinutesAdjust,
                                               90.0,
                                               PrayerCalculationParameterType.MinutesAdjust,
                                               Midnight.Standard);
            method4.SetCustomCalculationMethod(18.5,
                                               0.0,
                                               PrayerCalculationParameterType.MinutesAdjust,
                                               120.0,
                                               PrayerCalculationParameterType.MinutesAdjust,
                                               Midnight.Standard);

            Assert.Equal(CalculationMethodPreset.UmmAlQuraUniversity, method1.GetCalculationMethodPreset());
            Assert.Equal(CalculationMethodPreset.UmmAlQuraUniversity, method2.GetCalculationMethodPreset());
            Assert.Equal(CalculationMethodPreset.UmmAlQuraUniversity, method3.GetCalculationMethodPreset());
            Assert.Equal(CalculationMethodPreset.UmmAlQuraUniversity, method4.GetCalculationMethodPreset());
        }

        [Fact(DisplayName = "Test get Union des Organisations Islamiques de France CalculationMethod preset.")]
        public void TestGetUnionDesOrganisationsIslamiquesDeFrancePreset()
        {
            var method = new CalculationMethod();
            method.SetCustomCalculationMethod(12.0,
                                              0.0,
                                              PrayerCalculationParameterType.MinutesAdjust,
                                              12.0,
                                              PrayerCalculationParameterType.Angle,
                                              Midnight.Standard);

            Assert.Equal(CalculationMethodPreset.UnionDesOrganisationsIslamiquesDeFrance, method.GetCalculationMethodPreset());
        }

        [Fact(DisplayName = "Test get University of Islamic Sciences, Karachi CalculationMethod preset.")]
        public void TestGetUniversityOfIslamicSciencesKarachiPreset()
        {
            var method = new CalculationMethod();
            method.SetCustomCalculationMethod(18.0,
                                              0.0,
                                              PrayerCalculationParameterType.MinutesAdjust,
                                              18.0,
                                              PrayerCalculationParameterType.Angle,
                                              Midnight.Standard);

            Assert.Equal(CalculationMethodPreset.UniversityOfIslamicSciencesKarachi, method.GetCalculationMethodPreset());
        }

        [Fact(DisplayName = "Test set CalculationMethod using custom calculation parameter.")]
        public void TestSetCustomParameter()
        {
            var method = new CalculationMethod();
            method.SetCustomCalculationMethod(13.0,
                                              0.5,
                                              PrayerCalculationParameterType.MinutesAdjust,
                                              13.5,
                                              PrayerCalculationParameterType.Angle,
                                              Midnight.Standard);

            Assert.Equal(CalculationMethodPreset.Custom, method.Preset);
            Assert.Equal(13.0, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.5, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(13.5, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod to invalid preset should throw error.")]
        public void TestSetInvalidPresetError()
        {
            var method = new CalculationMethod();
            Assert.Throws<ArgumentOutOfRangeException>(() => method.SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(),
                                                                                               CalculationMethodPreset.Custom));
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Department of Islamic Advancement, Malaysia.")]
        public void TestSetPresetDepartmentOfIslamicAdvancementOfMalaysia()
        {
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(), CalculationMethodPreset.DepartmentOfIslamicAdvancementOfMalaysia);

            Assert.Equal(CalculationMethodPreset.DepartmentOfIslamicAdvancementOfMalaysia, method.Preset);
            Assert.Equal(20.0, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(18.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Egyptian General Authority of Survey.")]
        public void TestSetPresetEgyptianGeneralAuthorityOfSurvey()
        {
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(), CalculationMethodPreset.EgyptianGeneralAuthorityOfSurvey);

            Assert.Equal(CalculationMethodPreset.EgyptianGeneralAuthorityOfSurvey, method.Preset);
            Assert.Equal(19.5, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(17.5, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Institute of Geophysics, University of Tehran.")]
        public void TestSetPresetInstituteOfGeophysicsUniversityOfTehran()
        {
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(), CalculationMethodPreset.InstituteOfGeophysicsUniversityOfTehran);

            Assert.Equal(CalculationMethodPreset.InstituteOfGeophysicsUniversityOfTehran, method.Preset);
            Assert.Equal(17.7, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(4.5, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.MaghribParameter.Type);
            Assert.Equal(14.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.IshaParameter.Type);
            Assert.Equal(Midnight.Jafari, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Islamic Society of North America.")]
        public void TestSetPresetIslamicSocietyOfNorthAmerica()
        {
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(), CalculationMethodPreset.IslamicSocietyOfNorthAmerica);

            Assert.Equal(CalculationMethodPreset.IslamicSocietyOfNorthAmerica, method.Preset);
            Assert.Equal(15.0, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(15.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Ithna Ashari.")]
        public void TestSetPresetIthnaAshari()
        {
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(), CalculationMethodPreset.IthnaAshari);

            Assert.Equal(CalculationMethodPreset.IthnaAshari, method.Preset);
            Assert.Equal(16.0, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(4.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.MaghribParameter.Type);
            Assert.Equal(14.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.IshaParameter.Type);
            Assert.Equal(Midnight.Jafari, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Majlis Ugama Islam Singapura.")]
        public void TestSetPresetMajlisUgamaIslamSingapura()
        {
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(), CalculationMethodPreset.MajlisUgamaIslamSingapura);

            Assert.Equal(CalculationMethodPreset.MajlisUgamaIslamSingapura, method.Preset);
            Assert.Equal(20.0, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(18.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Muslim World League.")]
        public void TestSetPresetMuslimWorldLeague()
        {
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(), CalculationMethodPreset.MuslimWorldLeague);

            Assert.Equal(CalculationMethodPreset.MuslimWorldLeague, method.Preset);
            Assert.Equal(18.0, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(17.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Ummul Qura for Muharram 1st, 1425H.")]
        // ReSharper disable once InconsistentNaming
        public void TestSetPresetUmmAlQuraUniversityOnMuharram1st1425H()
        {
            var dateTime = new DateTime(2004, 2, 22, 0, 0, 0, DateTimeKind.Utc);
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(Instant.FromDateTimeUtc(dateTime), CalculationMethodPreset.UmmAlQuraUniversity);

            Assert.Equal(CalculationMethodPreset.UmmAlQuraUniversity, method.Preset);
            Assert.Equal(19.0, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(90.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Ummul Qura for Muharram 1st, 1435H.")]
        // ReSharper disable once InconsistentNaming
        public void TestSetPresetUmmAlQuraUniversityOnMuharram1st1435H()
        {
            var dateTime = new DateTime(2013, 11, 5, 0, 0, 0, DateTimeKind.Utc);
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(Instant.FromDateTimeUtc(dateTime), CalculationMethodPreset.UmmAlQuraUniversity);

            Assert.Equal(CalculationMethodPreset.UmmAlQuraUniversity, method.Preset);
            Assert.Equal(18.5, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(90.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Ummul Qura for Ramadhan 1st, 1425H.")]
        // ReSharper disable once InconsistentNaming
        public void TestSetPresetUmmAlQuraUniversityOnRamadhan1st1425H()
        {
            var dateTime = new DateTime(2004, 10, 15, 0, 0, 0, DateTimeKind.Utc);
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(Instant.FromDateTimeUtc(dateTime), CalculationMethodPreset.UmmAlQuraUniversity);

            Assert.Equal(CalculationMethodPreset.UmmAlQuraUniversity, method.Preset);
            Assert.Equal(19.0, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(120.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Ummul Qura for Ramadhan 1st, 1435H.")]
        // ReSharper disable once InconsistentNaming
        public void TestSetPresetUmmAlQuraUniversityOnRamadhan1st1435H()
        {
            var dateTime = new DateTime(2014, 6, 29, 0, 0, 0, DateTimeKind.Utc);
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(Instant.FromDateTimeUtc(dateTime), CalculationMethodPreset.UmmAlQuraUniversity);

            Assert.Equal(CalculationMethodPreset.UmmAlQuraUniversity, method.Preset);
            Assert.Equal(18.5, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(120.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to Union des Organisations Islamiques de France.")]
        public void TestSetPresetUnionDesOrganisationsIslamiquesDeFrance()
        {
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(), CalculationMethodPreset.UnionDesOrganisationsIslamiquesDeFrance);

            Assert.Equal(CalculationMethodPreset.UnionDesOrganisationsIslamiquesDeFrance, method.Preset);
            Assert.Equal(12.0, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(12.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }

        [Fact(DisplayName = "Test set CalculationMethod preset to University of Islamic Sciences, Karachi.")]
        public void TestSetPresetUniversityOfIslamicSciencesKarachi()
        {
            var method = new CalculationMethod();
            method.SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(), CalculationMethodPreset.UniversityOfIslamicSciencesKarachi);

            Assert.Equal(CalculationMethodPreset.UniversityOfIslamicSciencesKarachi, method.Preset);
            Assert.Equal(18.0, method.FajrParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.FajrParameter.Type);
            Assert.Equal(0.0, method.MaghribParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.MinutesAdjust, method.MaghribParameter.Type);
            Assert.Equal(18.0, method.IshaParameter.Value, 5);
            Assert.Equal(PrayerCalculationParameterType.Angle, method.IshaParameter.Type);
            Assert.Equal(Midnight.Standard, method.MidnightMethod);
        }
    }
}
