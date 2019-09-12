namespace UI.ViewModels
{
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
