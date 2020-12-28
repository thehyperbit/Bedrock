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
using Renci.SshNet;
using Renci.SshNet.Sftp;
using CmlLib;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Downloader;
using CmlLib.Core.LauncherProfile;
using CmlLib.Core.Mojang;
using CmlLib.Core.Version;
using CmlLib.Utils;

namespace Bedrock
{
    public partial class StartupWindow : Window
    {
        private bool Verification = false;
        private string TotalPath = Directory.GetCurrentDirectory();
        public static CMLauncher Launcher;

        private string Host = "bedrock-project.ru";
        private string Username = "root";
        private string Password = "password";

        public StartupWindow()
        {
            InitializeComponent();

            Initialize();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(200);

            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);
        }

        private async void Initialize()
        {
            await Task.Delay(600);

            try
            {
                using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                {
                    Client.Connect();

                    Client.Disconnect();
                }
            }
            catch
            {
                ProgressText.Text = "Отсутствует интернет-подключение!";
                await Task.Delay(2000);

                DoubleAnimation OpacityAnimation = new DoubleAnimation();
                OpacityAnimation.From = this.Opacity;
                OpacityAnimation.To = 0;
                OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
                this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);

                await Task.Delay(500);
                Environment.Exit(0);
            }

            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ProgressBar.Width;
            WidthAnimation.To = 80;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ProgressBar.BeginAnimation(Border.WidthProperty, WidthAnimation);
            for (byte i = 0; i <= 25; i++)
            {
                ProgressText.Text = i.ToString() + "%";
                await Task.Delay(15);
            }
            await Task.Delay(800);
            ProgressText.Text = "Установка лаунчера...";
 

            WidthAnimation.From = ProgressBar.Width;
            WidthAnimation.To = 160;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ProgressBar.BeginAnimation(Border.WidthProperty, WidthAnimation);
            for (byte i = 25; i <= 50; i++)
            {
                ProgressText.Text = i.ToString() + "%";
                await Task.Delay(15);
            }
            await Task.Delay(800);

            WidthAnimation.From = ProgressBar.Width;
            WidthAnimation.To = 240;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ProgressBar.BeginAnimation(Border.WidthProperty, WidthAnimation);
            for (byte i = 50; i <= 75; i++)
            {
                ProgressText.Text = i.ToString() + "%";
                await Task.Delay(15);
            }
            await Task.Delay(800);

