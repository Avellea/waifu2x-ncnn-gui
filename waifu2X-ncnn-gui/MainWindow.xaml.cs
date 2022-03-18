using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Win32;
using waifu2x_ncnn_gui;

namespace waifu2X_ncnn_gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            waifu2xLocationInput.Text = ConfigHandler.GetWaifu2xLocation();
        }


        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select an image.";
            ofd.DefaultExt = ".png";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if(ofd.ShowDialog() == true)
            {
                inputImagePath.Text = ofd.FileName;
                beforePreview.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }


        private void waifu2xLocationBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select an executable.";
            ofd.DefaultExt = ".exe";
            ofd.Filter = "Executable files|*.exe";

            if (ofd.ShowDialog() == true)
            {
                waifu2xLocationInput.Text = ofd.FileName;
                ConfigHandler.SetWaifu2xLocation(waifu2xLocationInput.Text);
                //beforePreview.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }


        private void scaleButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog() == true)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = waifu2xLocationInput.Text;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = 
                    "-i " + '"' + inputImagePath.Text + '"' 
                    + " -o " + '"' + sfd.FileName + '"' 
                    + " -n " + denoiseValue.Text
                    + " -s " + scaleValue.Text
                    + " -m " + modelName.Text
                    + " -g " + gpuID.Text;

                if(waifu2xLocationInput.Text == "Waifu2x location not set.")
                {
                    MessageBox.Show("Waifu2x location not set!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                } 
                else
                {
                    try
                    {
                        using (Process exeProcess = Process.Start(startInfo))
                        {
                            exeProcess.WaitForExit();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                } 
            }
        }
    }
}
