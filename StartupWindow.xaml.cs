using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
     
    public partial class StartupWindow : Window
    {
        private byte Verification = 3;

        public StartupWindow()
        {
            InitializeComponent();

            Initialize();
        }

        private async void Initialize()
        {
            await Task.Run(() => VerificationCheck());

            Animation();
        }

        private void VerificationCheck()
        {
            try
            {
                Process[] LauncherProcesses = Process.GetProcessesByName("Bedrock");
                if (LauncherProcesses.Length > 1)
                {
                    Environment.Exit(0);
                }

                string Path = Directory.GetCurrentDirectory();

                if (!Directory.Exists(Path + @"\Minecraft"))
                {
                    Environment.Exit(1);
                }

                if (!Directory.Exists(Path + @"\Resource"))
                {
                    Environment.Exit(1);
                }
                else
                {
                    if (!Directory.Exists(Path + @"\Resource\Fonts"))
                    {
                        Environment.Exit(1);
                    }
                    else if (!Directory.Exists(Path + @"\Resource\Images"))
                    {
                        Environment.Exit(1);
                    }
                    else if (!Directory.Exists(Path + @"\Resource\Sounds"))
                    {
                        Environment.Exit(1);
                    }
                    else if (!Directory.Exists(Path + @"\Resource\Videos"))
                    {
                        Environment.Exit(1);
                    }
                }

                if (!Directory.Exists(Path + @"\Servers"))
                {
                    Verification = 2;
                }
                else
                {
                    if (!Directory.Exists(Path + @"\Servers\1.15"))
                    {
                        Verification = 2;
                    }
                    else
                    {
                        if (!File.Exists(Path + @"\Servers\1.15\Server(1.15).jar"))
                        {
                            Verification = 2;
                        }
                        else if (!File.Exists(Path + @"\Servers\1.15\eula.txt"))
                        {
                            Verification = 2;
                        }

                    }
                }

                if (!Directory.Exists(Path + @"\Storage"))
                {
                    Verification = 2;
                }
                else
                {
                    if (!Directory.Exists(Path + @"\Storage\Crash Reports"))
                    {
                        Verification = 2;
                    }
                    else if (!Directory.Exists(Path + @"\Storage\Privacy Policy"))
                    {
                        Verification = 2;
                    }
                    else if (!Directory.Exists(Path + @"\Storage\Users"))
                    {
                        Verification = 2;
                    }
                    else if (!File.Exists(Path + @"\Storage\Users\User.dat"))
                    {
                        Verification = 1;
                    }
                    else if (File.Exists(Path + @"\Storage\Users\User.dat"))
                    {
                        Verification = 0; 
                    }  
                }
            }
            catch (Exception)
            {
                Environment.Exit(1);
            }
        }

        private async void Animation()
        {
            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                FragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            while (Verification == 3) { }

            if (Verification == 2)
            {
                Environment.Exit(2);
            }
            else if (Verification == 1)
            {
                AccountWindow AccountWindow = new AccountWindow();
                AccountWindow.Show();
            }
            else if (Verification == 0)
            {
                MainWindow MainWindow = new MainWindow();
                MainWindow.Show();
            }
           
            this.Close();
        }

    }
}
