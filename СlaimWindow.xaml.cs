using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bedrock
{
    /// <summary>
    /// Логика взаимодействия для СlaimWindow.xaml
    /// </summary>
    public partial class СlaimWindow : Window
    {
        public СlaimWindow()
        {
            InitializeComponent();

            MainInitialize();
        }

        public async void MainInitialize()
        {
            
        }

        private async void WindowClaimFragmentUIButtonCloseClick(object sender, RoutedEventArgs e)
        {
            for (int b = 10; b > 0; b--)
            {
                this.Opacity -= 0.1;
                await Task.Delay(15);
            }

            this.Owner.Effect = null;
            this.Close();
        }

        private void WindowClaimFragmentUIButtonCloseMouseEnter(object sender, MouseEventArgs e)
        {
            WindowClaimFragmentUIViewboxClose.Width += 6;
            WindowClaimFragmentUIViewboxClose.Height += 6;
        }

        private void WindowClaimFragmentUIButtonCloseMouseLeave(object sender, MouseEventArgs e)
        {
            WindowClaimFragmentUIViewboxClose.Width -= 6;
            WindowClaimFragmentUIViewboxClose.Height -= 6;
        }

        private void WindowClaimFragmentSendButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void WindowClaimFragmentSendButtonMouseEnter(object sender, MouseEventArgs e)
        {
            WindowClaimFragmentSendBorder.Width += 15;
            WindowClaimFragmentSendBorder.Height += 6;
        }

        private void WindowClaimFragmentSendButtonMouseLeave(object sender, MouseEventArgs e)
        {
            WindowClaimFragmentSendBorder.Width -= 15;
            WindowClaimFragmentSendBorder.Height -= 6;
        }
    }
}
