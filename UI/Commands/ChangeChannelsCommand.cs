namespace UI.Commands
{
    using BL.Extensions;

    using System;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Input;

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

            var firstValue = GetFirstValue(parameter);
            var secondValue = GetSecondValue(parameter);
            var thirdValue = GetThirdValue(parameter);

            var currentBitmap = parameter.CurrentBitmap;
            var maxProgressValue = parameter.CurrentBitmap.Width * currentBitmap.Height;

            var currentIteration = 0;

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

        private static int GetThirdValue(MainWindowVM parameter)
        {
            var firstValueString = string.Empty;

            if (parameter.FirstValue.Contains("."))
                firstValueString = parameter.ThirdValue.Replace(".", ",");
            else
                firstValueString = parameter.ThirdValue;

            if (!double.TryParse(firstValueString, out var doubleValue))
                MessageBox.Show($"Не удалось преобразовать данные!\n" +
                    $"{Environment.StackTrace}");

            var preparedValue = (int)doubleValue;
            return preparedValue;
        }

        private static int GetSecondValue(MainWindowVM parameter)
        {
            var firstValueString = string.Empty;

            if (parameter.FirstValue.Contains("."))
                firstValueString = parameter.SecondValue.Replace(".", ",");
            else
                firstValueString = parameter.SecondValue;

            if (!double.TryParse(firstValueString, out var doubleValue))
                MessageBox.Show($"Не удалось преобразовать данные!\n" +
                    $"{Environment.StackTrace}");

            var preparedValue = (int)doubleValue;
            return preparedValue;
        }

        private static int GetFirstValue(MainWindowVM parameter)
        {
            var firstValueString = string.Empty;

            if (parameter.FirstValue.Contains("."))
                firstValueString = parameter.FirstValue.Replace(".", ",");
            else
                firstValueString = parameter.FirstValue;

            if (!double.TryParse(firstValueString, out var doubleValue))
                MessageBox.Show($"Не удалось преобразовать данные!\n" +
                    $"{Environment.StackTrace}");

            var preparedValue = (int)doubleValue;
            return preparedValue;
        }

        #endregion
    }
}
