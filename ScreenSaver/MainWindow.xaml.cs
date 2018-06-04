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
        int randomKep;
        DispatcherTimer timer = new DispatcherTimer();
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            changeTimer();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            randomKep = random.Next(1, 4);
            changePicture(randomKep);
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
            randomKep = random.Next(1, 4);
            changePicture(randomKep);
        }

        private void changePicture(int index)
        {
            string res = ("tigris" + index).ToString();
            Vetites.Source = Application.Current.Resources[res] as ImageSource;
        }

        /* Ha az egér 1500 pixelnyit mozog akkor kilép a programból 
         * https://wpf.2000things.com/2012/10/17/670-getting-the-mouse-position-relative-to-a-specific-element/
         * https://www.harding.edu/fmccown/screensaver/screensaver.html */
        private Point mouseLocation = Mouse.GetPosition(null);
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
