using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Bedrock
{
    sealed class DataLauncher
    {
        public string Path { get; set; }

        public string Version { get; set; }

        public async void Initialize()
        {      
            try
            {
                Process[] LauncherProcesses = Process.GetProcessesByName("Bedrock");
                if(LauncherProcesses.Length > 1)
                {
                    ErrorWindow ErrorWindow = new ErrorWindow();
                    ErrorWindow.WindowErrorFragmentExitTextBlock.Text = "                  Приложение уже запущено.";
                    ErrorWindow.ShowDialog();
                    Environment.Exit(1);
                }

                Path = Directory.GetCurrentDirectory();

                if(!Directory.Exists(Path + @"\minecraft"))
                {
                    ErrorWindow ErrorWindow = new ErrorWindow();
                    ErrorWindow.ShowDialog();
                }

                if (!Directory.Exists(Path + @"\resource"))
                {
                    ErrorWindow ErrorWindow = new ErrorWindow();
                    ErrorWindow.ShowDialog();
                }
                else
                {
                    if (!Directory.Exists(Path + @"\resource\fonts"))
                    {
                        ErrorWindow ErrorWindow = new ErrorWindow();
                        ErrorWindow.ShowDialog();
                    }
                    else if (!Directory.Exists(Path + @"\resource\images"))
                    {
                        ErrorWindow ErrorWindow = new ErrorWindow();
                        ErrorWindow.ShowDialog();
                    }
                    else if (!Directory.Exists(Path + @"\resource\sounds"))
                    {
                        ErrorWindow ErrorWindow = new ErrorWindow();
                        ErrorWindow.ShowDialog();
                    }
                    else if (!Directory.Exists(Path + @"\resource\videos"))
                    {
                        ErrorWindow ErrorWindow = new ErrorWindow();
                        ErrorWindow.ShowDialog();
                    }
                }

                if (!Directory.Exists(Path + @"\servers"))
                {
                    ErrorWindow ErrorWindow = new ErrorWindow();
                    ErrorWindow.ShowDialog();
                }
                else
                {
                    if (!Directory.Exists(Path + @"\servers\1.15"))
                    {
                        ErrorWindow ErrorWindow = new ErrorWindow();
                        ErrorWindow.ShowDialog();
                    }
                    else
                    {
                        if (!File.Exists(Path + @"\servers\1.15\Server(1.15).jar"))
                        {
                            ErrorWindow ErrorWindow = new ErrorWindow();
                            ErrorWindow.ShowDialog();
                        }     
                    }
                }
            }
            catch (Exception)
            {
                Console.Beep(20000, 1000);
                ErrorWindow ErrorWindow = new ErrorWindow();
                ErrorWindow.ShowDialog();
            }
        }

    }
}
