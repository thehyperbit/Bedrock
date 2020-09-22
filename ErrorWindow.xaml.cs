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
 
    public partial class ErrorWindow : Window
    {
        public ErrorWindow()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            WindowErrorFragmentExitTextBlock.Text = "             Нарушена целостность файлов.\n  Попробуйте перезапустить лаунчер. Если\n проблема не исчезнет, переустановите его.";

            Timer();
        }

        private async void Timer()
        {
            for (int b = 10; b > 0; b--)
            {
                WindowErrorFragmentExitTimer.Text = b.ToString();
                await Task.Delay(1000);
            }

            for (int b = 10; b > 0; b--)
            {
                this.Opacity -= 0.1;
                await Task.Delay(15);
            }

            Environment.Exit(0);
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
                await Task.Delay(15);
            }

            Environment.Exit(0);
        }

        private void WindowErrorFragmentExitButtonMouseEnter(object sender, MouseEventArgs e)
        {
            WindowErrorFragmentExitBorder.Width += 20;
            WindowErrorFragmentExitBorder.Height += 0;
        }

        private void WindowErrorFragmentExitButtonMouseLeave(object sender, MouseEventArgs e)
        {
            WindowErrorFragmentExitBorder.Width -= 20;
            WindowErrorFragmentExitBorder.Height -= 0;
        }

        private async void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
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
                await Task.Delay(15);
            }

            Process[] BedrockProcesses = Process.GetProcessesByName("Bedrock");
            foreach (Process CurrentProcess in BedrockProcesses)
            {
                CurrentProcess.Kill();
            }
        }
    }
}
