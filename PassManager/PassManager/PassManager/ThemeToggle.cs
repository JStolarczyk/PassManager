using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PassManager
{
    public static class ThemeToggle
    {
        public static bool DarkMode { get; set; }

        public static void ApplyTheme(Form form)
        {
            if (DarkMode)
            {
                SetDarkMode(form);
            }
            else
            {
                SetLightMode(form);
            }
        }

        private static void SetLightMode(Form form)
        {
            //Form background colour
            form.BackColor = Color.White;

            // Foreach to set all controls e.g labels, buttons, textboxes colours
            foreach (Control allControls in form.Controls)
            {
                allControls.BackColor = Color.White;
                allControls.ForeColor = Color.Black;
            }
        }

        private static void SetDarkMode(Form form)
        {
            //Form background colour
            form.BackColor = Color.Black;

            foreach (Control myControls in form.Controls)
            {
                // Can override the all controls if you want to target a certain label or textbox 
                if (myControls is System.Windows.Forms.TextBox)
                {
                    myControls.BackColor = Color.White;
                    myControls.ForeColor = Color.Black;
                }
                else if (myControls is DataGridView)
                {
                    myControls.BackColor = Color.White;
                    myControls.ForeColor = Color.Black;
                }
                else
                {
                    myControls.BackColor = Color.Black;
                    myControls.ForeColor = Color.White;
                }

            }
        }
    }
}
