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
            DataContext = gameSection;

            //string SJ = gameSection.DisplayComboBoxSelection(LevelSelect);

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
            gameSection.DisplayComboBoxSelection(LevelSelect);
            //MessageBox.Show(string.Format("Are Enemies Enabled: {0}" + Environment.NewLine + "Is Death Pit Rising: {1}" + Environment.NewLine + "Is Low Gravity Enabled: {2}" + Environment.NewLine + "Is Stopwatch Enabled: {3}" + Environment.NewLine + "Level Theme: {4}" + Environment.NewLine + "Player Name: {5}", gameSection.AreEnemiesEnabled, gameSection.IsDeathPitRising, gameSection.IsLowGravityEnabled, gameSection.IsStopwatchEnabled, gameSection.DisplayComboBoxSelection(fff, LevelSelect), gameSection.PlayerName));
            gameSection.WriteGameSectionToFile();
            //Close();
        }
    }

    public partial class ScrollViewerSettings
    {
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
            String DCBS = comboBox.SelectionBoxItem.ToString();
        }
    }

    public partial class GameSection : ScrollViewerSettings
    {
        // These will store whatever the user ends up chosing at the end
        public bool AreEnemiesEnabled { get; set; }
        public bool IsDeathPitRising { get; set; }
        public bool IsLowGravityEnabled{ get; set; }
        public bool IsStopwatchEnabled { get; set; }
        public string LevelTheme { get; set; }
        public string PlayerName { get; set; }

        public void WriteGameSectionToFile()

        // If i can tomorrow, make a tab class that will take a tab and if that tab is click, display that grid and scroll wheel instead of having all these tabs in the class.
        {
            string path = @"C:\Users\s189074\Downloads\SJ.txt";

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
                    sw.WriteLine(string.Format("Are Enemies Enabled: {0}" + Environment.NewLine + "Is Death Pit Rising: {1}" + Environment.NewLine + "Is Low Gravity Enabled: {2}" + Environment.NewLine + "Is Stopwatch Enabled: {3}" + Environment.NewLine + "Level Theme: {4}" + Environment.NewLine + "Player Name: {5}", AreEnemiesEnabled, IsDeathPitRising, IsLowGravityEnabled, IsStopwatchEnabled, LevelTheme, PlayerName));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}