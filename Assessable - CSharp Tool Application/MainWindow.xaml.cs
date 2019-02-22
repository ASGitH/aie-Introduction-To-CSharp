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

namespace Assessable_CSharp_Tool_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // The following code below is implemented in 
            // the XAML window, but is also implemented
            // below but commented out for future reference.

            // (Lock Window Size)
            ResizeMode = ResizeMode.NoResize;

            InitializeComponent();
        }

        private void Game_Button_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"C:\Users\s189074\Downloads\My Name Is Jeff Sound Effect.mp3"));
            mediaPlayer.Volume = 1;
            mediaPlayer.Play();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"C:\Users\s189074\Downloads\Misc\Persona 4 Ending Theme - Never More (+ English LyricsSubs).mp3"));
            mediaPlayer.Volume = 1;
            mediaPlayer.Play();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            
            jd.Background = Brushes.Black;
        }
    }
}