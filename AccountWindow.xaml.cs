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

    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            Animation();
        }

        private async void Animation()
        {
            for (short b = 0; b < 50; b++)
            {
                await Task.Delay(1);
                this.Opacity += 0.02;
            }
        }

        private void MovementWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
