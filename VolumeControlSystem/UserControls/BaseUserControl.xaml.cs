using System.Windows;
using System.Windows.Controls;

namespace VolumeControlSystem.UserControls
{
    /// <summary>
    /// Interaction logic for BaseUserControl.xaml
    /// </summary>
    public partial class BaseUserControl : UserControl
    {
        public List<int> Ticks =
        [
            -80,
            -70,
            -60,
            -50,
            -40,
            -30,
            -20,
            -10,
            0
        ];

        public BaseUserControl()
        {
            InitializeComponent();
        }

        #region Dependency Properties
        public int SliderValue
        {
            get { return (int)GetValue(SliderValueProperty); }
            set { SetValue(SliderValueProperty, value); }
        }

        public static readonly DependencyProperty SliderValueProperty =
            DependencyProperty.Register("SliderValue", typeof(int), typeof(BaseUserControl), new PropertyMetadata(0, OnSliderValueChanged));

        private static void OnSliderValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (BaseUserControl)d;
            int newValue = (int)e.NewValue;
            control.SliderValue = newValue;
        }
        #endregion
    }
}
