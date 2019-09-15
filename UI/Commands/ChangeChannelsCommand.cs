namespace UI.Commands
{
    using BL.Extensions;
    using BL.Models;
    using BL.Utils;
    using System;
    using System.Drawing;
    using System.Windows;

    using UI.ViewModels;

    /// <summary>
    /// Изменение первого канала.
    /// </summary>
    public class ChangeChannelsCommand : BaseTCommand<MainWindowVM>
    {
        /// <summary>
        /// Выполнить.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        protected override void Execute(MainWindowVM parameter)
        {
            if (parameter.CurrentBitmap == null)
            {
                MessageBox.Show("Загрузите изображение.");
                return;
            }

            switch (parameter.CurrentFormat)
            {
                case BL.Enums.FormatType.RGB:
                    ConvertAsRGB(parameter);
                    break;

                case BL.Enums.FormatType.YUV:
                    ConvertAsYUV(parameter);
                    break;

                case BL.Enums.FormatType.HSL:
                    ConvertAsHSL(parameter);
                    break;
            }
        }

        /// <summary>
        /// Выполнить преобразования в соответствии с моделью HSL.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        private static void ConvertAsHSL(MainWindowVM parameter)
        {
            var hFactor = GetFirstValue(parameter);
            var sFactor = GetSecondValue(parameter);
            var lFactor = GetThirdValue(parameter);

            var currentBitmap = parameter.CurrentBitmap;

            for (var xIndex = 0; xIndex < currentBitmap.Width; ++xIndex)
                for (var yIndex = 0; yIndex < currentBitmap.Height; ++yIndex)
                {
                    var pixel = currentBitmap.GetPixel(xIndex, yIndex);

                    var rgbModel = new RGBModel(pixel.R, pixel.G, pixel.B);
                    var hslModel = ConverterUtil.RGBtoHSL(rgbModel);

                    var h = hslModel.H + hFactor;
                    var s = hslModel.S + sFactor;
                    var l = hslModel.L + lFactor;

                    var hslUpdatedModel = new HSLModel(h, s, l);
                    var rgbUpdatedModel = ConverterUtil.HSLtoRGB(hslUpdatedModel);

                    try
                    {
                        var updatedPixel = Color.FromArgb(rgbUpdatedModel.R, rgbUpdatedModel.G,
                            rgbUpdatedModel.B);

                        currentBitmap.SetPixel(xIndex, yIndex, updatedPixel);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"Не удалось обновить изображение!\n{exception}");
                        throw;
                    }
                }

            try
            {
                parameter.Image = currentBitmap.ConvertToImageSource();
                parameter.CurrentBitmap = currentBitmap;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось обновить изображение!\n{exception}");
                throw;
            }
        }

        /// <summary>
        /// Выполнить преобразования в соответствии с моделью YUV.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        private static void ConvertAsYUV(MainWindowVM parameter)
        {
            var yFactor = GetFirstValue(parameter);
            var uFactor = GetSecondValue(parameter);
            var vFactor = GetThirdValue(parameter);

            var currentBitmap = parameter.CurrentBitmap;

            for (var xIndex = 0; xIndex < currentBitmap.Width; ++xIndex)
                for (var yIndex = 0; yIndex < currentBitmap.Height; ++yIndex)
                {
                    var pixel = currentBitmap.GetPixel(xIndex, yIndex);

                    var rgbModel = new RGBModel(pixel.R, pixel.G, pixel.B);
                    var yuvModel = ConverterUtil.RGBToYUV(rgbModel);

                    var y = yuvModel.Y + yFactor;
                    var u = yuvModel.U + uFactor;
                    var v = yuvModel.V + vFactor;

                    var yuvUpdatedModel = new YUVModel(y, u, v);
                    var rgbUpdatedModel = ConverterUtil.YUVtoRGB(yuvUpdatedModel);

                    try
                    {
                        var updatedPixel = Color.FromArgb(rgbUpdatedModel.R, rgbUpdatedModel.G,
                            rgbUpdatedModel.B);

                        currentBitmap.SetPixel(xIndex, yIndex, updatedPixel);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"Не удалось обновить изображение!\n{exception}");
                        throw;
                    }
                }

            try
            {
                parameter.Image = currentBitmap.ConvertToImageSource();
                parameter.CurrentBitmap = currentBitmap;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось обновить изображение!\n{exception}");
                throw;
            }
        }

        /// <summary>
        /// Выполнить преобразования в соответствии с моделью RGB.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        private static void ConvertAsRGB(MainWindowVM parameter)
        {
            var firstValue = GetFirstValue(parameter);
            var secondValue = GetSecondValue(parameter);
            var thirdValue = GetThirdValue(parameter);

            var currentBitmap = parameter.CurrentBitmap;

            for (var xIndex = 0; xIndex < currentBitmap.Width; ++xIndex)
                for (var yIndex = 0; yIndex < currentBitmap.Height; ++yIndex)
                {
                    var pixel = currentBitmap.GetPixel(xIndex, yIndex);

                    var rValue = pixel.R + firstValue;

                    if (rValue > byte.MaxValue)
                        rValue = byte.MaxValue;

                    if (rValue < byte.MinValue)
                        rValue = byte.MinValue;

                    var gValue = pixel.G + secondValue;

                    if (gValue > byte.MaxValue)
                        gValue = byte.MaxValue;

                    if (gValue < byte.MinValue)
                        gValue = byte.MinValue;

                    var bValue = pixel.B + thirdValue;

                    if (bValue > byte.MaxValue)
                        bValue = byte.MaxValue;

                    if (bValue < byte.MinValue)
                        bValue = byte.MinValue;

                    try
                    {
                        var updatedPixel = Color.FromArgb((byte)rValue, (byte)gValue, (byte)bValue);
                        currentBitmap.SetPixel(xIndex, yIndex, updatedPixel);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"Не удалось обновить изображение!\n{exception}");
                        throw;
                    }
                }

            try
            {
                parameter.Image = currentBitmap.ConvertToImageSource();
                parameter.CurrentBitmap = currentBitmap;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось обновить изображение!\n{exception}");
                throw;
            }
        }

        #region Получение значений.

        /// <summary>
        /// Смещение по третьему каналу.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>Возвращает смещение по третьему каналу.</returns>
        private static int GetThirdValue(MainWindowVM parameter)
        {
            var value = string.Empty;

            if (parameter.ThirdValue.Contains("."))
                value = parameter.ThirdValue.Replace(".", ",");
            else
                value = parameter.ThirdValue;

            if (!double.TryParse(value, out var doubleValue))
                MessageBox.Show($"Не удалось преобразовать данные!\n" +
                    $"{Environment.StackTrace}");

            var preparedValue = (int)doubleValue;
            return preparedValue;
        }

        /// <summary>
        /// Смещение по второму каналу.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>Возвращает смещение по второму каналу.</returns>
        private static int GetSecondValue(MainWindowVM parameter)
        {
            var value = string.Empty;

            if (parameter.SecondValue.Contains("."))
                value = parameter.SecondValue.Replace(".", ",");
            else
                value = parameter.SecondValue;

            if (!double.TryParse(value, out var doubleValue))
                MessageBox.Show($"Не удалось преобразовать данные!\n" +
                    $"{Environment.StackTrace}");

            var preparedValue = (int)doubleValue;
            return preparedValue;
        }

        /// <summary>
        /// Смещение по первому каналу.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        /// <returns>Возвращает смещение по первому каналу.</returns>
        private static int GetFirstValue(MainWindowVM parameter)
        {
            var value = string.Empty;

            if (parameter.FirstValue.Contains("."))
                value = parameter.FirstValue.Replace(".", ",");
            else
                value = parameter.FirstValue;

            if (!double.TryParse(value, out var doubleValue))
                MessageBox.Show($"Не удалось преобразовать данные!\n" +
                    $"{Environment.StackTrace}");

            var preparedValue = (int)doubleValue;
            return preparedValue;
        }

        #endregion
    }
}
