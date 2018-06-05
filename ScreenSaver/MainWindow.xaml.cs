using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ScreenSaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Random random = new Random();
        EventArgs ea = new EventArgs();
        private Point mouseLocation = Mouse.GetPosition(null);
        
        public MainWindow()
        {
            InitializeComponent();
            changeTimer();
            timer_Tick(null, ea);
        }

        /* http://www.wpf-tutorial.com/misc/dispatchertimer/ */
        private void changeTimer()
        {                   
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            randomImage();
        }

        /*   https://social.msdn.microsoft.com/Forums/vstudio/en-US/93a2b52e-f1b0-4721-b6cc-7547e3ddc4f3/how-do-i-display-a-random-out-of-3-images-image-in-an-image-control?forum=wpf  */
         private void randomImage()
         {
             string imageDirectory = System.IO.Path.GetFullPath(@"../../img/");
             string[] imagePaths = Directory.GetFiles(imageDirectory, "*.jpg");
             int index = random.Next(imagePaths.Length);

             BitmapImage bitmapImage = new BitmapImage(
                                         new Uri(imagePaths[index])
                                         );
             Vetites.Source = bitmapImage;
         }

         /* Ha az egér 1500 pixelnyit mozog akkor kilép a programból 
          * https://wpf.2000things.com/2012/10/17/670-getting-the-mouse-position-relative-to-a-specific-element/
          * https://www.harding.edu/fmccown/screensaver/screensaver.html */
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point mouseLocationNew = e.GetPosition(null);
            // Terminate if mouse is moved a significant distance
            if ((Math.Abs(mouseLocation.X - mouseLocationNew.X) > 1500) || (Math.Abs(mouseLocation.Y - mouseLocationNew.Y) > 1500))
            {
                Application.Current.Shutdown();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
