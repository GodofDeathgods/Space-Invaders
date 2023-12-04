using Space_Invaders.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        private TimeSpan time;

        private void countup_Tick(object sender, EventArgs e)
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
}
