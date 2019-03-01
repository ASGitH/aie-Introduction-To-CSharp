using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        List<ScrollViewer> ScrollViewers = new List<ScrollViewer>();
        List<Grid> Grids = new List<Grid>();

        public MainWindow()
        {
            File.Delete(gameSection.path);

            InitializeComponent();
            DataContext = gameSection;

            gameSection.AddScrollViewerAndGrid(ScrollViewers, Game_Scroll_Viewer, Grids, Game_Grid);
            gameSection.AddScrollViewerAndGrid(ScrollViewers, Player_Scroll_Viewer, Grids, Player_Grid);
            gameSection.AddScrollViewerAndGrid(ScrollViewers, Audio_Scroll_Viewer, Grids, Audio_Grid);
            gameSection.AddScrollViewerAndGrid(ScrollViewers, Video_Scroll_Viewer, Grids, Video_Grid);

            // (Disable Game Controls)
            gameSection.DisableScrollViewerAndGrid(ScrollViewers, Grids);
        }

        // Triggers (Buttons, OnClick, OnMouseDown)
        private void GameTab(object sender, MouseButtonEventArgs e)
        {
            gameSection.EnableScrollViewerAndGrid(ScrollViewers, Grids, 0);
        }

        private void PlayerTab(object sender, MouseButtonEventArgs e)
        {
            gameSection.EnableScrollViewerAndGrid(ScrollViewers, Grids, 1);
        }

        private void AudioTab(object sender, MouseButtonEventArgs e)
        {
            gameSection.EnableScrollViewerAndGrid(ScrollViewers, Grids, 2);
        }

        private void VideoTab(object sender, MouseButtonEventArgs e)
        {
            gameSection.EnableScrollViewerAndGrid(ScrollViewers, Grids, 3);
        }

        private void StartButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("Game Section" + Environment.NewLine + "------------" + Environment.NewLine + "Are Enemies Enabled: {0}" + Environment.NewLine + "Is Death Pit Rising: {1}" + Environment.NewLine + "Is Low Gravity Enabled: {2}" + Environment.NewLine + "Is Stopwatch Enabled: {3}" + Environment.NewLine + "Level Theme: {4}" + Environment.NewLine + Environment.NewLine + "Player Section" + Environment.NewLine + "--------------" + Environment.NewLine + "Can Double Jump: {5}" + Environment.NewLine + "Is Invisible: {6}" + Environment.NewLine + "Player's Name: {7}" + Environment.NewLine + "Player's Speed: {8}" + Environment.NewLine + Environment.NewLine + "Audio Section" + Environment.NewLine + "-------------" + Environment.NewLine + "Enable Audio: {9}" + Environment.NewLine + "Track: {10}" + Environment.NewLine + "Custom Track: {11}" + Environment.NewLine + Environment.NewLine + "Video Section" + Environment.NewLine + "-------------" + Environment.NewLine + "Window Width: {12}" + " x " + "Window Height: {13}" + Environment.NewLine + "Tool Background: {14}", gameSection.AreEnemiesEnabled, gameSection.IsDeathPitRising, gameSection.IsLowGravityEnabled, gameSection.IsStopwatchEnabled, gameSection.DisplayComboBoxSelection(LevelSelect), gameSection.CanDoubleJump, gameSection.IsInvisible, gameSection.PlayerName, gameSection.DisplaySliderValue(PlayerSpeed), gameSection.EnableAudio, gameSection.Track, gameSection.CustomTrack, gameSection.WindowWidth, gameSection.WindowHeight, gameSection.ToolBackground));
            gameSection.WriteGameSectionToFile();
            Close();
        }

        private void NewClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            gameSection.WriteGameSectionToFile();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BrowseFilesButton(object sender, RoutedEventArgs e)
        {
            gameSection.mediaPlayer.Stop();
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension
            openFileDialog.Filter = "Supported Audio (*.acc; *.flac; *.m4a; *.mp3; *.ogg; *.wav; *.wma)|*.acc; *.flac; *.m4a; *.mp3; *.ogg; *.wav; *.wma";

            Nullable<bool> result = openFileDialog.ShowDialog();
            if(result == true)
            {                
                CustomTrackTextBox.Text = openFileDialog.FileName;
                gameSection.mediaPlayer.Open(new Uri(openFileDialog.FileName));
                gameSection.mediaPlayer.Play();
            }
        }

        private void ToolBackgroundButton(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension
            openFileDialog.Filter = "Image files (*.png; *.jpg) | *.png; *.jpg";

            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                ToolBackgroundTextBox.Text = openFileDialog.FileName;
                BackgroundCanvasImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void NumericalValuesOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Return)
                Keyboard.ClearFocus();
        }
    }

    public partial class ScrollViewerSettings
    {
        public void AddScrollViewerAndGrid(List<ScrollViewer> scrollViewers, ScrollViewer scrollViewer, List<Grid> grids, Grid grid)
        {
            scrollViewers.Add(scrollViewer);
            grids.Add(grid);
        }

        public void DisableScrollViewerAndGrid(List<ScrollViewer> scrollViewers, List<Grid> grids)
        {
            for (int i = 0; i < scrollViewers.Count(); i++)
            {
                scrollViewers[i].HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                scrollViewers[i].IsEnabled = false;
                scrollViewers[i].Visibility = Visibility.Hidden;
                grids[i].Visibility = Visibility.Hidden;
                // continue;
            }
        }

        public void EnableScrollViewerAndGrid(List<ScrollViewer> scrollViewers, List<Grid> grids, int Index)
        {
            for (int i = 0; i < scrollViewers.Count(); i++)
            {
                if (i == Index)
                {
                    scrollViewers[i].HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                    scrollViewers[i].IsEnabled = true;
                    scrollViewers[i].Visibility = Visibility.Visible;
                    grids[i].Visibility = Visibility.Visible;
                    continue;
                }
                scrollViewers[i].HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                scrollViewers[i].IsEnabled = false;
                scrollViewers[i].Visibility = Visibility.Hidden;
                grids[i].Visibility = Visibility.Hidden;
                // continue;
            }
        }

        public string DisplayComboBoxSelection(ComboBox comboBox)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)comboBox.SelectedItem;
            String DCBS = comboBox.SelectionBoxItem.ToString();
            return DCBS;
        }

        public int DisplaySliderValue(Slider slider)
        {
            int SliderValue = (int)slider.Value;
            return SliderValue;
        }
    }

