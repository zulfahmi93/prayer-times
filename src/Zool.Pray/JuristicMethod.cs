using System;
using System.ComponentModel.DataAnnotations;


namespace Zool.Pray
{
    /// <summary>
    ///     Provides properties for holding information used for calculating asr prayer. Provides methods for getting and setting the prayer times juristic method
    ///     parameter.
    /// </summary>
    public class JuristicMethod
    {
        #region Constructors

        /// <summary>
        ///     Create a new instance of <see cref="JuristicMethod" /> object.
        /// </summary>
        public JuristicMethod()
        {
            SetJuristicMethodPreset(JuristicMethodPreset.Standard);
        }

        #endregion


        #region Properties

        /// <summary>
        ///     Gets the juristic method preset.
        /// </summary>
        [Display(Name = "Juristic Method Preset")]
        public JuristicMethodPreset Preset { get; private set; }

        /// <summary>
        ///     Gets the juristic method time of shadow parameter.
        /// </summary>
        [Display(Name = "Multiplication Factor of Shadow's Length")]
        public int TimeOfShadow { get; private set; }

        #endregion


        #region Methods

        /// <summary>
        ///     Gets the <see cref="JuristicMethodPreset" /> enumeration value which agrees to juristic method parameters held by current instance of
        ///     <see cref="JuristicMethodPreset" /> object.
        /// </summary>
        /// <returns></returns>
        public JuristicMethodPreset GetJuristicMethodPreset()
        {
            if (TimeOfShadow == 2)
            {
                Preset = JuristicMethodPreset.Hanafi;
                return JuristicMethodPreset.Hanafi;
            }

            Preset = JuristicMethodPreset.Standard;
            TimeOfShadow = 1;
            return JuristicMethodPreset.Standard;
        }

        /// <summary>
        ///     Sets the juristic method parameters from given method preset.
        /// </summary>
        /// <param name="preset">
        ///     <see cref="JuristicMethodPreset" /> value.
        /// </param>
        public void SetJuristicMethodPreset(JuristicMethodPreset preset)
        {
            switch (preset)
            {
                case JuristicMethodPreset.Standard:
                    Preset = JuristicMethodPreset.Standard;
                    TimeOfShadow = 1;
                    return;

                case JuristicMethodPreset.Hanafi:
                    Preset = JuristicMethodPreset.Hanafi;
                    TimeOfShadow = 2;
                    return;

                default:
                    throw new ArgumentOutOfRangeException(nameof(preset));
            }
        }

        #endregion
    }
}
