namespace BL.Utils
{
    using BL.Models;

    /// <summary>
    /// Инструмент конвертирования.
    /// </summary>
    public static class ConverterUtil
    {
        /// <summary>
        /// Конвертировать RGB в YUV.
        /// </summary>
        /// <param name="rgb">RGB.</param>
        /// <returns>Возвращает YUV.</returns>
        public static YUVModel RGBToYUV(RGBModel rgb)
        {
            double y = rgb.R * .299000 + rgb.G * .587000 + rgb.B * .114000;
            double u = rgb.R * -.168736 + rgb.G * -.331264 + rgb.B * .500000 + 128;
            double v = rgb.R * .500000 + rgb.G * -.418688 + rgb.B * -.081312 + 128;

            return new YUVModel(y, u, v);
        }
    }
}
