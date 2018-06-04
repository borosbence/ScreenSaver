using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ScreenSaver
{
    public class Controller
    {
        int randomKep;
        DispatcherTimer timer = new DispatcherTimer();

        public void changeTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            randomKep = random.Next(1, 4);
            changePicture(randomKep);
        }

        private void changePicture(int index)
        {
            string res = ("tigris" + index).ToString();
            Vetites.Source = Application.Current.Resources[res] as ImageSource;
        }
    }
}
