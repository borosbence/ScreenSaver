using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
/* + Reference  */  
using System.Windows.Forms;
/* Rename reference*/
using Application = System.Windows.Application;


namespace ScreenSaver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        /* https://wbsimms.com/create-screensaver-net-wpf/  
             * https://stackoverflow.com/questions/2561104/how-do-i-ensure-a-form-displays-on-the-additional-monitor-in-a-dual-monitor-sc
             */

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 0 || e.Args[0].ToLower().StartsWith("/s"))
            {
                foreach (Screen s in Screen.AllScreens)
                {
                    if (s == Screen.PrimaryScreen)
                    {
                        MainWindow window = new MainWindow();
                        window.Left = s.WorkingArea.Left;
                        window.Top = s.WorkingArea.Top;
                        window.Height = s.WorkingArea.Height;
                        window.Width = s.WorkingArea.Width;
                        window.Show();
                    }
                    else
                    {
                        Blackout window = new Blackout();
                        window.Left = s.WorkingArea.Left;
                        window.Top = s.WorkingArea.Top;
                        window.Height = s.WorkingArea.Height;
                        window.Width = s.WorkingArea.Width;
                        window.Show();
                    }
                }
            }
            // If you want to configurate, or preview mode
            //else if (e.Args[0].ToLower().StartsWith("/c"))
            //else if (e.Args[0].ToLower().StartsWith("/p"))
        }
    }
}
