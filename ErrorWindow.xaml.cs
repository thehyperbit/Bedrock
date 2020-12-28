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
    public partial class ErrorWindow : Window
    {
        public static string ErrorMessage = "Ошибка!";
        public ErrorWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //ErrorText.Text = ErrorMessage;
        }

        private async void StayButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.4);
            this.BeginAnimation(Border.OpacityProperty,OpacityAnimation);

            await Task.Delay(400);
            this.Owner.Effect = null;
            this.Close();
        }

        private void StayButton_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = StayButtonBackground.Width;
            WidthAnimation.To = 180;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.3);
            StayButtonBackground.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }

        private void StayButton_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation WidthAnimation = new DoubleAnimation();
            WidthAnimation.From = StayButtonBackground.Width;
            WidthAnimation.To = 140;
            WidthAnimation.Duration = TimeSpan.FromSeconds(0.3);
            StayButtonBackground.BeginAnimation(Border.WidthProperty, WidthAnimation);
        }
    }
}
