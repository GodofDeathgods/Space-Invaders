using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Space_Invaders
{


    Form1 label = new Form1();

    private TimeSpan time;

    private void timer1_Tick(object sender, EventArgs e)
    {
        time = time.Add(TimeSpan.FromSeconds(1));
        timer.Text = time.ToString(@"mm\:ss");
    }
    private void TickTimer(object sender, EventArgs e)
    {
        time = new TimeSpan(00, 00, 00);
        timer.Text = time.ToString(@"mm\:ss");
        countup.Start();
    }
}
