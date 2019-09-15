namespace UI.Commands
{
    using BL.Constants;
    using BL.Utils;
    using System.Windows;
    using UI.ViewModels;

    /// <summary>
    /// Команда конвертации изображения.
    /// </summary>
    public class ConvertImageCommand : BaseTCommand<MainWindowVM>
    {
        /// <summary>
        /// Выполнить.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        protected override void Execute(MainWindowVM parameter)
        {
            if (string.IsNullOrEmpty(parameter.ConvertVariable))
            {
                MessageBox.Show("Выберите вариант конвертации.");
                return;
            }

            parameter.FirstValue = "0";
            parameter.SecondValue = "0";
            parameter.ThirdValue = "0";

            if (string.Equals(parameter.ConvertVariable,
                ConverterVariationConstants.RGB_TO_YUV,
                System.StringComparison.InvariantCultureIgnoreCase))
            {
                switch (parameter.CurrentFormat)
                {
                    case BL.Enums.FormatType.YUV:
                        return;

                    case BL.Enums.FormatType.HSL:
                        MessageBox.Show("Выбран неверный формат конвертации.");
                        return;

                    case BL.Enums.FormatType.RGB:
                        parameter.CurrentFormat = BL.Enums.FormatType.YUV;
                        parameter.LabelFirst = "Y";
                        parameter.LabelSecond = "U";
                        parameter.LabelThrird = "V";
                        break;
                }
            }

            if (string.Equals(parameter.ConvertVariable,
                ConverterVariationConstants.YUV_TO_RGB,
                System.StringComparison.InvariantCultureIgnoreCase))
            {
                switch (parameter.CurrentFormat)
                {
                    case BL.Enums.FormatType.RGB:
                        return;

                    case BL.Enums.FormatType.HSL:
                        MessageBox.Show("Выбран неверный формат конвертации.");
                        return;

                    case BL.Enums.FormatType.YUV:
                        parameter.CurrentFormat = BL.Enums.FormatType.RGB;
                        parameter.LabelFirst = "R";
                        parameter.LabelSecond = "G";
                        parameter.LabelThrird = "B";
                        break;
                }
            }

            if (string.Equals(parameter.ConvertVariable,
                ConverterVariationConstants.RGB_TO_HSL,
                System.StringComparison.InvariantCultureIgnoreCase))
            {
                switch (parameter.CurrentFormat)
                {
                    case BL.Enums.FormatType.YUV:
                        MessageBox.Show("Выбран неверный формат конвертации.");
                        return;

                    case BL.Enums.FormatType.HSL:
                        return;

                    case BL.Enums.FormatType.RGB:
                        parameter.CurrentFormat = BL.Enums.FormatType.HSL;
                        parameter.LabelFirst = "H";
                        parameter.LabelSecond = "S";
                        parameter.LabelThrird = "L";
                        break;
                }
            }

            if (string.Equals(parameter.ConvertVariable,
                ConverterVariationConstants.HSL_TO_RGB,
                System.StringComparison.InvariantCultureIgnoreCase))
            {
                switch (parameter.CurrentFormat)
                {
                    case BL.Enums.FormatType.YUV:
                        MessageBox.Show("Выбран неверный формат конвертации.");
                        return;

                    case BL.Enums.FormatType.RGB:
                        return;

                    case BL.Enums.FormatType.HSL:
                        parameter.CurrentFormat = BL.Enums.FormatType.RGB;
                        parameter.LabelFirst = "R";
                        parameter.LabelSecond = "G";
                        parameter.LabelThrird = "B";
                        break;
                }
            }
        }
    }
}
