using System.ComponentModel.DataAnnotations;


namespace Zool.Pray
{
    /// <summary>
    ///     Represents the prayer times juristic method preset.
    /// </summary>
    public enum JuristicMethodPreset
    {
        /// <summary>
        ///     Standard juristic method.
        /// </summary>
        [Display(Name = "Standard (Shafi'i, Maliki and Hanbali)")]
        Standard,

        /// <summary>
        ///     Hanafi juristic method.
        /// </summary>
        [Display(Name = "Hanafi")]
        Hanafi
    }
}
