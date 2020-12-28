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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Bedrock
{
    public partial class LoginWindow : Window
    {
        private static bool Verification = false;
        private string TotalPath = Directory.GetCurrentDirectory();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                string[] Nicknames = Directory.GetFiles(TotalPath + @"/Storage/Users");

                foreach (string FileName in Nicknames)
                {
                    string Nickname = System.IO.Path.GetFileName(FileName);
                    LoginTEXT.Text = Nickname;
                }
            }
            catch { }
        }

        private void Window_Movement(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Verification == false)
            {
                Environment.Exit(0);
            }
        }

        private async void UIExitButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);

            await Task.Delay(300);

            this.Owner.Effect = null;
            Environment.Exit(0);
        }

        private void UIExitButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = UIExitIcon.Width;
            WidthAnimation.To = 33;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.1);

            DoubleAnimation HeightAnimation = new DoubleAnimation();
            HeightAnimation.From = UIExitIcon.Height;
            HeightAnimation.To = 33;
            HeightAnimation.Duration = TimeSpan.FromSeconds(0.1);

            UIExitIcon.BeginAnimation(Border.WidthProperty, WidthAnimation);
            UIExitIcon.BeginAnimation(Border.HeightProperty, HeightAnimation);
        }

        private void UIExitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = UIExitIcon.Width;
            WidthAnimation.To = 28;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.1);

            DoubleAnimation HeightAnimation = new DoubleAnimation();
            HeightAnimation.From = UIExitIcon.Height;
            HeightAnimation.To = 28;
            HeightAnimation.Duration = TimeSpan.FromSeconds(0.1);

            UIExitIcon.BeginAnimation(Border.WidthProperty, WidthAnimation);
            UIExitIcon.BeginAnimation(Border.HeightProperty, HeightAnimation);
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginButtonBackground.IsEnabled = false;

            string Password = "password";

            try
            {
                string[] Nicknames = Directory.GetFiles(TotalPath + @"/Storage/Users");

                foreach (string Nickname in Nicknames)
                {
                    try
                    {
                        File.Delete(Nickname);
                    }
                    catch
                    {
                        break;
                    } 
                }
            }
            catch { }
           


            try
            {
                using (SftpClient Client = new SftpClient("bedrock-project.ru", "root", Password.Replace("password", "singularity")))
                {
                    Client.Connect();

                    using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Storage/Users/" + LoginTEXT.Text.ToString().Trim()))
                    {
                        Client.DownloadFile("/storage/accounts/" + LoginTEXT.Text.ToString().Trim() + "_" + PasswordTEXT.Password.ToString().Trim(), fileStream);
                    }

                    Client.Disconnect();
                }

                using (FileStream FileStream = File.OpenWrite(TotalPath + LoginTEXT.Text.ToString().Trim()))
                {
                    byte[] Info = new UTF8Encoding(true).GetBytes(PasswordTEXT.Password.ToString().Trim());

                    FileStream.Write(Info, 0, Info.Length);
                }

                Verification = true;

                DoubleAnimation OpacityAnimation = new DoubleAnimation();
                OpacityAnimation.From = this.Opacity;
                OpacityAnimation.To = 0;
                OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
                this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);
                await Task.Delay(500);
                this.Close();
            }
            catch 
            {
                try
                {
                    string[] Nicknames = Directory.GetFiles(TotalPath + @"/Storage/Users");

                    foreach (string Nickname in Nicknames)
                    {
                        try
                        {
                            File.Delete(Nickname);
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
                catch { }

                ErrorWindow ErrorWindow = new ErrorWindow();
                ErrorWindow.Owner = this;
                ErrorWindow.ErrorText.Text = "Неверный логин или пароль!";
                BlurEffect EffectBlur = new BlurEffect();
                EffectBlur.Radius = 10;
                this.Effect = EffectBlur;
                ErrorWindow.ShowDialog();

                LoginButtonBackground.IsEnabled = true;
            }
        }

        private void LoginButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From =LoginButtonBackground.Width;
            WidthAnimation.To = 190;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.2);
            LoginButtonBackground.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private void LoginButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = LoginButtonBackground.Width;
            WidthAnimation.To = 170;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.2);
            LoginButtonBackground.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginButtonBackground.Opacity == 1)
            {
                PasswordTEXT.Password = null;
                PasswordRepeatTEXT.Password = null;

                LoginButtonBackground.IsEnabled = false;
                RegisterPromptButton.Visibility = Visibility.Visible;

                PasswordBackground.Margin = new Thickness(0, -60, 0, 0);
                PasswordPrompt.Margin = new Thickness(-160, -120, 0, 0);

                EmailBackground.Visibility = Visibility.Visible;
                EmailPrompt.Visibility = Visibility.Visible;
                PasswordRepeatBackground.Visibility = Visibility.Visible;
                PasswordRepeatPrompt.Visibility = Visibility.Visible;

                DoubleAnimation LoginOpacityAnimation = new DoubleAnimation();
                LoginOpacityAnimation.From = LoginButtonBackground.Opacity;
                LoginOpacityAnimation.To = 0;
                LoginOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

                DoubleAnimation RegisterPromptOpacityAnimation = new DoubleAnimation();
                RegisterPromptOpacityAnimation.From = RegisterPrompt.Opacity;
                RegisterPromptOpacityAnimation.To = 1;
                RegisterPromptOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

                DoubleAnimation DecorationsOpacityAnimation = new DoubleAnimation();
                DecorationsOpacityAnimation.From = Decorations.Opacity;
                DecorationsOpacityAnimation.To = 0;
                DecorationsOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

                DoubleAnimation PasswordRepeatBackgroundOpacityAnimation = new DoubleAnimation();
                PasswordRepeatBackgroundOpacityAnimation.From = PasswordRepeatBackground.Opacity;
                PasswordRepeatBackgroundOpacityAnimation.To = 1;
                PasswordRepeatBackgroundOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

                DoubleAnimation PasswordRepeatPromptOpacityAnimation = new DoubleAnimation();
                PasswordRepeatPromptOpacityAnimation.From = PasswordRepeatPrompt.Opacity;
                PasswordRepeatPromptOpacityAnimation.To = 1;
                PasswordRepeatPromptOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

                DoubleAnimation EmailBackgroundOpacityAnimation = new DoubleAnimation();
                EmailBackgroundOpacityAnimation.From = EmailBackground.Opacity;
                EmailBackgroundOpacityAnimation.To = 1;
                EmailBackgroundOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

                DoubleAnimation EmailPromptOpacityAnimation = new DoubleAnimation();
                EmailPromptOpacityAnimation.From = EmailPrompt.Opacity;
                EmailPromptOpacityAnimation.To = 1;
                EmailPromptOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);


                LoginButtonBackground.BeginAnimation(Border.OpacityProperty, LoginOpacityAnimation);
                RegisterPrompt.BeginAnimation(Border.OpacityProperty, RegisterPromptOpacityAnimation);
                Decorations.BeginAnimation(Border.OpacityProperty, LoginOpacityAnimation);
                PasswordRepeatBackground.BeginAnimation(Border.OpacityProperty, PasswordRepeatBackgroundOpacityAnimation);
                PasswordRepeatPrompt.BeginAnimation(TextBlock.OpacityProperty, PasswordRepeatPromptOpacityAnimation);
                EmailBackground.BeginAnimation(Border.OpacityProperty, EmailBackgroundOpacityAnimation);
                EmailPrompt.BeginAnimation(TextBlock.OpacityProperty, EmailPromptOpacityAnimation);
            }
            else
            {
                RegisterButtonBackground.IsEnabled = false;

                if (PasswordTEXT.Password != PasswordRepeatTEXT.Password)
                {
                    ErrorWindow ErrorWindow = new ErrorWindow();
                    ErrorWindow.Owner = this;
                    ErrorWindow.ErrorText.Text = "Пароли не совпадают!";
                    BlurEffect EffectBlur = new BlurEffect();
                    EffectBlur.Radius = 10;
                    this.Effect = EffectBlur;
                    ErrorWindow.ShowDialog();
                }
                else if (PasswordTEXT.Password.Equals("") || PasswordRepeatTEXT.Password.Equals(""))
                {
                    ErrorWindow ErrorWindow = new ErrorWindow();
                    ErrorWindow.Owner = this;
                    ErrorWindow.ErrorText.Text = "Введите пароль!";
                    BlurEffect EffectBlur = new BlurEffect();
                    EffectBlur.Radius = 10;
                    this.Effect = EffectBlur;
                    ErrorWindow.ShowDialog();
                }
                else if (LoginTEXT.Text.Equals(""))
                {
                    ErrorWindow ErrorWindow = new ErrorWindow();
                    ErrorWindow.Owner = this;
                    ErrorWindow.ErrorText.Text = "Введите логин!";
                    BlurEffect EffectBlur = new BlurEffect();
                    EffectBlur.Radius = 10;
                    this.Effect = EffectBlur;
                    ErrorWindow.ShowDialog();
                }
                else if (LoginTEXT.Text.Length <= 2)
                {
                    ErrorWindow ErrorWindow = new ErrorWindow();
                    ErrorWindow.Owner = this;
                    ErrorWindow.ErrorText.Text = "Логин слишком короткий!";
                    BlurEffect EffectBlur = new BlurEffect();
                    EffectBlur.Radius = 10;
                    this.Effect = EffectBlur;
                    ErrorWindow.ShowDialog();
                }
                else if (EmailTEXT.Text.Equals("") || !(EmailTEXT.Text.Contains("@")))
                {
                    ErrorWindow ErrorWindow = new ErrorWindow();
                    ErrorWindow.Owner = this;
                    ErrorWindow.ErrorText.Text = "Введите Email!";
                    BlurEffect EffectBlur = new BlurEffect();
                    EffectBlur.Radius = 10;
                    this.Effect = EffectBlur;
                    ErrorWindow.ShowDialog();
                }
                else if (PasswordTEXT.Password == PasswordRepeatTEXT.Password && PasswordTEXT.Password != null)
                {
                    string Password = "password";

                    try
                    {
                        using (SftpClient Client = new SftpClient("bedrock-project.ru", "root", Password.Replace("password", "singularity")))
                        {
                            Client.Connect();

                            using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Storage/Users/" + LoginTEXT.Text.ToString().Trim()))
                            {
                                Client.DownloadFile("/storage/nicknames/" + LoginTEXT.Text.ToString().Trim(), fileStream);
                            }

                            Client.Disconnect();
                        }

                        ErrorWindow ErrorWindow = new ErrorWindow();
                        ErrorWindow.Owner = this;
                        ErrorWindow.ErrorText.Text = "Такой логин уже \n    существует!  ";
                        BlurEffect EffectBlur = new BlurEffect();
                        EffectBlur.Radius = 10;
                        this.Effect = EffectBlur;
                        ErrorWindow.ShowDialog();
                    }
                    catch
                    {
                        try
                        {
                            using (SftpClient Client = new SftpClient("bedrock-project.ru", "root", Password.Replace("password", "singularity")))
                            {
                                Client.Connect();

                                using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Storage/Users/" + LoginTEXT.Text.ToString().Trim() + "_" + PasswordRepeatTEXT.Password.ToString().Trim()))
                                {
                                    Client.UploadFile(fileStream, "/storage/accounts/" + LoginTEXT.Text.ToString().Trim() + "_" + PasswordRepeatTEXT.Password.ToString().Trim());
                                }

                                Client.Disconnect();
                            }

                            using (SftpClient Client = new SftpClient("bedrock-project.ru", "root", Password.Replace("password", "singularity")))
                            {
                                Client.Connect();

                                using (Stream fileStream = File.Create(Environment.CurrentDirectory + @"/Storage/Users/" + LoginTEXT.Text.ToString().Trim() + "_" + PasswordRepeatTEXT.Password.ToString().Trim()))
                                {
                                    Client.UploadFile(fileStream, "/storage/nicknames/" + LoginTEXT.Text.ToString().Trim());
                                }

                                Client.Disconnect();
                            }

                            try
                            {
                                File.Delete(Environment.CurrentDirectory + @"/Storage/Users/" + LoginTEXT.Text.ToString().Trim() + "_" + PasswordRepeatTEXT.Password.ToString().Trim());
                                File.Create(Environment.CurrentDirectory + @"/Storage/Users/" + LoginTEXT.Text.ToString().Trim());
                            }
                            catch { }

                            Verification = true;

                            DoubleAnimation OpacityAnimation = new DoubleAnimation();
                            OpacityAnimation.From = this.Opacity;
                            OpacityAnimation.To = 0;
                            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
                            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);

                            await Task.Delay(500);
                            this.Close();

                        }
                        catch
                        {
                            ErrorWindow ErrorWindow = new ErrorWindow();
                            ErrorWindow.Owner = this;
                            ErrorWindow.ErrorText.Text = "Что-то пошло не так!";
                            BlurEffect EffectBlur = new BlurEffect();
                            EffectBlur.Radius = 10;
                            this.Effect = EffectBlur;
                            ErrorWindow.ShowDialog();
                        }
                    }
                }

                RegisterButtonBackground.IsEnabled = true;
            }
            
        }

        private void RegisterButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = RegisterButtonBackground.Width;
            WidthAnimation.To = 190;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.2);
            RegisterButtonBackground.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private void RegisterButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = RegisterButtonBackground.Width;
            WidthAnimation.To = 170;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.2);
            RegisterButtonBackground.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private void RegsiterPromptButton_Click(object sender, RoutedEventArgs e)
        {
            PasswordTEXT.Password = null;
            PasswordRepeatTEXT.Password = null;

            LoginButtonBackground.IsEnabled = true;
            RegisterPromptButton.Visibility = Visibility.Hidden;

            PasswordBackground.Margin = new Thickness(0, -190, 0, 0);
            PasswordPrompt.Margin = new Thickness(-160, -250, 0, 0);

            EmailBackground.Visibility = Visibility.Hidden;
            EmailPrompt.Visibility = Visibility.Hidden;
            PasswordRepeatBackground.Visibility = Visibility.Hidden;
            PasswordRepeatPrompt.Visibility = Visibility.Hidden;

            DoubleAnimation LoginOpacityAnimation = new DoubleAnimation();
            LoginOpacityAnimation.From = LoginButtonBackground.Opacity;
            LoginOpacityAnimation.To = 1;
            LoginOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

            DoubleAnimation RegisterPromptOpacityAnimation = new DoubleAnimation();
            RegisterPromptOpacityAnimation.From = RegisterPrompt.Opacity;
            RegisterPromptOpacityAnimation.To = 0;
            RegisterPromptOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

            DoubleAnimation DecorationsOpacityAnimation = new DoubleAnimation();
            DecorationsOpacityAnimation.From = Decorations.Opacity;
            DecorationsOpacityAnimation.To = 1;
            DecorationsOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

            DoubleAnimation PasswordRepeatBackgroundOpacityAnimation = new DoubleAnimation();
            PasswordRepeatBackgroundOpacityAnimation.From = PasswordRepeatBackground.Opacity;
            PasswordRepeatBackgroundOpacityAnimation.To = 0;
            PasswordRepeatBackgroundOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

            DoubleAnimation PasswordRepeatPromptOpacityAnimation = new DoubleAnimation();
            PasswordRepeatPromptOpacityAnimation.From = PasswordRepeatPrompt.Opacity;
            PasswordRepeatPromptOpacityAnimation.To = 0;
            PasswordRepeatPromptOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

            DoubleAnimation EmailBackgroundOpacityAnimation = new DoubleAnimation();
            EmailBackgroundOpacityAnimation.From = EmailBackground.Opacity;
            EmailBackgroundOpacityAnimation.To = 0;
            EmailBackgroundOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);

            DoubleAnimation EmailPromptOpacityAnimation = new DoubleAnimation();
            EmailPromptOpacityAnimation.From = EmailPrompt.Opacity;
            EmailPromptOpacityAnimation.To = 0;
            EmailPromptOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);


            LoginButtonBackground.BeginAnimation(Border.OpacityProperty, LoginOpacityAnimation);
            RegisterPrompt.BeginAnimation(Border.OpacityProperty, RegisterPromptOpacityAnimation);
            Decorations.BeginAnimation(Border.OpacityProperty, LoginOpacityAnimation);
            PasswordRepeatBackground.BeginAnimation(Border.OpacityProperty, PasswordRepeatBackgroundOpacityAnimation);
            PasswordRepeatPrompt.BeginAnimation(TextBlock.OpacityProperty, PasswordRepeatPromptOpacityAnimation);
            EmailBackground.BeginAnimation(Border.OpacityProperty, EmailBackgroundOpacityAnimation);
            EmailPrompt.BeginAnimation(TextBlock.OpacityProperty, EmailPromptOpacityAnimation);
        }

        private void RegsiterPromptButton_MouseEnter(object sender, MouseEventArgs e)
        {
            RegisterPrompt.TextDecorations = System.Windows.TextDecorations.Underline;
        }

        private void RegsiterPromptButton_MouseLeave(object sender, MouseEventArgs e)
        {
            RegisterPrompt.TextDecorations = null;
        }
    }
}
