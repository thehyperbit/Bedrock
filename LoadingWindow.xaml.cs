using CmlLib.Core;
using CmlLib.Core.Auth;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bedrock
{
    public partial class LoadingWindow : Window
    {
        private string TotalPath = Directory.GetCurrentDirectory();

        private CMLauncher Launcher = new CMLauncher(new MinecraftPath());

        public static string Version { get; set; }
        public static string IP { get; set; }
        public static string Nickname;

        public LoadingWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);

            await Task.Delay(300);

            if (!File.Exists(TotalPath + @"/Storage/Stream/MinecraftVersion"))
            {
                try
                {
                    using (SftpClient Client = new SftpClient("bedrock-project.ru", "root", "singularity"))
                    {
                        Client.Connect();

                        using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Storage/Stream/MinecraftVersion"))
                        {
                            Client.DownloadFile("/launcher/Storage/Stream/MinecraftVersion", fileStream);
                        }
                    }
                }
                catch { }
            }

            string MinecraftVersion;

            try
            {
                FileStream FileStream = new FileStream(TotalPath + @"/Storage/Stream/MinecraftVersion", FileMode.Open, FileAccess.Read);
                using (var StreamReader = new StreamReader(FileStream, Encoding.UTF8))
                {
                    MinecraftVersion = StreamReader.ReadToEnd();
                    MinecraftVersion = MinecraftVersion.Trim();

                    if (MinecraftVersion == null)
                    {
                        MinecraftVersion = "1.16.4";
                    }
                }
            }
            catch
            {
                MinecraftVersion = "1.16.4";
            }

            MSession MSession;

            if (Nickname != null)
            {
                MSession = MSession.GetOfflineSession(Nickname);
            }
            else
            {
                MSession = MSession.GetOfflineSession("Steve");
            }

           

            var LaunchOption = new MLaunchOption
            {
                MinimumRamMb = 512,
                MaximumRamMb = 1024,
                Session = MSession,
                ScreenWidth = 1920,
                ScreenHeight = 1080,
                ServerIp = IP,
                FullScreen = true
            };

            try
            {
                System.Diagnostics.Process Process = Launcher.CreateProcess(MinecraftVersion, LaunchOption);
                Process.Start();
            }
            catch
            {
                string PATH = new MinecraftPath() + @"\versions\" + MinecraftVersion;

                Directory.Delete(PATH, true);

                System.Diagnostics.Process Process = Launcher.CreateProcess(MinecraftVersion, LaunchOption);
                Process.Start();
            }
           


            // launch forge (already installed)
            // var process = launcher.CreateProcess("1.16.2-forge-33.0.5", launchOption);

            // launch forge (install forge if not installed)
            // var process = launcher.CreateProcess("1.16.2", "33.0.5", launchOption);


            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = LoadProgress.Opacity;
            WidthAnimation.To = 320;
            WidthAnimation.Duration = TimeSpan.FromSeconds(2);
            LoadProgress.BeginAnimation(Rectangle.WidthProperty, WidthAnimation);
            await Task.Delay(2000);


            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);
            await Task.Delay(1000);

            this.Close();

        }
    }
}
