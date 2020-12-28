using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio.Wave;
using Microsoft.Win32;
using System.IO;
using TraceLd.MineStatSharp;
using System.Security.Principal;

namespace Bedrock
{
    public partial class MainWindow : Window
    {

        WaveOutEvent WaveOutEvent = new WaveOutEvent();
        private static string TotalPath = Directory.GetCurrentDirectory();
        private static string ProfileAvatarImageSource = TotalPath + @"/Resource/Images/SteveAvatar.png";
        private static string ServersAvatarImageSource = TotalPath + @"/Resource/Images/BedrockAvatar.png";
        bool MinecraftState = false;

        private static bool HardcoreState = false;
        private static bool VanillaState = false;
        private static bool MinigamesState = false;
        private static bool RoleplayState = false;
        private static bool DominationState = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Process[] Processes = Process.GetProcessesByName("Bedrock");
            if (Processes.Length > 2)
            {
                Environment.Exit(1);
            }

            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

                if (isAdmin == false)
                {
                    Environment.Exit(1);
                }
            }
            catch 
            {
                Environment.Exit(1);
            }
        }

        private void SoundPlayer(string Path)
        {
            try
            {
                Mp3FileReader Mp3FileReader = new Mp3FileReader(Path);
                WaveOutEvent.Init(Mp3FileReader);
                WaveOutEvent.Play();
            }
            catch { }
        }

        private async void OnlineChanger()
        {
            while (true)
            {
                MineStat HardcoreCheck = new MineStat("hardcore.bedrock-project.ru", 25565);

                if (HardcoreCheck.ServerUp)
                {
                    await Dispatcher.InvokeAsync(() => ServersHardcorePlayers.Content = HardcoreCheck.CurrentPlayers + "/" + HardcoreCheck.MaximumPlayers);
                    HardcoreState = true;
                }
                else
                {
                    await Dispatcher.InvokeAsync(() => ServersHardcorePlayers.Content = "Выкл.");
                    HardcoreState = false;
                }

                MineStat VanillaCheck = new MineStat("vanilla.bedrock-project.ru", 25565);

                if (VanillaCheck.ServerUp)
                {
                    await Dispatcher.InvokeAsync(() => ServersVanillaPlayers.Content = VanillaCheck.CurrentPlayers + "/" + VanillaCheck.MaximumPlayers);
                    VanillaState = false;
                }
                else
                {
                    await Dispatcher.InvokeAsync(() => ServersVanillaPlayers.Content = "Выкл.");
                    VanillaState = false;
                }

                MineStat MinigamesCheck = new MineStat("minigames.bedrock-project.ru", 25565);

                if (MinigamesCheck.ServerUp)
                {
                    await Dispatcher.InvokeAsync(() => ServersMinigamesPlayers.Content = MinigamesCheck.CurrentPlayers + "/" + MinigamesCheck.MaximumPlayers);
                    MinigamesState = true;
                }
                else
                {
                    await Dispatcher.InvokeAsync(() => ServersMinigamesPlayers.Content = "Выкл.");
                    MinigamesState = false;
                }

                MineStat RoleplayCheck = new MineStat("roleplay.bedrock-project.ru", 25565);

                if (RoleplayCheck.ServerUp)
                {
                    await Dispatcher.InvokeAsync(() => ServersRoleplayPlayers.Content = RoleplayCheck.CurrentPlayers + "/" + RoleplayCheck.MaximumPlayers);
                    RoleplayState = true;
                }
                else
                {
                    await Dispatcher.InvokeAsync(() => ServersRoleplayPlayers.Content = "Выкл.");
                    RoleplayState = false;
                }

                MineStat DominationCheck = new MineStat("domination.bedrock-project.ru", 25565);

                if (DominationCheck.ServerUp)
                {
                    await Dispatcher.InvokeAsync(() => ServersDominationPlayers.Content = DominationCheck.CurrentPlayers + "/" + DominationCheck.MaximumPlayers);
                    DominationState = true;
                }
                else
                {
                    await Dispatcher.InvokeAsync(() => ServersDominationPlayers.Content = "Выкл.");
                    DominationState = false;
                }

                await Task.Delay(5000);
            }           
        }

        private void PageChanger(string Page)
        {
            DoubleAnimation ServersOpacityAnimation = new DoubleAnimation();
            DoubleAnimation ProfileOpacityAnimation = new DoubleAnimation();
            BitmapImage BitmapImage = new BitmapImage();

            switch (Page)
            {
                case "Servers":
                    ServersOpacityAnimation.From = Servers.Opacity;
                    ServersOpacityAnimation.To = 1;
                    ServersOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

                    ProfileOpacityAnimation.From = Profile.Opacity;
                    ProfileOpacityAnimation.To = 0;
                    ProfileOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

                    Servers.BeginAnimation(Border.OpacityProperty, ServersOpacityAnimation);
                    Profile.BeginAnimation(Border.OpacityProperty, ProfileOpacityAnimation);

                    Servers.Visibility = Visibility.Visible;
                    Profile.Visibility = Visibility.Hidden;

                    Servers.IsEnabled = true;
                    Profile.IsEnabled = false;

                    ControlAvatarImage.Width = 157;
                    ControlAvatarImage.Height = 157;

                    try
                    {
                        BitmapImage.BeginInit();
                        BitmapImage.UriSource = new Uri(ServersAvatarImageSource);
                        BitmapImage.EndInit();
                        ControlAvatarImage.Source = BitmapImage;
                    }
                    catch { }
                    
                    break;

                case "Profile":

                    ServersOpacityAnimation.From = Servers.Opacity;
                    ServersOpacityAnimation.To = 0;
                    ServersOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

                    ProfileOpacityAnimation.From = Profile.Opacity;
                    ProfileOpacityAnimation.To = 1;
                    ProfileOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

                    Servers.BeginAnimation(Border.OpacityProperty, ServersOpacityAnimation);
                    Profile.BeginAnimation(Border.OpacityProperty, ProfileOpacityAnimation);

                    Servers.Visibility = Visibility.Hidden;
                    Profile.Visibility = Visibility.Visible;

                    Servers.IsEnabled = false;
                    Profile.IsEnabled = true;

                    ControlAvatarImage.Width = 117;
                    ControlAvatarImage.Height = 117;

                    try
                    {
                        BitmapImage.BeginInit();
                        BitmapImage.UriSource = new Uri(ProfileAvatarImageSource);
                        BitmapImage.EndInit();
                        ControlAvatarImage.Source = BitmapImage;
                    }
                    catch { }

                    break;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private async void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                if (MinecraftState == true)
                {
                    this.ShowInTaskbar = false;

                    await Task.Delay(10000);

                    Process[] Processes;

                    while (true)
                    {
                        await Task.Delay(10);
                        Processes = Process.GetProcessesByName("javaw");

                        if (Processes.Length > 0)
                        {
                            break;
                        }
                    }

                    int MinecraftProcess = Processes.Length;

                    while (true)
                    {
                        await Task.Delay(100);
                        Process[] JavaProcesses = Process.GetProcessesByName("javaw");

                        if (JavaProcesses.Length < MinecraftProcess)
                        {
                            this.ShowInTaskbar = true;
                            this.WindowState = WindowState.Normal;
                            break;
                        }
                    }

                    MinecraftState = false;

                    DoubleAnimation OpacityAnimation = new DoubleAnimation();
                    OpacityAnimation.From = this.Opacity;
                    OpacityAnimation.To = 1;
                    OpacityAnimation.Duration = TimeSpan.FromSeconds(0.8);
                    this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);

                    await Task.Delay(800);
                    this.IsEnabled = true;
                }

            }
        }

        private void ClaimButton_Click(object sender, RoutedEventArgs e)
        {
            ClaimWindow ClaimWindow = new ClaimWindow();
            ClaimWindow.Owner = this;

            BlurEffect EffectBlur = new BlurEffect();
            EffectBlur.Radius = 10;
            this.Effect = EffectBlur;

            ClaimWindow.ShowDialog();
        }

        private void ClaimButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ClaimButtonBackground.Width;
            WidthAnimation.To = 106;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation HeightAnimation = new DoubleAnimation();
            HeightAnimation.From = ClaimButtonBackground.Height;
            HeightAnimation.To = 40;
            HeightAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ClaimEffect.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation WallpaperOpacityAnimation = new DoubleAnimation();
            WallpaperOpacityAnimation.From = ClaimWallpaper.Opacity;
            WallpaperOpacityAnimation.To = 1;
            WallpaperOpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);

            ClaimButtonBackground.BeginAnimation(Border.WidthProperty, WidthAnimation);
            ClaimButtonBackground.BeginAnimation(Border.HeightProperty, HeightAnimation);
            ClaimEffect.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
            ClaimWallpaper.BeginAnimation(Border.OpacityProperty, WallpaperOpacityAnimation);

        }

        private void ClaimButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ClaimButtonBackground.Width;
            WidthAnimation.To = 100;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation HeightAnimation = new DoubleAnimation();
            HeightAnimation.From = ClaimButtonBackground.Height;
            HeightAnimation.To = 34;
            HeightAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ClaimEffect.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation WallpaperOpacityAnimation = new DoubleAnimation();
            WallpaperOpacityAnimation.From = ClaimWallpaper.Opacity;
            WallpaperOpacityAnimation.To = 0.5;
            WallpaperOpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);

            ClaimButtonBackground.BeginAnimation(Border.WidthProperty, WidthAnimation);
            ClaimButtonBackground.BeginAnimation(Border.HeightProperty, HeightAnimation);
            ClaimEffect.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
            ClaimWallpaper.BeginAnimation(Border.OpacityProperty, WallpaperOpacityAnimation);
        }

        private async void ControlExitButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => SoundPlayer(TotalPath + @"/Resource/Sounds/door.mp3"));

            BlurEffect EffectBlur = new BlurEffect();
            EffectBlur.Radius = 10;
            this.Effect = EffectBlur;

            ExitWindow ExitWindow = new ExitWindow();
            ExitWindow.Owner = this;
            ExitWindow.ShowDialog();
        }

        private void ControlExitButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ControlExitEffect.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation OpacityAnimationIcon = new DoubleAnimation();
            OpacityAnimationIcon.From = ControlExitIcon.Opacity;
            OpacityAnimationIcon.To = 0;
            OpacityAnimationIcon.Duration = TimeSpan.FromSeconds(0.2);

            ControlExitIcon.BeginAnimation(Border.OpacityProperty, OpacityAnimationIcon);
            ControlExitEffect.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
        }

        private void ControlExitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ControlExitEffect.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation OpacityAnimationIcon = new DoubleAnimation();
            OpacityAnimationIcon.From = ControlExitIcon.Opacity;
            OpacityAnimationIcon.To = 1;
            OpacityAnimationIcon.Duration = TimeSpan.FromSeconds(0.2);

            ControlExitIcon.BeginAnimation(Border.OpacityProperty, OpacityAnimationIcon);
            ControlExitEffect.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
        }

        private async void AdvertisementButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdvertisementEffect.Opacity == 0.7)
            {
                await Task.Run(() => SoundPlayer(TotalPath + @"/Resource/Sounds/cave.mp3"));
            }
        }

        private void AdvertisementButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = AdvertisementButtonBackground.Width;
            WidthAnimation.To = 106;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation HeightAnimation = new DoubleAnimation();
            HeightAnimation.From = AdvertisementButtonBackground.Height;
            HeightAnimation.To = 40;
            HeightAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation EffectOpacityAnimation = new DoubleAnimation();
            EffectOpacityAnimation.From = AdvertisementEffect.Opacity;
            EffectOpacityAnimation.To = 0.7;
            EffectOpacityAnimation.Duration = TimeSpan.FromSeconds(6);

            DoubleAnimation SupportEffectOpacityAnimation = new DoubleAnimation();
            SupportEffectOpacityAnimation.From = AdvertisementSupportEffect.Opacity;
            SupportEffectOpacityAnimation.To = 0.7;
            SupportEffectOpacityAnimation.Duration = TimeSpan.FromSeconds(6);

            AdvertisementButtonBackground.BeginAnimation(Border.WidthProperty, WidthAnimation);
            AdvertisementButtonBackground.BeginAnimation(Border.HeightProperty, HeightAnimation);
            AdvertisementEffect.BeginAnimation(Image.OpacityProperty, EffectOpacityAnimation);
            AdvertisementSupportEffect.BeginAnimation(Image.OpacityProperty, EffectOpacityAnimation);
        }

        private void AdvertisementButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = AdvertisementButtonBackground.Width;
            WidthAnimation.To = 100;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation HeightAnimation = new DoubleAnimation();
            HeightAnimation.From = AdvertisementButtonBackground.Height;
            HeightAnimation.To = 34;
            HeightAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation EffectOpacityAnimation = new DoubleAnimation();
            EffectOpacityAnimation.From = AdvertisementEffect.Opacity;
            EffectOpacityAnimation.To = 0;
            EffectOpacityAnimation.Duration = TimeSpan.FromSeconds(0.4);

            DoubleAnimation SupportEffectOpacityAnimation = new DoubleAnimation();
            SupportEffectOpacityAnimation.From = AdvertisementSupportEffect.Opacity;
            SupportEffectOpacityAnimation.To = 0;
            SupportEffectOpacityAnimation.Duration = TimeSpan.FromSeconds(0.4);

            AdvertisementButtonBackground.BeginAnimation(Border.WidthProperty, WidthAnimation);
            AdvertisementButtonBackground.BeginAnimation(Border.HeightProperty, HeightAnimation);
            AdvertisementEffect.BeginAnimation(Image.OpacityProperty, EffectOpacityAnimation);
            AdvertisementSupportEffect.BeginAnimation(Image.OpacityProperty, EffectOpacityAnimation);
        }

        private void ControlServersButton_Click(object sender, RoutedEventArgs e)
        {
            PageChanger("Servers");
        }

        private void ControlServersButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ControlServers.Width;
            WidthAnimation.To = 180;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.1);
            ControlServers.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private void ControlServersButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ControlServers.Width;
            WidthAnimation.To = 165;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.1);
            ControlServers.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private void ControlProfileButton_Click(object sender, RoutedEventArgs e)
        {
            PageChanger("Profile");
        }

        private void ControlProfileButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ControlProfile.Width;
            WidthAnimation.To = 180;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.1);
            ControlProfile.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private void ControlProfileButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ControlProfile.Width;
            WidthAnimation.To = 165;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.1);
            ControlProfile.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private async void ControlShopButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = TipComingSoon.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            TipComingSoon.BeginAnimation(Border.OpacityProperty, OpacityAnimation);

            await Task.Delay(2000);

            OpacityAnimation.From = TipComingSoon.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            TipComingSoon.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
        }

        private void ControlShopButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ControlShop.Width;
            WidthAnimation.To = 180;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.1);
            ControlShop.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private void ControlShopButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ControlShop.Width;
            WidthAnimation.To = 165;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.1);
            ControlShop.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private async void ControlNewsButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = TipComingSoon.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            TipComingSoon.BeginAnimation(Border.OpacityProperty, OpacityAnimation);

            await Task.Delay(2000);

            OpacityAnimation.From = TipComingSoon.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            TipComingSoon.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
        }

        private void ControlNewsButton_MouseEnter(object sender, MouseEventArgs e)
        {

            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ControlNews.Width;
            WidthAnimation.To = 180;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.1);
            ControlNews.BeginAnimation(Border.WidthProperty, WidthAnimation);
            ControlNews.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private void ControlNewsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = ControlNews.Width;
            WidthAnimation.To = 165;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.1);
            ControlNews.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private void VkontakteButton_Click(object sender, RoutedEventArgs e)
        {
            VkontakteLabel.Foreground = Brushes.Red;

            Process Process = new Process();
            Process.StartInfo.UseShellExecute = true;
            Process.StartInfo.FileName = "https://vk.com/bedrock.project";
            Process.Start();
        }

        private void VkontakteButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = VkontakteLabel.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.1);

            TranslateTransform Transform = new TranslateTransform();
            Vkontakte.RenderTransform = Transform;
            DoubleAnimation MarginAnimation = new DoubleAnimation();
            MarginAnimation.From = Vkontakte.Margin.Right;
            MarginAnimation.To = 80;
            MarginAnimation.Duration = TimeSpan.FromSeconds(0.5);

            Vkontakte.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
            Transform.BeginAnimation(TranslateTransform.XProperty, MarginAnimation);
        }

        private void VkontakteButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = VkontakteLabel.Opacity;
            OpacityAnimation.To = 0.5;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.1);

            short Right = (short)Canvas.GetRight(Vkontakte);
            TranslateTransform Transform = new TranslateTransform();
            Vkontakte.RenderTransform = Transform;
            DoubleAnimation MarginAnimation = new DoubleAnimation();
            MarginAnimation.From = Vkontakte.Margin.Right;
            MarginAnimation.To = 0;
            MarginAnimation.Duration = TimeSpan.FromSeconds(0.4);
            Transform.BeginAnimation(TranslateTransform.XProperty, MarginAnimation);

            Vkontakte.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
            VkontakteLabel.Foreground = Brushes.White;
        }

        private void InstagramButton_Click(object sender, RoutedEventArgs e)
        {
            InstagramLabel.Foreground = Brushes.Red;

            Process Process = new Process();
            Process.StartInfo.UseShellExecute = true;
            Process.StartInfo.FileName = "https://www.instagram.com/bedrock.project/";
            Process.Start();
        }

        private void InstagramButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = Instagram.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.1);

            TranslateTransform Transform = new TranslateTransform();
            Instagram.RenderTransform = Transform;
            DoubleAnimation MarginAnimation = new DoubleAnimation();
            MarginAnimation.From = Instagram.Margin.Right;
            MarginAnimation.To = 80;
            MarginAnimation.Duration = TimeSpan.FromSeconds(0.5);

            Instagram.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
            Transform.BeginAnimation(TranslateTransform.XProperty, MarginAnimation);
        }

        private void InstagramButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = Instagram.Opacity;
            OpacityAnimation.To = 0.4;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.1);

            short Right = (short)Canvas.GetRight(Instagram);
            TranslateTransform Transform = new TranslateTransform();
            Instagram.RenderTransform = Transform;
            DoubleAnimation MarginAnimation = new DoubleAnimation();
            MarginAnimation.From = Instagram.Margin.Right;
            MarginAnimation.To = 0;
            MarginAnimation.Duration = TimeSpan.FromSeconds(0.5);

            Instagram.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
            Transform.BeginAnimation(TranslateTransform.XProperty, MarginAnimation);

            InstagramLabel.Foreground = Brushes.White;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartupWindow StartupWindow = new StartupWindow();
            StartupWindow.Owner = this;
            this.ShowInTaskbar = false;
            StartupWindow.ShowDialog();

            try
            {
                BitmapImage BitmapImage = new BitmapImage();
                BitmapImage.BeginInit();
                BitmapImage.UriSource = new Uri(ServersAvatarImageSource);
                BitmapImage.EndInit();
                ControlAvatarImage.Source = BitmapImage;
            }
            catch { }

            this.Cursor = ((TextBlock)this.Resources["CursorMain"]).Cursor;

            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);

            await Task.Delay(500);

            DoubleAnimation HardcoreOpacityAnimation = new DoubleAnimation();
            HardcoreOpacityAnimation.From = ServersHardcore.Opacity;
            HardcoreOpacityAnimation.To = 1;
            HardcoreOpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ServersHardcore.BeginAnimation(Border.OpacityProperty, HardcoreOpacityAnimation);

            await Task.Delay(300);

            DoubleAnimation VanillaOpacityAnimation = new DoubleAnimation();
            VanillaOpacityAnimation.From = ServersVanilla.Opacity;
            VanillaOpacityAnimation.To = 1;
            VanillaOpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ServersVanilla.BeginAnimation(Border.OpacityProperty, VanillaOpacityAnimation);

            await Task.Delay(300);

            DoubleAnimation MinigamesOpacityAnimation = new DoubleAnimation();
            MinigamesOpacityAnimation.From = ServersMinigames.Opacity;
            MinigamesOpacityAnimation.To = 1;
            MinigamesOpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ServersMinigames.BeginAnimation(Border.OpacityProperty, MinigamesOpacityAnimation);

            await Task.Delay(300);

            DoubleAnimation RoleplayOpacityAnimation = new DoubleAnimation();
            RoleplayOpacityAnimation.From = ServersRoleplay.Opacity;
            RoleplayOpacityAnimation.To = 1;
            RoleplayOpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ServersRoleplay.BeginAnimation(Border.OpacityProperty, RoleplayOpacityAnimation);

            await Task.Delay(300);

            DoubleAnimation DominationOpacityAnimation = new DoubleAnimation();
            DominationOpacityAnimation.From = ServersDomination.Opacity;
            DominationOpacityAnimation.To = 1;
            DominationOpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            ServersDomination.BeginAnimation(Border.OpacityProperty, DominationOpacityAnimation);

            await Task.Delay(300);

            DoubleAnimation ClaimOpacityAnimation = new DoubleAnimation();
            ClaimOpacityAnimation.From = Claim.Opacity;
            ClaimOpacityAnimation.To = 1;
            ClaimOpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            Claim.BeginAnimation(Image.OpacityProperty, ClaimOpacityAnimation);

            await Task.Delay(300);

            DoubleAnimation AdvertisementOpacityAnimation = new DoubleAnimation();
            AdvertisementOpacityAnimation.From = Advertisement.Opacity;
            AdvertisementOpacityAnimation.To = 1;
            AdvertisementOpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            Advertisement.BeginAnimation(Image.OpacityProperty, AdvertisementOpacityAnimation);

            try
            {
                string[] Nicknames = Directory.GetFiles(TotalPath + @"/Storage/Users");

                foreach (string FileName in Nicknames)
                {
                    string Nickname = System.IO.Path.GetFileName(FileName);
                    ProfileNicknameTextbox.Text = Nickname;
                }
            }
            catch { }

            this.IsEnabled = true;

            await Task.Run(() => OnlineChanger());

            await Task.Run(() => SoundPlayer(TotalPath + @"/Resource/Sounds/pop.mp3"));
        }


        private async void ServersHardcoreButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);
            this.IsEnabled = false;

            await Task.Delay(500);
            MinecraftState = true;
            this.WindowState = WindowState.Minimized;

            string Name = ProfileNicknameTextbox.Text;

            LoadingWindow LoadingWindow = new LoadingWindow();
            LoadingWindow.Version = "1.14.4";
            LoadingWindow.IP = "hardcore.bedrock-project.ru";
            LoadingWindow.Nickname = Name;
            LoadingWindow.Owner = this;
            LoadingWindow.ShowDialog();
        }

        private void ServersHardcoreButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ServersHardcoreWallpaper.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
            ServersHardcoreWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);

            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = ServersHardcoreWallpaper.Width;
            SizeAnimation.To = 630;
            SizeAnimation.DecelerationRatio = 1;
            SizeAnimation.Duration = TimeSpan.FromSeconds(1);
            ServersHardcoreWallpaper.BeginAnimation(Image.WidthProperty, SizeAnimation);
        }

        private void ServersHardcoreButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ServersHardcoreWallpaper.Opacity;
            OpacityAnimation.To = 0.6;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
            ServersHardcoreWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);

            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = ServersHardcoreWallpaper.Width;
            SizeAnimation.To = 560;
            SizeAnimation.Duration = TimeSpan.FromSeconds(0.1);

            ServersHardcoreWallpaper.BeginAnimation(Image.WidthProperty, SizeAnimation);
            ServersHardcoreWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);
        }

        private async void ServersVanillaButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);
            this.IsEnabled = false;

            await Task.Delay(500);
            MinecraftState = true;
            this.WindowState = WindowState.Minimized;

            string Name = ProfileNicknameTextbox.Text;

            LoadingWindow LoadingWindow = new LoadingWindow();
            LoadingWindow.Version = "1.12.2";
            LoadingWindow.IP = "vanilla.bedrock-project.ru";
            LoadingWindow.Nickname = Name;
            LoadingWindow.Owner = this;
            LoadingWindow.ShowDialog();
        }

        private void ServersVanillaButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ServersVanillaWallpaper.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
            ServersVanillaWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);

            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = ServersVanillaWallpaper.Width;
            SizeAnimation.To = 630;
            SizeAnimation.DecelerationRatio = 1; 
            SizeAnimation.Duration = TimeSpan.FromSeconds(1);
            ServersVanillaWallpaper.BeginAnimation(Image.WidthProperty, SizeAnimation);
        }

        private void ServersVanillaButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ServersVanillaWallpaper.Opacity;
            OpacityAnimation.To = 0.6;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
            
            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = ServersVanillaWallpaper.Width;
            SizeAnimation.To = 560;
            SizeAnimation.Duration = TimeSpan.FromSeconds(0.1);

            ServersVanillaWallpaper.BeginAnimation(Image.WidthProperty, SizeAnimation);
            ServersVanillaWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);
        }

        private async void ServersMinigamesButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);
            this.IsEnabled = false;

            await Task.Delay(500);
            MinecraftState = true;
            this.WindowState = WindowState.Minimized;

            string Name = ProfileNicknameTextbox.Text;

            LoadingWindow LoadingWindow = new LoadingWindow();
            LoadingWindow.Version = "1.12.2";
            LoadingWindow.IP = "minigames.bedrock-project.ru";
            LoadingWindow.Nickname = Name;
            LoadingWindow.Owner = this;
            LoadingWindow.ShowDialog();
        }

        private void ServersMinigamesButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ServersMinigamesWallpaper.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
            ServersMinigamesWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);

            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = ServersMinigamesWallpaper.Width;
            SizeAnimation.To = 630;
            SizeAnimation.DecelerationRatio = 1;
            SizeAnimation.Duration = TimeSpan.FromSeconds(1);
            ServersMinigamesWallpaper.BeginAnimation(Image.WidthProperty, SizeAnimation);
        }

        private void ServersMinigamesButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ServersMinigamesWallpaper.Opacity;
            OpacityAnimation.To = 0.6;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
           
            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = ServersMinigamesWallpaper.Width;
            SizeAnimation.To = 560;
            SizeAnimation.Duration = TimeSpan.FromSeconds(0.1);

            ServersMinigamesWallpaper.BeginAnimation(Image.WidthProperty, SizeAnimation);
            ServersMinigamesWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);
        }

        private async void ServersRoleplayButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);
            this.IsEnabled = false;

            await Task.Delay(500);
            MinecraftState = true;
            this.WindowState = WindowState.Minimized;

            string Name = ProfileNicknameTextbox.Text;

            LoadingWindow LoadingWindow = new LoadingWindow();
            LoadingWindow.Version = "1.14";
            LoadingWindow.IP = "roleplay.bedrock-project.ru";
            LoadingWindow.Nickname = Name;
            LoadingWindow.Owner = this;
            LoadingWindow.ShowDialog();
        }

        private void ServersRoleplayButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ServersRoleplayWallpaper.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
            ServersRoleplayWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);

            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = ServersRoleplayWallpaper.Width;
            SizeAnimation.To = 630;
            SizeAnimation.DecelerationRatio = 1;
            SizeAnimation.Duration = TimeSpan.FromSeconds(1);
            ServersRoleplayWallpaper.BeginAnimation(Image.WidthProperty, SizeAnimation);
        }

        private void ServersRoleplayButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ServersRoleplayWallpaper.Opacity;
            OpacityAnimation.To = 0.6;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
            
            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = ServersRoleplayWallpaper.Width;
            SizeAnimation.To = 560;
            SizeAnimation.Duration = TimeSpan.FromSeconds(0.1);

            ServersRoleplayWallpaper.BeginAnimation(Image.WidthProperty, SizeAnimation);
            ServersRoleplayWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);
        }

        private async void ServersDominationButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);
            this.IsEnabled = false;

            await Task.Delay(500);
            MinecraftState = true;
            this.WindowState = WindowState.Minimized;

            string Name = ProfileNicknameTextbox.Text;

            LoadingWindow LoadingWindow = new LoadingWindow();
            LoadingWindow.IP = "domination.bedrock-project.ru";
            LoadingWindow.Nickname = Name;
            LoadingWindow.Owner = this;
            LoadingWindow.ShowDialog();
        }

        private void ServersDominationButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ServersDominationWallpaper.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);
            ServersDominationWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);

            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = ServersDominationWallpaper.Width;
            SizeAnimation.To = 630;
            SizeAnimation.DecelerationRatio = 1;
            SizeAnimation.Duration = TimeSpan.FromSeconds(1);
            ServersDominationWallpaper.BeginAnimation(Image.WidthProperty, SizeAnimation);
        }

        private void ServersDominationButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = ServersDominationWallpaper.Opacity;
            OpacityAnimation.To = 0.6;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.2);

            DoubleAnimation SizeAnimation = new DoubleAnimation();
            SizeAnimation.From = ServersDominationWallpaper.Width;
            SizeAnimation.To = 560;
            SizeAnimation.Duration = TimeSpan.FromSeconds(0.1);

            ServersDominationWallpaper.BeginAnimation(Image.WidthProperty, SizeAnimation);
            ServersDominationWallpaper.BeginAnimation(Image.OpacityProperty, OpacityAnimation);
        }

        

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            BlurEffect EffectBlur = new BlurEffect();
            EffectBlur.Radius = 10;
            this.Effect = EffectBlur;

            SettingsWindow SettingsWindow = new SettingsWindow();
            SettingsWindow.Owner = this;
            SettingsWindow.ShowDialog();
        }

        private void SettingsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = Settings.Opacity;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.1);

            TranslateTransform Transform = new TranslateTransform();
            Settings.RenderTransform = Transform;
            DoubleAnimation MarginAnimation = new DoubleAnimation();
            MarginAnimation.From = Settings.Margin.Right;
            MarginAnimation.To = 100;
            MarginAnimation.Duration = TimeSpan.FromSeconds(0.4);

            Settings.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
            Transform.BeginAnimation(TranslateTransform.XProperty, MarginAnimation);
        }

        private void SettingsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = Settings.Opacity;
            OpacityAnimation.To = 0.5;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.1);

            TranslateTransform Transform = new TranslateTransform();
            Settings.RenderTransform = Transform;
            DoubleAnimation MarginAnimation = new DoubleAnimation();
            MarginAnimation.From = Settings.Margin.Right;
            MarginAnimation.To = 0;
            MarginAnimation.Duration = TimeSpan.FromSeconds(0.4);

            Settings.BeginAnimation(Border.OpacityProperty, OpacityAnimation);
            Transform.BeginAnimation(TranslateTransform.XProperty, MarginAnimation);
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
  
        private void ProfileAvatarButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "Png Image|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (SaveFileDialog.ShowDialog() == true)
            {
                string ImageFile = SaveFileDialog.FileName;
                ProfileAvatarImage.Source = new BitmapImage(new Uri(ImageFile));
                ProfileAvatarImageSource = ImageFile;
            }
        }

        private void ProfileAvatarButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ProfileAvatarImage.Width += 10;
            ProfileAvatarImage.Height += 10;
        }

        private void ProfileAvatarButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ProfileAvatarImage.Width -= 10;
            ProfileAvatarImage.Height -= 10;
        }

       
    }
}
