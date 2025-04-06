using System;
using System.Drawing;
using System.Windows.Forms;

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
        // Sets the button text depending on what theme your on 
        public static void SetThemeButtonText(Button btnToggleTheme)
        {
            if (DarkMode)
            {
                btnToggleTheme.Text = "Light Mode";
            }
            else
            {
                btnToggleTheme.Text = "Dark Mode";
            }
        }

        private static void SetLightMode(Form form)
        {
            form.BackColor = Color.White;

            // Goes through all the controls in the form (Containers like panel and DGV are not set with form.Control)
            foreach (Control control in form.Controls)
            {
                // DGV is a container so must specify that you are trying to set the color
                if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.LightGray;
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.Black;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    dgv.EnableHeadersVisualStyles = false;
                }
                // This will go through the controls of the panel container and set the color 
                else if (control is Panel)
                {
                    Panel panel = control as Panel;

                    panel.BackColor = Color.White;

                    foreach (Control buttonControl in panel.Controls)
                    {
                        if (buttonControl is Button button)
                        {
                            button.BackColor = Color.White;
                            button.ForeColor = Color.Black;
                        }
                    }
                }
                // Everything else is set to this color scheme 
                else
                {
                    control.BackColor = Color.White;
                    control.ForeColor = Color.Black;
                }
            }
        }

        private static void SetDarkMode(Form form)
        {
            form.BackColor = Color.Black;

            // Goes through all the controls in the form (Containers like panel and DGV are not set with form.Control)
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    control.BackColor = Color.White;
                    control.ForeColor = Color.Black;
                }
                // DGV is a container so must specify that you are trying to set the color
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.LightGray;
                    dgv.DefaultCellStyle.BackColor = Color.Black;
                    dgv.DefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    dgv.EnableHeadersVisualStyles = false;
                }
                // This will go through the controls of the panel container and set the color 
                else if (control is Panel)
                {
                    Panel panel = control as Panel;

                    panel.BackColor = Color.LightGray;

                    foreach (Control buttonControl in panel.Controls)
                    {
                        if (buttonControl is Button button)
                        {
                            button.BackColor = Color.Black;
                            button.ForeColor = Color.White;
                        }

                    }
                }
                // Everything else is set to this color scheme 
                else
                {
                    control.BackColor = Color.Black;
                    control.ForeColor = Color.White;
                }
            }
        }
    }
}
