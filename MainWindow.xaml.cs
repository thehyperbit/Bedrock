using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Bedrock
{ 
    public partial class MainWindow : Window
    {
        public WaveOutEvent WaveOutEvent = new WaveOutEvent();
        public MainWindow()
        {
            InitializeComponent();

            Initialize();
        }

        public void Mp3Player(string Path)
        {
            try
            {
                Mp3FileReader Mp3FileReader = new Mp3FileReader(Path);
                WaveOutEvent.Init(Mp3FileReader);
                WaveOutEvent.Play();
            }
            catch { }
           
        }

        private async void Initialize()
        {
            Animation();

            string Path = Directory.GetCurrentDirectory() + @"\resource\sounds\levelup.mp3";
            await Task.Run(() => Mp3Player(Path));
        }

        private async void Animation()
        {
            for (int b = 20; b > 0; b--)
            {
                await Task.Delay(1);
                this.Opacity += 0.05;
            }

            for (int b = 25; b > 0; b--)
            {
                WindowMainFragmentServer.Opacity += 0.04;
                await Task.Delay(1);
            }

            for (int b = 25; b > 0; b--)
            {
                WindowMainFragmentClaim.Opacity += 0.04;
                await Task.Delay(1);
            }

            for (int b = 50; b > 0; b--)
            {
                WindowMainFragmentServers.Opacity += 0.02;
                await Task.Delay(1);
            }
        }

        private async void InitializeData()
        {           
           /* WindowMainFragmentSettingsScrollMainLabelVersionOS.Content = "Версия OS: " + LauncherData.VersionOS;
            WindowMainFragmentSettingsScrollMainLabelVersionLauncher.Content = "Версия Launcher:  " + "v0.15";
            WindowMainFragmentSettingsScrollMainLabelVersionMinecraft.Content = "Версия Minecraft:  " + "v1.16";
            WindowMainFragmentSettingsScrollMainLabelPathMinecraft.Content = "Расположение MC:  " + LauncherData.PathMinecraft; */
        }

        private async void CloseWindow(object sender, RoutedEventArgs e)
        {
            string Path = Directory.GetCurrentDirectory() + @"\resource\sounds\door.mp3";
            await Task.Run(() => Mp3Player(Path));

            System.Windows.Media.Effects.BlurEffect EffectBlur = new System.Windows.Media.Effects.BlurEffect();
            EffectBlur.Radius = 10;
            this.Effect = EffectBlur;

            CloseWindow CloseWindow = new CloseWindow();
            CloseWindow.Owner = this;
            CloseWindow.ShowDialog(); 
        }

        private void MovementWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.Cursor = ((TextBlock)this.Resources["CursorMovement"]).Cursor;
                this.DragMove();
              
            }
            else
            {
                this.Cursor = ((TextBlock)this.Resources["CursorMain"]).Cursor;
            }
        }

        private async void WindowMainFragmentControlButtonServersClick(object sender, RoutedEventArgs e)
        {
            WindowMainFragmentServers.Opacity = 0;

            if (WindowMainFragmentSettingsScrollMain.Opacity > 1)
            {
                WindowMainFragmentSettingsScrollMain.Opacity = 1;
            }

            for (int b = 20; b > 0; b--)
            {
                WindowMainFragmentServers.Opacity += 0.05;
                WindowMainFragmentSettingsScrollMain.Opacity -= 0.05;
                await Task.Delay(1);
            }

            WindowMainFragmentServers.IsEnabled = true;
            WindowMainFragmentSettingsScrollMain.IsEnabled = false;  
        }

        private void WindowMainFragmentControlButtonServersMouseEnter(object sender, MouseEventArgs e)
        {
            WindowMainFragmentControlIconFocus.Margin = new Thickness(0, 0, 120, 200);   // -640 Default
            WindowMainFragmentControlIconFocus.Opacity = 1;
        }

        private void WindowMainFragmentControlButtonServersMouseLeave(object sender, MouseEventArgs e)
        {
            WindowMainFragmentControlIconFocus.Opacity = 0;
        }

        private void WindowMainFragmentControlButtonProfileMouseEnter(object sender, MouseEventArgs e)
        {
            WindowMainFragmentControlIconFocus.Margin = new Thickness(0, 0, 120, 80);   // -640 Default
            WindowMainFragmentControlIconFocus.Opacity = 1;
        }

        private void WindowMainFragmentControlButtonProfileMouseLeave(object sender, MouseEventArgs e)
        {
            WindowMainFragmentControlIconFocus.Opacity = 0;
        }

        private void WindowMainFragmentControlButtonShopMouseEnter(object sender, MouseEventArgs e)
        {
            WindowMainFragmentControlIconFocus.Margin = new Thickness(0, 0, 120, -40);  // -640 Default
            WindowMainFragmentControlIconFocus.Opacity = 1;
        }

        private void WindowMainFragmentControlButtonShopMouseLeave(object sender, MouseEventArgs e)
        {
            WindowMainFragmentControlIconFocus.Opacity = 0;
        }

        private async void WindowMainFragmentControlButtonSettingsClick(object sender, RoutedEventArgs e)
        {
            WindowMainFragmentSettingsScrollMain.Opacity = 0;

            if (WindowMainFragmentServers.Opacity > 1)
            {
                WindowMainFragmentServers.Opacity = 1;
            }

            for (int b = 20; b > 0; b--)
            {
                WindowMainFragmentServers.Opacity -= 0.05;
                WindowMainFragmentSettingsScrollMain.Opacity += 0.05;
                await Task.Delay(1);
            }

            WindowMainFragmentServers.IsEnabled = false;
            WindowMainFragmentSettingsScrollMain.IsEnabled = true;
        }

        private void WindowMainFragmentControlButtonSettingsMouseEnter(object sender, MouseEventArgs e)
        {
            WindowMainFragmentControlIconFocus.Margin = new Thickness(0, 0, 120, -160);   // -640 Default
            WindowMainFragmentControlIconFocus.Opacity = 1;
        }

        private void WindowMainFragmentControlButtonSettingsMouseLeave(object sender, MouseEventArgs e)
        {
            WindowMainFragmentControlIconFocus.Opacity = 0;
        }

        private async void WindowMainFragmentControlButtonDoorMouseLeave(object sender, MouseEventArgs e)
        {
            for (int b = 10; b > 0; b--)
            {
                WindowMainFragmentControlIconDoorTwo.Opacity -= 0.1;
                await Task.Delay(15);
            }
        }

        private async void WindowMainFragmentControlButtonDoorMouseEnter(object sender, MouseEventArgs e)
        {
            for (int b = 10; b > 0; b--)
            {
                WindowMainFragmentControlIconDoorTwo.Opacity += 0.1;
                await Task.Delay(15);
            }
        }

        private async void WindowMainFragmentServerButtonCreateMouseEnter(object sender, MouseEventArgs e)
        {
            for (int b = 10; b > 0; b--)
            {
                WindowMainFragmentServerImageWallpaper.Opacity += 0.05;
                WindowMainFragmentServerBorderCreate.Width += 2;
                WindowMainFragmentServerBorderCreate.Height += 1;
                await Task.Delay(15);
            }
           
        }

        private async void WindowMainFragmentServerButtonCreateMouseLeave(object sender, MouseEventArgs e)
        {
            for (int b = 10; b > 0; b--)
            {
                WindowMainFragmentServerImageWallpaper.Opacity -= 0.05;
                WindowMainFragmentServerBorderCreate.Width -= 2;
                WindowMainFragmentServerBorderCreate.Height -= 1;
                await Task.Delay(15);
            }     
        }

        private async void WindowMainFragmentСlaimButtonReportMouseEnter(object sender, MouseEventArgs e)
        {
            for (int b = 10; b > 0; b--)
            {
                WindowMainFragmentClaimImageHerobrineMask.Opacity += 0.1;
                WindowMainFragmentClaimBorderReport.Width += 2;
                WindowMainFragmentClaimBorderReport.Height += 1;
                await Task.Delay(15);
            }
        }

        private async void WindowMainFragmentСlaimButtonReportMouseLeave(object sender, MouseEventArgs e)
        {
            for (int b = 10; b > 0; b--)
            {
                WindowMainFragmentClaimImageHerobrineMask.Opacity -= 0.1;
                WindowMainFragmentClaimBorderReport.Width -= 2;
                WindowMainFragmentClaimBorderReport.Height -= 1;
                await Task.Delay(15);
            }
        }

        private async void WindowMainFragmentServerButtonCreateClick(object sender, RoutedEventArgs e)
        {
            string Path = Directory.GetCurrentDirectory() + @"\resource\sounds\pop.mp3";
            await Task.Run(() => Mp3Player(Path));

            System.Windows.Media.Effects.BlurEffect EffectBlur = new System.Windows.Media.Effects.BlurEffect();
            EffectBlur.Radius = 10;
            this.Effect = EffectBlur;

            ServerWindow ServerWindow = new ServerWindow();
            ServerWindow.Owner = this;
            ServerWindow.ShowDialog();
        }

        private async void WindowMainFragmentСlaimButtonReportClick(object sender, RoutedEventArgs e)
        {
            string Path = Directory.GetCurrentDirectory() + @"\resource\sounds\pop.mp3";
            await Task.Run(() => Mp3Player(Path));

            System.Windows.Media.Effects.BlurEffect EffectBlur = new System.Windows.Media.Effects.BlurEffect();
            EffectBlur.Radius = 10;
            this.Effect = EffectBlur;

            СlaimWindow ClaimWindow = new СlaimWindow();
            ClaimWindow.Owner = this;
            ClaimWindow.ShowDialog();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                try
                {
                    DataServer DataServer = new DataServer();
                    DataServer.Finish();
                }
                catch { }

                try
                {
                    Process[] MinecraftProcesses = Process.GetProcessesByName("javaw");
                    foreach (Process CurrentProcess in MinecraftProcesses)
                    {
                        CurrentProcess.Kill();
                    }
                }
                catch { }
            }
            catch { }
        }

        private async void StateChangedWindow(object sender, EventArgs e)
        {
             if (this.WindowState == WindowState.Minimized)
            {
                await Task.Delay(30000);
                for (int b = 43200; b > 0; b--)
                {
                    await Task.Delay(1000);
                    try
                    {
                        Process[] MinecraftProcesses = Process.GetProcessesByName("javaw");
                        if (MinecraftProcesses.Length == 0)
                        {
                            this.WindowState = WindowState.Normal;
                            this.ShowInTaskbar = true;

                            DataServer DataServer = new DataServer();
                            DataServer.Finish();

                            DataConnection DataConnection = new DataConnection();
                            DataConnection.Connection = false;

                            b = 0;
                        }
                    }
                    catch { }
                }
            }
        }

        private void WindowMainFragmentServersBorderTopComboBoxDropDownClosed(object sender, EventArgs e)
        {
            if (WindowMainFragmentServersBorderTopComboBox.SelectedIndex == 0)
            {
                WindowMainFragmentServersScrollProject.IsEnabled = true;
                WindowMainFragmentServersScrollPlayers.IsEnabled = false;
                WindowMainFragmentServersScrollProject.Opacity = 1;
                WindowMainFragmentServersScrollPlayers.Opacity = 0;
                WindowMainFragmentServersScrollProject.Visibility = Visibility.Visible;
                WindowMainFragmentServersScrollPlayers.Visibility = Visibility.Collapsed;
            }
            else if (WindowMainFragmentServersBorderTopComboBox.SelectedIndex == 1)
            {
                WindowMainFragmentServersScrollProject.IsEnabled = false;
                WindowMainFragmentServersScrollPlayers.IsEnabled = true;
                WindowMainFragmentServersScrollProject.Opacity = 0;
                WindowMainFragmentServersScrollPlayers.Opacity = 1;
                WindowMainFragmentServersScrollProject.Visibility = Visibility.Collapsed;
                WindowMainFragmentServersScrollPlayers.Visibility = Visibility.Visible;
            }
        }

        private async void WindowMainFragmentServersScrollProjectServerHardcoreButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            this.ShowInTaskbar = false;

            string IP = "tech.hypergalaxy.net";
            int Port = 30002;
            DataMinecraft DataMinecraft = new DataMinecraft();
            await Task.Run(() => DataMinecraft.Start(IP, Port));

            LoadWindow LoadWindow = new LoadWindow();
            LoadWindow.Owner = this;
            LoadWindow.ShowDialog();
        }

        private void WindowMainFragmentServersScrollProjectServerHardcoreButtonMouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter BrushConverter = new BrushConverter();
            WindowMainFragmentServersScrollProjectServerHardcoreBorder.Background = (Brush)BrushConverter.ConvertFrom("#FF3F3F3F");
        }

        private void WindowMainFragmentServersScrollProjectServerHardcoreButtonMouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter BrushConverter = new BrushConverter();
            WindowMainFragmentServersScrollProjectServerHardcoreBorder.Background = (Brush)BrushConverter.ConvertFrom("#FF2E2E2E");
        }

        private async void WindowMainFragmentServersScrollProjectServerSkyblockButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            this.ShowInTaskbar = false;

            string IP = "tech.hypergalaxy.net";
            int Port = 25565;
            DataMinecraft DataMinecraft = new DataMinecraft();
            await Task.Run(() => DataMinecraft.Start(IP, Port));

            LoadWindow LoadWindow = new LoadWindow();
            LoadWindow.Owner = this;
            LoadWindow.ShowDialog();
        }

        private void WindowMainFragmentServersScrollProjectServerSkyblockButtonMouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter BrushConverter = new BrushConverter();
            WindowMainFragmentServersScrollProjectServerSkyblockBorder.Background = (Brush)BrushConverter.ConvertFrom("#FF3F3F3F");
        }

        private void WindowMainFragmentServersScrollProjectServerSkyblockButtonMouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter BrushConverter = new BrushConverter();
            WindowMainFragmentServersScrollProjectServerSkyblockBorder.Background = (Brush)BrushConverter.ConvertFrom("#FF2E2E2E");
        }
    }
}