public partial class GameSection : ScrollViewerSettings
    {
        // Misc.
        public string path = @".\Preferences.txt";
        public MediaPlayer mediaPlayer = new MediaPlayer();

        // Game Section
        // These will store whatever the user ends up chosing at the end
        public bool AreEnemiesEnabled { get; set; }
        public bool IsDeathPitRising { get; set; }
        public bool IsLowGravityEnabled{ get; set; }
        public bool IsStopwatchEnabled { get; set; }
        public string LevelTheme { get; set; }

        // Player Section
        public bool CanDoubleJump { get; set; }
        public bool IsInvisible { get; set; }
        public string PlayerName { get; set; }
        public string PlayerSpeed { get; set; }

        // Audio Section
        public bool EnableAudio { get; set; }
        public string Track { get; set; }
        public string CustomTrack { get; set; }

        // Video Section
        public string WindowWidth { get; set; }
        public string WindowHeight { get; set; }
        public string ToolBackground { get; set; }

        public void WriteGameSectionToFile()
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (FileStream fs = File.Create(path))
                {

                }

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(string.Format("Game Section" + Environment.NewLine + "------------" + Environment.NewLine + "Are Enemies Enabled: {0}" + Environment.NewLine + "Is Death Pit Rising: {1}" + Environment.NewLine + "Is Low Gravity Enabled: {2}" + Environment.NewLine + "Is Stopwatch Enabled: {3}" + Environment.NewLine + "Level Theme: {4}" + Environment.NewLine + Environment.NewLine + "Player Section" + Environment.NewLine + "--------------" + Environment.NewLine +  "Can Double Jump: {5}" + Environment.NewLine + "Is Invisible: {6}" + Environment.NewLine + "Player's Name: {7}" + Environment.NewLine + "Player's Speed: {8}" + Environment.NewLine + Environment.NewLine + "Audio Section" + Environment.NewLine + "-------------" + Environment.NewLine + "Enable Audio: {9}" + Environment.NewLine + "Track: {10}" + Environment.NewLine + "Custom Track: {11}" + Environment.NewLine + Environment.NewLine + "Video Section" + Environment.NewLine + "-------------" + Environment.NewLine + "Window Width: {12}" + " x "+ "Window Height: {13}" + Environment.NewLine + "Tool Background: {14}", AreEnemiesEnabled, IsDeathPitRising, IsLowGravityEnabled, IsStopwatchEnabled, LevelTheme, CanDoubleJump, IsInvisible, PlayerName, PlayerSpeed, EnableAudio, Track, CustomTrack, WindowWidth, WindowHeight, ToolBackground));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}