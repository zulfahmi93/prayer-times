using System;

using NodaTime;

using Zool.Pray.Maths;


namespace Zool.Pray
{
    /// <summary>
    ///     Provides properties for holding information used for calculating fajr, maghrib and isha prayers. Provides methods for getting and setting the prayer times
    ///     calculation method parameter.
    /// </summary>
    public class CalculationMethod
    {
        #region Constructors

        /// <summary>
        ///     Create a new instance of <see cref="CalculationMethod" /> object.
        /// </summary>
        public CalculationMethod()
        {
            FajrParameter = new PrayerCalculationParameter(0.0, PrayerCalculationParameterType.MinutesAdjust);
            MaghribParameter = new PrayerCalculationParameter(0.0, PrayerCalculationParameterType.MinutesAdjust);
            IshaParameter = new PrayerCalculationParameter(0.0, PrayerCalculationParameterType.MinutesAdjust);
            SetCalculationMethodPreset(SystemClock.Instance.GetCurrentInstant(), CalculationMethodPreset.UmmAlQuraUniversity);
        }

        #endregion


        #region Properties

        /// <summary>
        ///     Gets the calculation method preset.
        /// </summary>
        public CalculationMethodPreset Preset { get; private set; }

        /// <summary>
        ///     Gets the calculation parameter for fajr prayer.
        /// </summary>
        public PrayerCalculationParameter FajrParameter { get; }

        /// <summary>
        ///     Gets the calculation parameter for maghrib prayer.
        /// </summary>
        public PrayerCalculationParameter MaghribParameter { get; }

        /// <summary>
        ///     Gets the calculation parameter for isha prayer.
        /// </summary>
        public PrayerCalculationParameter IshaParameter { get; }

        /// <summary>
        ///     Gets the calculation parameter for midnight.
        /// </summary>
        public Midnight MidnightMethod { get; private set; }

        #endregion


        #region Methods

