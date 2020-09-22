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
    public partial class ServerWindow : Window
    {
        public ServerWindow()
        {
            InitializeComponent();
        }

        private void MovementWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
              /*  this.Cursor = ((TextBlock)this.Resources["CursorMovement"]).Cursor;
                this.DragMove(); */

            }
            else
            {
                this.Cursor = ((TextBlock)this.Resources["CursorMain"]).Cursor;
            }
        }

        private async void WindowServerFragmentCreateButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            this.Owner.Effect = null;
            this.Owner.WindowState = WindowState.Minimized;
            this.Owner.ShowInTaskbar = false;
            this.Close();

            LoadWindow LoadWindow = new LoadWindow();
            LoadWindow.ShowDialog();

            string Name;
            string Mode = "survival";
            string Difficult = "easy";
            string Slots;

            Name = WindowServerFragmentNameTextBox.Text;
            if (WindowServerFragmentNameTextBox.Text.Equals(""))
            {
                Name = "Minecraft Server";
            }

            if (WindowServerFragmentModeComboBox.SelectedIndex == 0)
            {
                Mode = "survival";
            }
            else if (WindowServerFragmentModeComboBox.SelectedIndex == 1)
            {
                Mode = "creative";
            }
            else if (WindowServerFragmentModeComboBox.SelectedIndex == 2)
            {
                Mode = "adventure";
            }

            if (WindowServerFragmentDifficultComboBox.SelectedIndex == 0)
            {
                Difficult = "peaceful";
            }
            else if (WindowServerFragmentDifficultComboBox.SelectedIndex == 1)
            {
                Difficult = "easy";
            }
            else if (WindowServerFragmentDifficultComboBox.SelectedIndex == 2)
            {
                Difficult = "normal";
            }
            else if (WindowServerFragmentDifficultComboBox.SelectedIndex == 3)
            {
                Difficult = "hard";
            }

            Slots = (WindowServerFragmentSlotsComboBox.SelectedIndex + 2).ToString();
          
            DataServer DataServer = new DataServer();
            await Task.Run(() => DataServer.Initialize(Name, Mode, Difficult, Slots));

            await Task.Delay(1000);

            string IP = "127.0.0.1";
            int Port = 48211;
            DataMinecraft DataMinecraft = new DataMinecraft();
            await Task.Run(() => DataMinecraft.Start(IP, Port));

            DataConnection DataConnection = new DataConnection();
            await Task.Run(() => DataConnection.Start());
        }

        private void WindowServerFragmentCreateButtonMouseEnter(object sender, MouseEventArgs e)
        {
            WindowServerFragmentCreateBorder.Width += 15;
            WindowServerFragmentCreateBorder.Height += 6;

        }

        private void WindowServerFragmentCreateButtonMouseLeave(object sender, MouseEventArgs e)
        {
            WindowServerFragmentCreateBorder.Width -= 15;
            WindowServerFragmentCreateBorder.Height -= 6;
        }

        private void WindowServerFragmentModeComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WindowServerFragmentModeComboBox.SelectedIndex == 0)
            {
                WindowServerFragmentWallpaperImageSurvival.Opacity = 0.2;
                WindowServerFragmentWallpaperImageCreative.Opacity = 0;
                WindowServerFragmentWallpaperImageAdventure.Opacity = 0;
            }

            if (WindowServerFragmentModeComboBox.SelectedIndex == 1)
            {
                WindowServerFragmentWallpaperImageSurvival.Opacity = 0;
                WindowServerFragmentWallpaperImageCreative.Opacity = 0.2;
                WindowServerFragmentWallpaperImageAdventure.Opacity = 0;
            }

            if (WindowServerFragmentModeComboBox.SelectedIndex == 2)
            {
                WindowServerFragmentWallpaperImageSurvival.Opacity = 0;
                WindowServerFragmentWallpaperImageCreative.Opacity = 0;
                WindowServerFragmentWallpaperImageAdventure.Opacity = 0.2;
            }
        }

        private void WindowServerFragmentUIButtonCloseMouseEnter(object sender, MouseEventArgs e)
        {
            WindowServerFragmentUIViewboxClose.Width += 6;
            WindowServerFragmentUIViewboxClose.Height += 6;
        }

        private void WindowServerFragmentUIButtonCloseMouseLeave(object sender, MouseEventArgs e)
        {
            WindowServerFragmentUIViewboxClose.Width -= 6;
            WindowServerFragmentUIViewboxClose.Height -= 6;
        }

        private async void WindowServerFragmentUIButtonCloseClick(object sender, RoutedEventArgs e)
        {
            for (int b = 10; b > 0; b--)
            {
                this.Opacity -= 0.1;
                await Task.Delay(15);
            }

            this.Owner.Effect = null;
            this.Close();

        }
   
    }
}
