using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VolumeControlSystem.SoundControl;

namespace VolumeControlSystem.UserControls
{
    /// <summary>
    /// Interaction logic for TextEnterUserControl.xaml
    /// </summary>
    public partial class TextEnterUserControl : UserControl, INotifyPropertyChanged
    {
        public TextEnterUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Notify Property Change
        private int _sliderValue;
        public int SliderValue
        {
            get { return _sliderValue; }
            set
            {
                if (_sliderValue != value)
                {
                    _sliderValue = value;
                    OnPropertyChanged(nameof(SliderValue));
                    OnPropertyChanged(nameof(LocalSliderValue));
                }
            }
        }

        public int LocalSliderValue
        {
            get { return _sliderValue; }
            set
            {
                if (_sliderValue != value)
                {
                    _sliderValue = value;
                    BaseUC.SliderValue = value; // Update BaseUserControl slider value
                    OnPropertyChanged(nameof(LocalSliderValue));
                    OnPropertyChanged(nameof(SliderValue));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
