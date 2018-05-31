using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
/* + Reference */ 
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
/* + Reference  */  
using System.Windows.Forms;
/* Át kell írni, hogy az app működjön */
using Application = System.Windows.Application;


namespace ScreenSaver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            /* https://wbsimms.com/create-screensaver-net-wpf/  */
            if (e.Args.Length == 0 || e.Args[0].ToLower().StartsWith("/s"))
            {
                foreach (Screen s in Screen.AllScreens)
                {
                    if (s != Screen.PrimaryScreen)
                    {
                        Blackout window = new Blackout();
                        window.Show();
                    }
                    else
                    {
                        MainWindow window = new MainWindow();
                        window.Show();
                    }
                }
            }
        }
    }
}
