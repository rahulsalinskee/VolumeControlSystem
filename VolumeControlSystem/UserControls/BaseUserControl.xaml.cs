using System;
using System.Collections.Generic;
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
    /// Interaction logic for BaseUserControl.xaml
    /// </summary>
    public partial class BaseUserControl : UserControl
    {
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