        /// <summary>
        ///     Gets the <see cref="CalculationMethodPreset" /> enumeration value which agrees to calculation method parameters held by current instance of
        ///     <see cref="CalculationMethod" /> object.
        /// </summary>
        /// <returns>
        ///     <see cref="CalculationMethodPreset" /> enumeration value.
        /// </returns>
        public CalculationMethodPreset GetCalculationMethodPreset()
        {
            //
            // JAKIM.
            if (Preset == CalculationMethodPreset.DepartmentOfIslamicAdvancementOfMalaysia)
            {
                return CalculationMethodPreset.DepartmentOfIslamicAdvancementOfMalaysia;
            }

            //
            // Ithna Ashari
            if ((Math.Abs(FajrParameter.Value - 16.0) < Tolerance.Course) &&
                (FajrParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(MaghribParameter.Value - 4.0) < Tolerance.Course) &&
                (MaghribParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(IshaParameter.Value - 14.0) < Tolerance.Course) &&
                (IshaParameter.Type == PrayerCalculationParameterType.Angle) &&
                (MidnightMethod == Midnight.Jafari))
            {
                Preset = CalculationMethodPreset.IthnaAshari;
                return CalculationMethodPreset.IthnaAshari;
            }

            //
            // University of Islamic Sciences, Karachi
            if ((Math.Abs(FajrParameter.Value - 18.0) < Tolerance.Course) &&
                (FajrParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(MaghribParameter.Value - 0.0) < Tolerance.Course) &&
                (MaghribParameter.Type == PrayerCalculationParameterType.MinutesAdjust) &&
                (Math.Abs(IshaParameter.Value - 18.0) < Tolerance.Course) &&
                (IshaParameter.Type == PrayerCalculationParameterType.Angle) &&
                (MidnightMethod == Midnight.Standard))
            {
                Preset = CalculationMethodPreset.UniversityOfIslamicSciencesKarachi;
                return CalculationMethodPreset.UniversityOfIslamicSciencesKarachi;
            }

            //
            // Islamic Society of North America
            if ((Math.Abs(FajrParameter.Value - 15.0) < Tolerance.Course) &&
                (FajrParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(MaghribParameter.Value - 0.0) < Tolerance.Course) &&
                (MaghribParameter.Type == PrayerCalculationParameterType.MinutesAdjust) &&
                (Math.Abs(IshaParameter.Value - 15.0) < Tolerance.Course) &&
                (IshaParameter.Type == PrayerCalculationParameterType.Angle) &&
                (MidnightMethod == Midnight.Standard))
            {
                Preset = CalculationMethodPreset.IslamicSocietyOfNorthAmerica;
                return CalculationMethodPreset.IslamicSocietyOfNorthAmerica;
            }

            //
            // Muslim World League
            if ((Math.Abs(FajrParameter.Value - 18.0) < Tolerance.Course) &&
                (FajrParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(MaghribParameter.Value - 0.0) < Tolerance.Course) &&
                (MaghribParameter.Type == PrayerCalculationParameterType.MinutesAdjust) &&
                (Math.Abs(IshaParameter.Value - 17.0) < Tolerance.Course) &&
                (IshaParameter.Type == PrayerCalculationParameterType.Angle) &&
                (MidnightMethod == Midnight.Standard))
            {
                Preset = CalculationMethodPreset.MuslimWorldLeague;
                return CalculationMethodPreset.MuslimWorldLeague;
            }

            //
            // Umm Al-Qura University, Makkah
            if (((Math.Abs(FajrParameter.Value - 19.0) < Tolerance.Course) || (Math.Abs(FajrParameter.Value - 18.5) < Tolerance.Course)) &&
                (FajrParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(MaghribParameter.Value - 0.0) < Tolerance.Course) &&
                (MaghribParameter.Type == PrayerCalculationParameterType.MinutesAdjust) &&
                ((Math.Abs(IshaParameter.Value - 90.0) < Tolerance.Course) || (Math.Abs(IshaParameter.Value - 120.0) < Tolerance.Course)) &&
                (IshaParameter.Type == PrayerCalculationParameterType.MinutesAdjust) &&
                (MidnightMethod == Midnight.Standard))
            {
                Preset = CalculationMethodPreset.UmmAlQuraUniversity;
                return CalculationMethodPreset.UmmAlQuraUniversity;
            }

            //
            // Egyptian General Authority of Survey
            if ((Math.Abs(FajrParameter.Value - 19.5) < Tolerance.Course) &&
                (FajrParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(MaghribParameter.Value - 0.0) < Tolerance.Course) &&
                (MaghribParameter.Type == PrayerCalculationParameterType.MinutesAdjust) &&
                (Math.Abs(IshaParameter.Value - 17.5) < Tolerance.Course) &&
                (IshaParameter.Type == PrayerCalculationParameterType.Angle) &&
                (MidnightMethod == Midnight.Standard))
            {
                Preset = CalculationMethodPreset.EgyptianGeneralAuthorityOfSurvey;
                return CalculationMethodPreset.EgyptianGeneralAuthorityOfSurvey;
            }

            //
            // Union des Organisations Islamiques de France
            if ((Math.Abs(FajrParameter.Value - 12.0) < Tolerance.Course) &&
                (FajrParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(MaghribParameter.Value - 0.0) < Tolerance.Course) &&
                (MaghribParameter.Type == PrayerCalculationParameterType.MinutesAdjust) &&
                (Math.Abs(IshaParameter.Value - 12.0) < Tolerance.Course) &&
                (IshaParameter.Type == PrayerCalculationParameterType.Angle) &&
                (MidnightMethod == Midnight.Standard))
            {
                Preset = CalculationMethodPreset.UnionDesOrganisationsIslamiquesDeFrance;
                return CalculationMethodPreset.UnionDesOrganisationsIslamiquesDeFrance;
            }

            //
            // Majlis Ugama Islam Singapura
            if ((Math.Abs(FajrParameter.Value - 20.0) < Tolerance.Course) &&
                (FajrParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(MaghribParameter.Value - 0.0) < Tolerance.Course) &&
                (MaghribParameter.Type == PrayerCalculationParameterType.MinutesAdjust) &&
                (Math.Abs(IshaParameter.Value - 18.0) < Tolerance.Course) &&
                (IshaParameter.Type == PrayerCalculationParameterType.Angle) &&
                (MidnightMethod == Midnight.Standard))
            {
                Preset = CalculationMethodPreset.MajlisUgamaIslamSingapura;
                return CalculationMethodPreset.MajlisUgamaIslamSingapura;
            }

            //
            // Institute of Geophysics, University of Tehran
            if ((Math.Abs(FajrParameter.Value - 17.7) < Tolerance.Course) &&
                (FajrParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(MaghribParameter.Value - 4.5) < Tolerance.Course) &&
                (MaghribParameter.Type == PrayerCalculationParameterType.Angle) &&
                (Math.Abs(IshaParameter.Value - 14.0) < Tolerance.Course) &&
                (IshaParameter.Type == PrayerCalculationParameterType.Angle) &&
                (MidnightMethod == Midnight.Jafari))
            {
                Preset = CalculationMethodPreset.InstituteOfGeophysicsUniversityOfTehran;
                return CalculationMethodPreset.InstituteOfGeophysicsUniversityOfTehran;
            }

            //
            // Custom.
            Preset = CalculationMethodPreset.Custom;
            return CalculationMethodPreset.Custom;
        }