            if (!Directory.Exists(TotalPath + @"/Resource"))
            {
                try
                {
                    Directory.CreateDirectory(TotalPath + @"/Resource");

                    if (Directory.Exists(TotalPath + @"/Resource"))
                    {
                        Directory.CreateDirectory(TotalPath + @"/Resource/Fonts");

                        Directory.CreateDirectory(TotalPath + @"/Resource/Images");

                        try
                        {
                            using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                            {
                                Client.Connect();

                                using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Resource/Images/SteveAvatar.png"))
                                {
                                    Client.DownloadFile("/launcher/Resource/Images/SteveAvatar.png", fileStream);
                                }

                                Client.Disconnect();
                            }

                           
                        }
                        catch { }

                        Directory.CreateDirectory(TotalPath + @"/Resource/Sounds");

                        Directory.CreateDirectory(TotalPath + @"/Resource/Videos");
                    }
                }
                catch { }
            }
            else
            {
                if (!Directory.Exists(TotalPath + @"/Resource/Fonts"))
                {
                    Directory.CreateDirectory(TotalPath + @"/Resource/Fonts");
                }

                if (!Directory.Exists(TotalPath + @"/Resource/Images"))
                {
                    Directory.CreateDirectory(TotalPath + @"/Resource/Images");

                    if (!File.Exists(TotalPath + @"/Resource/Images/SteveAvatar.png"))
                    {
                        try
                        {
                            using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                            {
                                Client.Connect();

                                using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Resource/Images/SteveAvatar.png"))
                                {
                                    Client.DownloadFile("/launcher/Resource/Images/SteveAvatar.png", fileStream);
                                }

                                Client.Disconnect();
                            }
                        }
                        catch { }
                    }

                    if (!File.Exists(TotalPath + @"/Resource/Images/BedrockAvatar.png"))
                    {
                        try
                        {
                            using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                            {
                                Client.Connect();

                                using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Resource/Images/BedrockAvatar.png"))
                                {
                                    Client.DownloadFile("/launcher/Resource/Images/BedrockAvatar.png", fileStream);
                                }

                                Client.Disconnect();
                            }
                        }
                        catch { }
                    }

                }
                else
                {
                    if (!File.Exists(TotalPath + @"/Resource/Images/SteveAvatar.png"))
                    {
                        try
                        {
                            using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                            {
                                Client.Connect();

                                using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Resource/Images/SteveAvatar.png"))
                                {
                                    Client.DownloadFile("/launcher/Resource/Images/SteveAvatar.png", fileStream);
                                }

                                Client.Disconnect();
                            }
                        }
                        catch { }
                    }

                    if (!File.Exists(TotalPath + @"/Resource/Images/BedrockAvatar.png"))
                    {
                        try
                        {
                            using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                            {
                                Client.Connect();

                                using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Resource/Images/BedrockAvatar.png"))
                                {
                                    Client.DownloadFile("/launcher/Resource/Images/BedrockAvatar.png", fileStream);
                                }

                                Client.Disconnect();
                            }
                        }
                        catch { }
                    }
                }

                if (!Directory.Exists(TotalPath + @"/Resource/Sounds"))
                {
                    Directory.CreateDirectory(TotalPath + @"/Resource/Sounds");
                }

                if (!Directory.Exists(TotalPath + @"/Resource/Videos"))
                {
                    Directory.CreateDirectory(TotalPath + @"/Resource/Videos");
                }

            }

            ProgressText.Text = "Установка майнкрафта...";

            if (!Directory.Exists(TotalPath + @"/Storage"))
            {
                try
                {
                    Directory.CreateDirectory(TotalPath + @"/Storage");
                    Directory.CreateDirectory(TotalPath + @"/Storage/Saves");
                    Directory.CreateDirectory(TotalPath + @"/Storage/Crashes");
                    Directory.CreateDirectory(TotalPath + @"/Storage/Users");
                    Directory.CreateDirectory(TotalPath + @"/Storage/Stream");

                    try
                    {
                        using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                        {
                            Client.Connect();

                            using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Storage/Stream/MinecraftVersion"))
                            {
                                Client.DownloadFile("/launcher/Storage/Stream/MinecraftVersion", fileStream);
                            }

                            Client.Disconnect();
                        }
                    }
                    catch { }

                    try
                    {
                        using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                        {
                            Client.Connect();

                            using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Storage/Stream/LauncherVersion"))
                            {
                                Client.DownloadFile("/launcher/Storage/Stream/LauncherVersion", fileStream);
                            }

                            Client.Disconnect();
                        }
                    }
                    catch { }
                }
                catch { }
            }
            else
            {
                if (!Directory.Exists(TotalPath + @"/Storage/Saves"))
                {
                    Directory.CreateDirectory(TotalPath + @"/Storage/Saves");
                }

                if (!Directory.Exists(TotalPath + @"/Storage/Crashes"))
                {
                    Directory.CreateDirectory(TotalPath + @"/Storage/Crashes");
                }

                if (!Directory.Exists(TotalPath + @"/Storage/Users"))
                {
                    Directory.CreateDirectory(TotalPath + @"/Storage/Users");
                }

                if (!Directory.Exists(TotalPath + @"/Storage/Stream"))
                {
                    Directory.CreateDirectory(TotalPath + @"/Storage/Stream");
                }

                try
                {
                    using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                    {
                        Client.Connect();

                        using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Storage/Stream/MinecraftVersion"))
                        {
                            Client.DownloadFile("/launcher/Storage/Stream/MinecraftVersion", fileStream);
                        }

                        Client.Disconnect();
                    }
                }
                catch { }

                try
                {
                    using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                    {
                        Client.Connect();

                        using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Storage/Stream/LauncherVersion"))
                        {
                            Client.DownloadFile("/launcher/Storage/Stream/LauncherVersion", fileStream);
                        }

                        Client.Disconnect();
                    }
                }
                catch { }

            }

