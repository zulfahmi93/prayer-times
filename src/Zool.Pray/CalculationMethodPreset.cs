using System.ComponentModel.DataAnnotations;


namespace Zool.Pray
{
    /// <summary>
    ///     Calculation method preset.
    /// </summary>
    public enum CalculationMethodPreset
    {
        /// <summary>
        ///     Custom calculation method.
        /// </summary>
        [Display(Name = "Custom")]
        Custom,

        /// <summary>
        ///     Ithna Ashari calculation method.
        /// </summary>
        [Display(Name = "Ithna Ashari")]
        IthnaAshari,

        /// <summary>
        ///     University of Islamic Sciences, Karachi calculation method.
        /// </summary>
        [Display(Name = "University of Islamic Sciences, Karachi")]
        UniversityOfIslamicSciencesKarachi,

        /// <summary>
        ///     Islamic Society of North America calculation method.
        /// </summary>
        [Display(Name = "Islamic Society of North America (ISNA)")]
        IslamicSocietyOfNorthAmerica,

        /// <summary>
        ///     Muslim World League calculation method.
        /// </summary>
        [Display(Name = "Muslim World League")]
        MuslimWorldLeague,

        /// <summary>
        ///     Umm Al-Qura University calculation method.
        /// </summary>
        [Display(Name = "Umm Al-Qura University, Makkah")]
        UmmAlQuraUniversity,

        /// <summary>
        ///     Egyptian General Authority of Survey calculation method.
        /// </summary>
        [Display(Name = "Egyptian General Authority of Survey")]
        EgyptianGeneralAuthorityOfSurvey,

        /// <summary>
        ///     Institute of Geophysics, University of Tehran calculation method.
        /// </summary>
        [Display(Name = "Institute of Geophysics, University of Tehran")]
        InstituteOfGeophysicsUniversityOfTehran,

        /// <summary>
        ///     Union Des Organisations Islamiques De France calculation method.
        /// </summary>
        [Display(Name = "Union of Islamic Organisations of France")]
        UnionDesOrganisationsIslamiquesDeFrance,

        /// <summary>
        ///     Majlis Ugama Islam Singapura calculation method.
        /// </summary>
        [Display(Name = "Islamic Religious Council of Singapore")]
        MajlisUgamaIslamSingapura,

        /// <summary>
        ///     Department of Islamic Advancement of Malaysia calculation method.
        /// </summary>
        [Display(Name = "Department of Islamic Advancement of Malaysia")]
        DepartmentOfIslamicAdvancementOfMalaysia
    }
}
