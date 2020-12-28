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
    public partial class ExitWindow : Window
    {
        public ExitWindow()
        {
            InitializeComponent();

            this.Cursor = ((TextBlock)this.Resources["CursorMain"]).Cursor;
        }

        private async void StayButton_Click(object sender, RoutedEventArgs e)
        {
            for (byte b = 0; b < 10; b++)
            {
                await Task.Delay(2);
                this.Opacity -= 0.1;
 
            }

            this.Close();
            this.Owner.Effect = null;
        }

        private void StayButton_MouseEnter(object sender, MouseEventArgs e)
        {
            StayButtonBackground.Width += 12;
            StayButtonBackground.Height += 5;
        }

        private void StayButton_MouseLeave(object sender, MouseEventArgs e)
        {
            StayButtonBackground.Width -= 12;
            StayButtonBackground.Height -= 5;
        }

        private async void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = this.Owner.Opacity;
            OpacityAnimation.To = 0;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.4);
            
            DoubleAnimation ExitOpacityAnimation = new DoubleAnimation();
            ExitOpacityAnimation.From = this.Opacity;
            ExitOpacityAnimation.To = 0;
            ExitOpacityAnimation.Duration = TimeSpan.FromSeconds(0.4);

            this.Owner.BeginAnimation(Window.OpacityProperty, OpacityAnimation);
            this.BeginAnimation(Window.OpacityProperty, ExitOpacityAnimation);
            await Task.Delay(500);

            this.Owner.Close();
        }

        private void ExitButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitButtonBackground.Width += 12;
            ExitButtonBackground.Height += 5;
        }

        private void ExitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ExitButtonBackground.Width -= 12;
            ExitButtonBackground.Height -= 5;
        }
    }
}
