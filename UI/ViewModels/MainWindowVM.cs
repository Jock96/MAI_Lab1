namespace UI.ViewModels
{
    using BL.Constants;
    using BL.Enums;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Media;
    using UI.Commands;

    /// <summary>
    /// Вью-модель главного окна.
    /// </summary>
    public class MainWindowVM : BaseVM
    {
        /// <summary>
        /// Вью-модель главного окна.
        /// </summary>
        public MainWindowVM()
        {
            _currentFormat = FormatType.NONE;
            LoadImageCommand = new LoadImageCommand();
            ConvertImageCommand = new ConvertImageCommand();

            _labelFirst = "R";
            _labelSecond = "G";
            _labelThird = "B";

            _firstValue = "0";
            _secondValue = "0";
            _thirdValue = "0";

            ChangeChannelsCommand = new ChangeChannelsCommand();
        }

        #region Значение каналов текущего рисунка.

        /// <summary>
        /// Значение третьего канала.
        /// </summary>
        private string _thirdChannelValue;

        /// <summary>
        /// Значение третьего канала.
        /// </summary>
        public string ThirdChannelValue
        {
            get => _thirdChannelValue;
            set
            {
                _thirdChannelValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Значение второго канала.
        /// </summary>
        private string _secondChannelValue;

        /// <summary>
        /// Значение второго канала.
        /// </summary>
        public string SecondChannelValue
        {
            get => _secondChannelValue;
            set
            {
                _secondChannelValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Значение первого канала.
        /// </summary>
        private string _firstChannelValue;

        /// <summary>
        /// Значение первого канала.
        /// </summary>
        public string FirstChannelValue
        {
            get => _firstChannelValue;
            set
            {
                _firstChannelValue = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Работа с форматами.

        /// <summary>
        /// Варианты конвертации.
        /// </summary>
        public List<string> ConverterVariations { get; set; } =
            new List<string> {
                ConverterVariationConstants.RGB_TO_YUV,
                ConverterVariationConstants.YUV_TO_RGB,
                ConverterVariationConstants.RGB_TO_HSL,
                ConverterVariationConstants.HSL_TO_RGB };

        /// <summary>
        /// Выбранный вариант конвертации.
        /// </summary>
        public string ConvertVariable { get; set; }

        /// <summary>
        /// Описание текущего формата.
        /// </summary>
        private string _currentFormatDescription;

        /// <summary>
        /// Описание текущего формата.
        /// </summary>
        public string CurrentFormatDescription
        {
            get => _currentFormatDescription;
            set
            {
                _currentFormatDescription = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Тип текущего формата.
        /// </summary>
        private FormatType _currentFormat;

        /// <summary>
        /// Тип текущего формата.
        /// </summary>
        public FormatType CurrentFormat
        {
            get => _currentFormat;
            set
            {
                _currentFormat = value;
                _currentFormatDescription = _currentFormat.ToString();
                OnPropertyChanged(nameof(CurrentFormatDescription));
            }
        }

        #endregion

        /// <summary>
        /// Изменение первого канала.
        /// </summary>
        public ChangeChannelsCommand ChangeChannelsCommand { get; set; }

        /// <summary>
        /// Загрузить изображение.
        /// </summary>
        public LoadImageCommand LoadImageCommand { get; set; }

        /// <summary>
        /// Загрузить изображение.
        /// </summary>
        public ConvertImageCommand ConvertImageCommand { get; set; }

        #region Значение каналов.

        /// <summary>
        /// Первое значение.
        /// </summary>
        private string _firstValue;

        /// <summary>
        /// Первое значение.
        /// </summary>
        public string FirstValue
        {
            get => _firstValue;
            set
            {
                _firstValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Второе значение.
        /// </summary>
        private string _secondValue;

        /// <summary>
        /// Второе значение.
        /// </summary>
        public string SecondValue
        {
            get => _secondValue;
            set
            {
                _secondValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Третье значение.
        /// </summary>
        private string _thirdValue;

        /// <summary>
        /// Третье значение.
        /// </summary>
        public string ThirdValue
        {
            get => _thirdValue;
            set
            {
                _thirdValue = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Имена меток.

        /// <summary>
        /// Первая метка.
        /// </summary>
        private string _labelFirst;

        /// <summary>
        /// Вторая метка.
        /// </summary>
        private string _labelSecond;

        /// <summary>
        /// Третья метка.
        /// </summary>
        private string _labelThird;

        /// <summary>
        /// Первая метка.
        /// </summary>
        public string LabelFirst
        {
            get => _labelFirst;
            set
            {
                _labelFirst = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Вторая метка.
        /// </summary>
        public string LabelSecond
        {
            get => _labelSecond;
            set
            {
                _labelSecond = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Третья метка.
        /// </summary>
        public string LabelThrird
        {
            get => _labelThird;
            set
            {
                _labelThird = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Изображение.

        /// <summary>
        /// Изображение.
        /// </summary>
        private ImageSource _image;

        /// <summary>
        /// Текущее изображение.
        /// </summary>
        public Bitmap CurrentBitmap { get; set; }

        /// <summary>
        /// Изображение.
        /// </summary>
        public ImageSource Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