        /// <summary>
        ///     Sets the calculation method parameters from given method preset.
        /// </summary>
        /// <param name="instant">
        ///     <see cref="Instant" /> of time.
        /// </param>
        /// <param name="preset">
        ///     <see cref="CalculationMethodPreset" /> to set.
        /// </param>
        public void SetCalculationMethodPreset(Instant instant, CalculationMethodPreset preset)
        {
            //
            // Umm Al-Qura University, Makkah
            if (preset == CalculationMethodPreset.UmmAlQuraUniversity)
            {
                // Convert Gregorian date to Hijri.
                var calendarSystem = CalendarSystem.IslamicBcl;
                var hijri = instant.InUtc().WithCalendar(calendarSystem);
                var isBefore1430H = hijri.Year < 1430;
                var isRamadhan = hijri.Month == 9;

                Preset = CalculationMethodPreset.UmmAlQuraUniversity;
                FajrParameter.Value = isBefore1430H ? 19 : 18.5;
                FajrParameter.Type = PrayerCalculationParameterType.Angle;
                MaghribParameter.Value = 0.0;
                MaghribParameter.Type = PrayerCalculationParameterType.MinutesAdjust;
                IshaParameter.Value = isRamadhan ? 120.0 : 90.0;
                IshaParameter.Type = PrayerCalculationParameterType.MinutesAdjust;
                MidnightMethod = Midnight.Standard;
                return;
            }

            switch (preset)
            {
                case CalculationMethodPreset.IthnaAshari:
                    Preset = CalculationMethodPreset.IthnaAshari;
                    FajrParameter.Value = 16.0;
                    FajrParameter.Type = PrayerCalculationParameterType.Angle;
                    MaghribParameter.Value = 4.0;
                    MaghribParameter.Type = PrayerCalculationParameterType.Angle;
                    IshaParameter.Value = 14.0;
                    IshaParameter.Type = PrayerCalculationParameterType.Angle;
                    MidnightMethod = Midnight.Jafari;
                    return;

                case CalculationMethodPreset.UniversityOfIslamicSciencesKarachi:
                    Preset = CalculationMethodPreset.UniversityOfIslamicSciencesKarachi;
                    FajrParameter.Value = 18.0;
                    FajrParameter.Type = PrayerCalculationParameterType.Angle;
                    MaghribParameter.Value = 0.0;
                    MaghribParameter.Type = PrayerCalculationParameterType.MinutesAdjust;
                    IshaParameter.Value = 18.0;
                    IshaParameter.Type = PrayerCalculationParameterType.Angle;
                    MidnightMethod = Midnight.Standard;
                    return;

                case CalculationMethodPreset.IslamicSocietyOfNorthAmerica:
                    Preset = CalculationMethodPreset.IslamicSocietyOfNorthAmerica;
                    FajrParameter.Value = 15.0;
                    FajrParameter.Type = PrayerCalculationParameterType.Angle;
                    MaghribParameter.Value = 0.0;
                    MaghribParameter.Type = PrayerCalculationParameterType.MinutesAdjust;
                    IshaParameter.Value = 15.0;
                    IshaParameter.Type = PrayerCalculationParameterType.Angle;
                    MidnightMethod = Midnight.Standard;
                    return;

                case CalculationMethodPreset.MuslimWorldLeague:
                    Preset = CalculationMethodPreset.MuslimWorldLeague;
                    FajrParameter.Value = 18.0;
                    FajrParameter.Type = PrayerCalculationParameterType.Angle;
                    MaghribParameter.Value = 0.0;
                    MaghribParameter.Type = PrayerCalculationParameterType.MinutesAdjust;
                    IshaParameter.Value = 17.0;
                    IshaParameter.Type = PrayerCalculationParameterType.Angle;
                    MidnightMethod = Midnight.Standard;
                    return;

                case CalculationMethodPreset.EgyptianGeneralAuthorityOfSurvey:
                    Preset = CalculationMethodPreset.EgyptianGeneralAuthorityOfSurvey;
                    FajrParameter.Value = 19.5;
                    FajrParameter.Type = PrayerCalculationParameterType.Angle;
                    MaghribParameter.Value = 0.0;
                    MaghribParameter.Type = PrayerCalculationParameterType.MinutesAdjust;
                    IshaParameter.Value = 17.5;
                    IshaParameter.Type = PrayerCalculationParameterType.Angle;
                    MidnightMethod = Midnight.Standard;
                    return;

                case CalculationMethodPreset.InstituteOfGeophysicsUniversityOfTehran:
                    Preset = CalculationMethodPreset.InstituteOfGeophysicsUniversityOfTehran;
                    FajrParameter.Value = 17.7;
                    FajrParameter.Type = PrayerCalculationParameterType.Angle;
                    MaghribParameter.Value = 4.5;
                    MaghribParameter.Type = PrayerCalculationParameterType.Angle;
                    IshaParameter.Value = 14.0;
                    IshaParameter.Type = PrayerCalculationParameterType.Angle;
                    MidnightMethod = Midnight.Jafari;
                    return;

                case CalculationMethodPreset.UnionDesOrganisationsIslamiquesDeFrance:
                    Preset = CalculationMethodPreset.UnionDesOrganisationsIslamiquesDeFrance;
                    FajrParameter.Value = 12.0;
                    FajrParameter.Type = PrayerCalculationParameterType.Angle;
                    MaghribParameter.Value = 0.0;
                    MaghribParameter.Type = PrayerCalculationParameterType.MinutesAdjust;
                    IshaParameter.Value = 12.0;
                    IshaParameter.Type = PrayerCalculationParameterType.Angle;
                    MidnightMethod = Midnight.Standard;
                    return;

                case CalculationMethodPreset.MajlisUgamaIslamSingapura:
                    Preset = CalculationMethodPreset.MajlisUgamaIslamSingapura;
                    FajrParameter.Value = 20.0;
                    FajrParameter.Type = PrayerCalculationParameterType.Angle;
                    MaghribParameter.Value = 0.0;
                    MaghribParameter.Type = PrayerCalculationParameterType.MinutesAdjust;
                    IshaParameter.Value = 18.0;
                    IshaParameter.Type = PrayerCalculationParameterType.Angle;
                    MidnightMethod = Midnight.Standard;
                    return;

                case CalculationMethodPreset.DepartmentOfIslamicAdvancementOfMalaysia:
                    Preset = CalculationMethodPreset.DepartmentOfIslamicAdvancementOfMalaysia;
                    FajrParameter.Value = 20.0;
                    FajrParameter.Type = PrayerCalculationParameterType.Angle;
                    MaghribParameter.Value = 0.0;
                    MaghribParameter.Type = PrayerCalculationParameterType.MinutesAdjust;
                    IshaParameter.Value = 18.0;
                    IshaParameter.Type = PrayerCalculationParameterType.Angle;
                    MidnightMethod = Midnight.Standard;
                    return;

                default:
                    throw new ArgumentOutOfRangeException(nameof(preset));
            }
        }

