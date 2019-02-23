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
            gameSection.SetDataContext(Game_Grid);

            // (Disable Game Controls)
            gameSection.DisableGrid(Game_Grid);
            gameSection.DisableGrid(Player_Grid);
        }

        private void GameTab(object sender, MouseButtonEventArgs e)
        {
            gameSection.EnableGrid(Game_Grid);
        }

        private void PlayerTab(object sender, MouseButtonEventArgs e)
        {
            gameSection.DisableGrid(Game_Grid);
            gameSection.EnableGrid(Player_Grid);
        }

        private void StartButton(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(string.Format("Is Death Pit Rising: {0}" + "Level Theme: {1}" + "Are Enemies Enabled: {2}", gameSection.IsDeathPitRising, gameSection.DisplayComboBoxSelection(LevelSelect), gameSection.AreEnemiesEnabled);
            MessageBox.Show(string.Format("Is Death Pit Rising: {0}" + "Are Enemies Enabled: {1}" + "Is Stopwatch Enabled: {2}", gameSection.IsDeathPitRising, gameSection.AreEnemiesEnabled, gameSection.IsStopWatchEnabled));
            gameSection.WriteGameSectionToFile();
            //Close();
        }
    }

    public partial class GridSettings
    {
        public void SetDataContext(Grid grid)
        {
            grid.DataContext = this;
        }
        public void DisableGrid(Grid grid)
        {
            grid.IsEnabled = false;
            grid.Visibility = Visibility.Hidden;
        }
        public void EnableGrid(Grid grid)
        {
            grid.IsEnabled = true;
            grid.Visibility = Visibility.Visible;
        }
        public void DisplayComboBoxSelection(ComboBox comboBox)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)comboBox.SelectedItem;
            String DCBS = comboBoxItem.Content.ToString();
        }
    }

    public partial class GameSection : GridSettings
    {         
        // These will store whatever the user ends up chosing at the end
        public bool IsDeathPitRising { get; set; }
        public string LevelTheme { get; set; }
        public bool IsStopWatchDisabled { get; set; }
        public bool IsStopWatchEnabled { get; set; }
        public bool AreEnemiesEnabled { get; set; }
        public void WriteGameSectionToFile()
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