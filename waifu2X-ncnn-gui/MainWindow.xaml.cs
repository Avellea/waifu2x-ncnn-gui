using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Imaging;

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
        }



        private void browseButton_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();

            ofd.Title = "Select an image.";
            ofd.DefaultExt = ".png";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if(ofd.ShowDialog() == true)
            {
                inputImagePath.Text = ofd.FileName;
                beforePreview.Source = new BitmapImage(new Uri(ofd.FileName));
            }

        }

        private void scaleButton_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            if(sfd.ShowDialog() == true)
            {
                string inputPath = inputImagePath.Text;
                string outputFile = sfd.FileName;
                string denoiseVal = denoiseValue.Text;
                string scaleVal = scaleValue.Text;
                string modelVal = modelName.Text;
                string gpuVal = gpuID.Text;

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "waifu2x-ncnn-vulkan.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = "-i " + '"' + inputPath + '"' + " -o " + '"' + outputFile + '"' + " -n " + denoiseVal + " -s " + scaleVal + " -m " + modelVal + " -g " + gpuVal;

                

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
