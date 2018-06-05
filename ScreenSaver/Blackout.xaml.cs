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

namespace ScreenSaver
{
    /// <summary>
    /// Interaction logic for Blackout.xaml
    /// </summary>
    public partial class Blackout : Window
    {
        private Point mouseLocation = Mouse.GetPosition(null);
        public Blackout()
        {
            InitializeComponent();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point mouseLocationNew = e.GetPosition(null);

            if ((Math.Abs(mouseLocation.X - mouseLocationNew.X) > 1500) || (Math.Abs(mouseLocation.Y - mouseLocationNew.Y) > 1500))
            {
                Application.Current.Shutdown();
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
