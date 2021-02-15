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

namespace SimpleCallLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SLD_URGENCY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Updates the urgency label as the user moves the slider (also changing the background colour of the slider itself and the label)
            //Minor (Green) : #FFA3EE75
            //Moderate (Amber): #FFEEB875
            //Severe (Red): #FFEE7575

            var slider = sender as Slider;
            Brush greenBrush, amberBrush, redBrush;
            greenBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA3EE75"));
            amberBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFEEB875"));
            redBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFEE7575"));

            switch (slider.Value)
            {
                case 0.0:
                    slider.Background = greenBrush;
                    LAB_URGENCY_TEXT.Background = greenBrush;
                    LAB_URGENCY_TEXT.Content = "Minor";
                    break;

                case 1.0:
                    slider.Background = amberBrush;
                    LAB_URGENCY_TEXT.Background = amberBrush;
                    LAB_URGENCY_TEXT.Content = "Moderate";
                    break;

                case 2.0:
                    slider.Background = redBrush;
                    LAB_URGENCY_TEXT.Background = redBrush;
                    LAB_URGENCY_TEXT.Content = "Severe";
                    break;

            }
        }


    }
}
