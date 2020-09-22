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
 
    public partial class LoadWindow : Window
    {
        public LoadWindow()
        {
            InitializeComponent();
        }

        private async void Loading(object sender, RoutedEventArgs e)
        {

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity -= 0.1;
                await Task.Delay(50);
            }

            for (int b = 10; b > 0; b--)
            {
                WindowLoadFragmentMainImageBedrock.Opacity += 0.1;
                await Task.Delay(50);
            }


            await Task.Delay(100);
            this.Close();
        }
    }
}
