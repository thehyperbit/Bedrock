using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
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
    public partial class ClaimWindow : Window
    {
        private string TotalPath = Directory.GetCurrentDirectory();

        public ClaimWindow()
        {
            InitializeComponent();

            this.Cursor = ((TextBlock)this.Resources["CursorMain"]).Cursor;
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
            this.Close();
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

        private void ViolationTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Dispatch.Opacity != 1)
            {
                Dispatch.Opacity = 1;
                Dispatch.IsEnabled = true; 
            }
        }

        private async void DispatchButton_Click(object sender, RoutedEventArgs e)
        {
            Random Random = new Random();
            int HashCode = Random.Next(100000, 999999);
            string Type = "Использование читов";

            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = Dispatch.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);
            Dispatch.BeginAnimation(Border.OpacityProperty, OpacityAnimation);

            Dispatch.IsEnabled = false;

            await Task.Delay(400);

            if (ViolationComboBox.SelectedIndex == 0)
            {
                Type = "Использование читов";
            }
            else if (ViolationComboBox.SelectedIndex == 1)
            {
                Type = "Использование багов";
            }
            else if (ViolationComboBox.SelectedIndex == 2)
            {
                Type = "Токсичное поведение";
            }
            else if (ViolationComboBox.SelectedIndex == 3)
            {
                Type = "Недоработка проекта";
            }

            try
            {
                using (FileStream FileStream = File.Create(TotalPath + @"/Storage/Saves/report"))
                {
                    byte[] Text = new UTF8Encoding(true).GetBytes("Дата: " + DateTime.Now.ToString() + "\n" + "Никнейм: " + NicknameTextBox.Text + "\n" + "Вид нарушения: " + Type + "\n" + "Сообщение: " + ViolationTextBox.Text);
                    FileStream.Write(Text, 0, Text.Length);
                }

                using (SftpClient Client = new SftpClient("bedrock-project.ru", "root", "singularity"))
                {
                    Client.Connect();

                    using (var UploadFile = File.OpenRead(TotalPath + @"/Storage/Saves/report"))
                    {
                        Client.UploadFile(UploadFile, "/storage/reports/report" + HashCode);
                    }
                    Client.Disconnect();
                }
            }
            catch
            {
                
            }

            DoubleAnimation WindowOpacityAnimation = new DoubleAnimation();
            WindowOpacityAnimation.From = this.Opacity;
            WindowOpacityAnimation.To = 0;
            WindowOpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);
            this.BeginAnimation(Window.OpacityProperty, WindowOpacityAnimation);

            await Task.Delay(300);

            this.Owner.Effect = null;
            this.Close();
        }

        private void DispatchButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Dispatch.Width = 128;
            Dispatch.Height = 44;         
        }

        private void DispatchButton_MouseLeave(object sender, MouseEventArgs e)
        {        
            Dispatch.Width = 120;         
            Dispatch.Height = 38;
        }
    }
}
