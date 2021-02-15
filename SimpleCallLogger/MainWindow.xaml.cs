using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

        private void W_MAIN_Loaded(object sender, RoutedEventArgs e)
        {

            //Perform loading events
                //Check version compatibility
                //Load data for controls

           ///////////////////////////
           ///Version Compatibility///
           ///////////////////////////
            
            //Open Connection
                ///OBJ folder only being used to initial development and testing, production location would not be within solution folders
            SQLiteConnection cnn = new SQLiteConnection("Data Source=C:\\Users\\Ross\\source\\repos\\SimpleCallLogger\\SimpleCallLogger\\obj\\SimpleCallLoggerDB.db");
            cnn.Open();

            //Get data
            SQLiteCommand cmd = new SQLiteCommand("SELECT SERV_VERS FROM [T_SERV_VERS]")
            {
                Connection = cnn
            };
            SQLiteDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            //Check onlu one row has been returned
            if (dt.Rows.Count == 0)
            {
                //No rows returned - warn and exit
                _ = MessageBox.Show("Error checking version compatability (no data) \n \n Application will close to protect integrity", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Windows.Application.Current.Shutdown();
            }
            else if (dt.Rows.Count > 1)
            {
                //More than 1 row returned - warn and exit
                _ = MessageBox.Show("Error checking version compatability (data >1) \n \n Application will close to protect integrity", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Windows.Application.Current.Shutdown();
            }
            else
            {
                //Only 1 row returned (OK)
                if (Convert.ToInt32(dt.Rows[0]["SERV_VERS"]) == CLS_GLOB_VARS.CLIENT_VERS)
                {
                    //Version match (OK)
                    //_ = MessageBox.Show("Database Connection Successful!", "Hello!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    //Version do not match - warn and exit
                    _ = MessageBox.Show("This version of the application is incompatible with the server!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    System.Windows.Application.Current.Shutdown();
                }
            }

            ////////////////////////////
            ///Load data for controls///
            ////////////////////////////
            


        }
    }
}