        /// <summary>
        ///     Sets the calculation method parameters using custom parameters.
        /// </summary>
        /// <param name="fajrAngleParameter">
        ///     Custom fajr prayer angle calculation parameter.
        /// </param>
        /// <param name="maghribParameter">
        ///     Custom maghrib prayer calculation parameter value.
        /// </param>
        /// <param name="maghribParameterType">
        ///     Custom maghrib prayer calculation parameter type.
        /// </param>
        /// <param name="ishaParameter">
        ///     Custom isha prayer calculation parameter value.
        /// </param>
        /// <param name="ishaParameterType">
        ///     Custom isha prayer calculation parameter type.
        /// </param>
        /// <param name="midnight">
        ///     Midnight time calculation method.
        /// </param>
        public void SetCustomCalculationMethod(double fajrAngleParameter,
                                               double maghribParameter,
                                               PrayerCalculationParameterType maghribParameterType,
                                               double ishaParameter,
                                               PrayerCalculationParameterType ishaParameterType,
                                               Midnight midnight)
        {
            Preset = CalculationMethodPreset.Custom;
            FajrParameter.Value = fajrAngleParameter;
            FajrParameter.Type = PrayerCalculationParameterType.Angle;
            MaghribParameter.Value = maghribParameter;
            MaghribParameter.Type = maghribParameterType;
            IshaParameter.Value = ishaParameter;
            IshaParameter.Type = ishaParameterType;
            MidnightMethod = midnight;
        }

        #endregion
    }
}
