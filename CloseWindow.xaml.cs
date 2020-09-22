using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class CloseWindow : Window
    {
        public CloseWindow()
        {
            InitializeComponent();
        }

        private async void LauncherClose(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    Process[] ServerProcesses = Process.GetProcessesByName("java");
                    foreach (Process CurrentProcess in ServerProcesses)
                    {
                        CurrentProcess.Kill();
                    }
                }
                catch { }
                
                try
                {
                    Process[] MinecraftProcesses = Process.GetProcessesByName("javaw");
                    foreach (Process CurrentProcess in MinecraftProcesses)
                    {
                        CurrentProcess.Kill();
                    }
                }
                catch { }                      
            }
            catch { }          

            for (int b = 10; b > 0; b--)
            {
                this.Opacity -= 0.1;
                this.Owner.Opacity -= 0.1;
                await Task.Delay(15);
            }

            this.Owner.Close();
        }

        private async void LauncherReturn(object sender, RoutedEventArgs e)
        {
            for (int b = 10; b > 0; b--)
            {
                this.Opacity -= 0.1;
                await Task.Delay(15);
            }

            this.Owner.Effect = null;
            this.Close();
        }

        private void WindowCloseFragmentReturnButtonMouseEnter(object sender, MouseEventArgs e)
        {
            WindowCloseFragmentReturnBorder.Width += 10;
            WindowCloseFragmentReturnBorder.Height += 4;
        }

        private void WindowCloseFragmentReturnBorderMouseLeave(object sender, MouseEventArgs e)
        {
            WindowCloseFragmentReturnBorder.Width -= 10;
            WindowCloseFragmentReturnBorder.Height -= 4;
        }

        private void WindowCloseFragmentExitButtonMouseEnter(object sender, MouseEventArgs e)
        {
            WindowCloseFragmentExitBorder.Width += 10;
            WindowCloseFragmentExitBorder.Height += 4;
        }

        private void WindowCloseFragmentExitButtonMouseLeave(object sender, MouseEventArgs e)
        {
            WindowCloseFragmentExitBorder.Width -= 10;
            WindowCloseFragmentExitBorder.Height -= 4;
        }
       
    }
}
