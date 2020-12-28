using System;
using System.Collections.Generic;
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
   
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
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
    }
}