            string LaunchertVersion;

            try
            {
                FileStream FileStream = new FileStream(TotalPath + @"/Storage/Stream/LaunchertVersion", FileMode.Open, FileAccess.Read);
                using (var StreamReader = new StreamReader(FileStream, Encoding.UTF8))
                {
                    LaunchertVersion = StreamReader.ReadToEnd();
                    LaunchertVersion = LaunchertVersion.Trim();

                    if (LaunchertVersion == "tech")
                    {
                        ProgressText.Text = "Лаунчер закрыт на тех-обслуживание.";

                        await Task.Delay(2000);

                        DoubleAnimation OpacityAnimation = new DoubleAnimation();
                        OpacityAnimation.From = this.Opacity;
                        OpacityAnimation.To = 0;
                        OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
                        this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);

                        await Task.Delay(500);
                        Environment.Exit(0);
                    } 
                }
            
            }
            catch { }

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
                        MinecraftVersion = "1.12.2";
                    }
                }  
            }
            catch 
            {
                 MinecraftVersion = "1.12.2";
            }
            
            if (!Directory.Exists(TotalPath + @"/Minecraft"))
            {
                Directory.CreateDirectory(TotalPath + @"/Minecraft");

                try
                {
                    Launcher = new CMLauncher(Directory.GetCurrentDirectory() + @"\Minecraft");

                    MVersion MVersion = Launcher.GetVersion(MinecraftVersion);
                    Launcher.CheckGameFiles(MVersion, false, false);

                    try
                    {
                        using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                        {
                            Client.Connect();

                            using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Minecraft/options.txt"))
                            {
                                Client.DownloadFile("/launcher/Minecraft/options.txt", fileStream);
                            }

                            Client.Disconnect();
                        }
                    }
                    catch { }
                    
                }
                catch { }
            }
            else
            {
                if (Directory.Exists(TotalPath + @"/Minecraft/saves"))
                {
                    Directory.Delete(TotalPath + @"/Minecraft/saves");
                }

                if (!Directory.Exists(TotalPath + @"/Minecraft/assets"))
                {
                    Directory.CreateDirectory(TotalPath + @"/Minecraft/assets");
                }

                if (!Directory.Exists(TotalPath + @"/Minecraft/assets/objects"))
                {
                    Directory.CreateDirectory(TotalPath + @"/Minecraft/assets/objects");
                }

                if (!File.Exists(TotalPath + @"/Minecraft/options.txt"))
                {
                    try
                    {
                        using (SftpClient Client = new SftpClient(Host, Username, Password.Replace("password", "singularity")))
                        {
                            Client.Connect();

                            using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Minecraft/options.txt"))
                            {
                                Client.DownloadFile("/launcher/Minecraft/options.txt", fileStream);
                            }

                            Client.Disconnect();
                        }
                    }
                    catch { }
                }

                try
                {
                    CMLauncher Launcher = new CMLauncher(Directory.GetCurrentDirectory() + @"\Minecraft");

                    MVersion MVersion = Launcher.GetVersion(MinecraftVersion);
                    Launcher.CheckGameFiles(MVersion, false, false);
                }
                catch { }
            }

            WidthAnimation.From = ProgressBar.Width;
            WidthAnimation.To = 320;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ProgressBar.BeginAnimation(Border.WidthProperty, WidthAnimation);
            for (byte i = 75; i <= 100; i++)
            {
                ProgressText.Text = i.ToString() + "%";
                await Task.Delay(15);
            }
            await Task.Delay(1000);

            LoginWindow LoginWindow = new LoginWindow();
            LoginWindow.Owner = this;
            this.Visibility = Visibility.Hidden;
            this.ShowInTaskbar = false;
            LoginWindow.ShowDialog();

            Verification = true;

            this.Owner.ShowInTaskbar = true;
            this.Close();
      
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Verification == false)
            {
                Environment.Exit(0);
            }
        }
    }
}
