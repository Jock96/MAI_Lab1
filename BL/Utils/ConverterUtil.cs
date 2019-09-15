namespace BL.Utils
{
    using BL.Models;
    using System;

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

        /// <summary>
        /// Конвертировать RGB в HSL.
        /// </summary>
        /// <param name="rgb">RGB.</param>
        /// <returns>Возвращает HSL.</returns>
        public static HSLModel RGBtoHSL(RGBModel rgb)
        {
            var r = (rgb.R / 255d);
            var g = (rgb.G / 255d);
            var b = (rgb.B / 255d);

            var min = Math.Min(Math.Min(r, g), b);
            var max = Math.Max(Math.Max(r, g), b);
            var delta = max - min;

            var h = 0d;
            var s = 0d;
            var l = ((max + min) / 2.0d);

            if (delta != 0)
            {
                if (l < 0.5d)
                {
                    s = delta / (max + min);
                }
                else
                {
                    s = delta / (2.0d - max - min);
                }


                if (r == max)
                {
                    h = (g - b) / delta;
                }

                else if (g == max)
                {
                    h = 2d + (b - r) / delta;
                }

                else if (b == max)
                {
                    h = 4d + (r - g) / delta;
                }
            }

            return new HSLModel(h, s, l);
        }

        /// <summary>
        /// Конвертировать YUV в RGB.
        /// </summary>
        /// <param name="yuv">YUV.</param>
        /// <returns>Возвращает RGB.</returns>
        public static RGBModel YUVtoRGB(YUVModel yuv)
        {
            var r = yuv.Y + yuv.V;

            if (r > byte.MaxValue)
                r = byte.MaxValue;

            if (r < byte.MinValue)
                r = byte.MinValue;

            var g = yuv.Y - (.299000 * yuv.V + .114000 * yuv.U) / (1 - .299000 - .114000);

            if (g > byte.MaxValue)
                g = byte.MaxValue;

            if (g < byte.MinValue)
                g = byte.MinValue;

            var b = yuv.Y + yuv.U;

            if (b > byte.MaxValue)
                b = byte.MaxValue;

            if (b < byte.MinValue)
                b = byte.MinValue;

            return new RGBModel((byte)r, (byte)g, (byte)b);
        }

        /// <summary>
        /// Конвертировать HSL в RGB.
        /// </summary>
        /// <param name="hsl">HSL.</param>
        /// <returns>Возвращает RGB.</returns>
        public static RGBModel HSLtoRGB(HSLModel hsl)
        {
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if (hsl.S == 0)
            {
                r = (byte)Math.Round(hsl.L * 255d);
                g = (byte)Math.Round(hsl.L * 255d);
                b = (byte)Math.Round(hsl.L * 255d);
            }
            else
            {
                double t1, t2;
                double th = hsl.H / 6.0d;

                if (hsl.L < 0.5d)
                    t2 = hsl.L * (1d + hsl.S);
                else
                {
                    t2 = (hsl.L + hsl.S) - (hsl.L * hsl.S);

                    t1 = 2d * hsl.L - t2;

                    double tr, tg, tb;
                    tr = th + (1.0d / 3.0d);
                    tg = th;
                    tb = th - (1.0d / 3.0d);

                    tr = ColorCalculation(tr, t1, t2);
                    tg = ColorCalculation(tg, t1, t2);
                    tb = ColorCalculation(tb, t1, t2);

                    r = (byte)Math.Round(tr * 255d);
                    g = (byte)Math.Round(tg * 255d);
                    b = (byte)Math.Round(tb * 255d);
                }
            }

            return new RGBModel(r, g, b);
        }

        /// <summary>
        /// Вычисление цветов.
        /// </summary>
        private static double ColorCalculation(double c, double t1, double t2)
        {
            if (c < 0) c += 1d;

            if (c > 1) c -= 1d;

            if (6.0d * c < 1.0d)
                return t1 + (t2 - t1) * 6.0d * c;

            if (2.0d * c < 1.0d)
                return t2;

            if (3.0d * c < 2.0d)
                return t1 + (t2 - t1) * (2.0d / 3.0d - c) * 6.0d;

            return t1;
        }
    }
}
