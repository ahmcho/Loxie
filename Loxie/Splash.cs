using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loxie
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            InitializeComponent();
            Timer t = new Timer();
            t.Interval = 6000;
            t.Start();
            t.Tick += new EventHandler(timer1_Tick);
            t.Start();
            Opacity = 0;
            Timer timer = new Timer();
            
            timer.Tick += new EventHandler((sender, e) =>           
            {
            
            if ((Opacity += 0.005d) == 1) timer.Stop();
            
            });

            timer.Interval = 1;

            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
            
                //Form1.Show();
            }
    }
}
