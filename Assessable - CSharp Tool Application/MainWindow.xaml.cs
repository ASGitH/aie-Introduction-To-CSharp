using System;
using System.Collections.Generic;
using System.IO;
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
        GameSection gameSection = new GameSection();
        public MainWindow()
        {
            InitializeComponent();
            gameSection.SetDataContext(Game_Scroll_Viewer);

            // (Disable Game Controls)
            gameSection.DisableScrollViewer(Game_Scroll_Viewer, Game_Grid);
            gameSection.DisableScrollViewer(Player_Scroll_Viewer, Player_Grid);
        }

        private void GameTab(object sender, MouseButtonEventArgs e)
        {
            gameSection.EnableScrollViewer(Game_Scroll_Viewer, Game_Grid);
            gameSection.DisableScrollViewer(Player_Scroll_Viewer, Player_Grid);
        }

        private void PlayerTab(object sender, MouseButtonEventArgs e)
        {
            gameSection.EnableScrollViewer(Player_Scroll_Viewer, Player_Grid);
            gameSection.DisableScrollViewer(Game_Scroll_Viewer, Game_Grid);
        }

        private void StartButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("Is Death Pit Rising: {0}" + " Are Enemies Enabled: {1}" + " Is Stopwatch Enabled: {2}", gameSection.IsDeathPitRising, gameSection.AreEnemiesEnabled, gameSection.IsStopWatchEnabled));
            gameSection.WriteGameSectionToFile();
            //Close();
        }
    }

    public partial class ScrollViewerSettings
    {
        public void SetDataContext(ScrollViewer scrollViewer)
        {
            scrollViewer.DataContext = this;
        }
        public void DisableScrollViewer(ScrollViewer scrollViewer, Grid grid)
        {
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            scrollViewer.IsEnabled = false;
            scrollViewer.Visibility = Visibility.Hidden;
            grid.Visibility = Visibility.Hidden;
        }
        public void EnableScrollViewer(ScrollViewer scrollViewer, Grid grid)
        {
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            scrollViewer.IsEnabled = true;
            scrollViewer.Visibility = Visibility.Visible;
            grid.Visibility = Visibility.Visible;
        }
        public void DisplayComboBoxSelection(ComboBox comboBox)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)comboBox.SelectedItem;
            String DCBS = comboBoxItem.Content.ToString();
        }
    }

    public partial class GameSection : ScrollViewerSettings
    {         
        // These will store whatever the user ends up chosing at the end
        public bool IsDeathPitRising { get; set; }
        public string LevelTheme { get; set; }
        public bool IsStopWatchEnabled { get; set; }
        public bool AreEnemiesEnabled { get; set; }
        public void WriteGameSectionToFile()

        // If i can tomorrow, make a tab class that will take a tab and if that tab is click, display that grid and scroll wheel instead of having all these tabs in the class.
        {
            string path = @"C:\Users\7319a\Downloads\Sj.txt";

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using(FileStream fs = File.Create(path))
                {

                }

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(string.Format("Is Death Pit Rising: {0}" + "Are Enemies Enabled: {1}" + "Is Stopwatch Enabled: {2}", IsDeathPitRising, AreEnemiesEnabled, IsStopWatchEnabled));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}