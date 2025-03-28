using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassManager
{
    public partial class Form3_Home: Form
    {
        // SET AT 5 SECOND TIMER FOR TESTING
        private const int sessionTimeout = 5 * 1000;
        private Timer sessionTimer;

        public Form3_Home()
        {
            InitializeComponent();
            ThemeToggle.ApplyTheme(this);

            sessionTimer = new Timer();
            sessionTimer.Interval = sessionTimeout;
            sessionTimer.Tick += SessionTimer_Tick;

            this.MouseMove += Form3_MouseMove; // Mouse Movements
            this.KeyDown += Form3_KeyDown; // Any Key pressed
        }

        private void SessionTimer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Session has timeout. Returning to login page!!");

            sessionTimer.Stop();
            this.Close();

            Form1_Login form1 = new Form1_Login();
            form1.Show();
        }
        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            sessionTimer.Stop();
            sessionTimer.Start();
        }
        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            sessionTimer.Stop();
            sessionTimer.Start();
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            // Light mode set as default 
            if (ThemeToggle.DarkMode)
            {
                ThemeToggle.DarkMode = false;
                ThemeToggle.ApplyTheme(this);
                btnToggleTheme.Text = "Dark Mode";
            }
            else
            {
                ThemeToggle.DarkMode = true;
                ThemeToggle.ApplyTheme(this);
                btnToggleTheme.Text = "Light Mode";
            }
        }
    }
}
