using System.ComponentModel;

namespace BL.Enums
{
    /// <summary>
    /// Типы форматов.
    /// </summary>
    public enum FormatType
    {
        /// <summary>
        /// Тип RGB.
        /// </summary>
        [Description("RGB")]
        RGB,

        /// <summary>
        /// Тип YUV.
        /// </summary>
        [Description("YUV")]
        YUV,

        /// <summary>
        /// Тип HSL.
        /// </summary>
        [Description("HSL")]
        HSL,

        /// <summary>
        /// Без типа.
        /// </summary>
        [Description("Нет")]
        NONE
    }
}
