using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            findscreen(e);
        }

        private void findscreen(StartupEventArgs e)
        {
            /* https://wbsimms.com/create-screensaver-net-wpf/  
             * https://stackoverflow.com/questions/2561104/how-do-i-ensure-a-form-displays-on-the-additional-monitor-in-a-dual-monitor-sc
             */
            if (e.Args.Length == 0 || e.Args[0].ToLower().StartsWith("/s"))
            {
                foreach (Screen s in Screen.AllScreens)
                {
                    if (s == Screen.PrimaryScreen)
                    {
                        MainWindow window = new MainWindow();
                        window.Left = s.Bounds.Left;
                        window.Top = s.Bounds.Top;
                        window.Height = s.Bounds.Height;
                        window.Width = s.Bounds.Width;
                        window.Show();
                    }
                    else
                    {
                        Blackout window = new Blackout();
                        window.Left = s.Bounds.Left;
                        window.Top = s.Bounds.Top;
                        window.Height = s.Bounds.Height;
                        window.Width = s.Bounds.Width;
                        window.Show();
                    }
                }
            }
        }


    }
}
