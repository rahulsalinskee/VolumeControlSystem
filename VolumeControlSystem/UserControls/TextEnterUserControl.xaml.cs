using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void EntryValueTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void IntegerTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static bool IsTextAllowed(string text)
        {
            return Regex.IsMatch(text, @"^-?\d+$");
        }

        private void EntryValueTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void EntryValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(EntryValueTextBox.Text, out int value))
            {
                if (value < -80)
                {
                    value = -80;
                }
                else if (value > 0)
                {
                    value = 0;
                }

                LocalSliderValue = value;
            }
            //else if (EntryValueTextBox.Text != "-")
            //{
            //    LocalSliderValue = 0;
            //}

        }
    }
}
