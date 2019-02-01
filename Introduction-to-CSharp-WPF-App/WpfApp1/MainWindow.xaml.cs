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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IsPlaying(false);
        }

        private void IsPlaying(bool bValue)
        {
            Play_Button.IsEnabled = bValue;
            Stop_Button.IsEnabled = bValue;
            Full_Screen_Button.IsEnabled = bValue;
        }

        private void Open_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            // ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            ofd.Filter = "All files (*.*)|*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
                HwndTarget hwndTarget = hwndSource.CompositionTarget;
                hwndTarget.RenderMode = RenderMode.SoftwareOnly;
                base.OnSourceInitialized(e);

                MediaEL.Source = new Uri(ofd.FileName);
                Play_Button.IsEnabled = true;
                Stop_Button.IsEnabled = true;
                Full_Screen_Button.IsEnabled = true;
                MediaEL.Play();
                //MediaEL.Position = MediaEL.Position + TimeSpan.FromMinutes(23);
            }
        }

        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {
            IsPlaying(true);
            if (Play_Button.Content.ToString() == "Play")
            {
                MediaEL.Play();
                Play_Button.Content = "Pause";
            }
            else
            {
                MediaEL.Pause();
                Play_Button.Content = "Play";
            }
        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            MediaEL.Stop();
            Play_Button.Content = "Play";
            IsPlaying(false);
            Play_Button.IsEnabled = true;
        }

        private void Full_Screen_Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            //MediaEL.Width = 1920;
            //MediaEL.Height = 1080;
            Thickness margin = Open_Button.Margin;
            margin.Top = 1000;
            Open_Button.Margin = margin;
        }
    }
}