using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PassManager
{
    public partial class Add : Form
    {
        private Form3_Home parentForm;
        public Add(Form3_Home form)
        {
            InitializeComponent();
            parentForm = form; // Store the passed reference


            ThemeToggle.ApplyTheme(this);
            ThemeToggle.SetThemeButtonText(btnThemeToggle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string line = $"\n{title} {username} {password}";
            // Use '|' as separator

            try
            {
                string loginPairsDirectory = "login_pairs";
                string userFilePath = Path.Combine(loginPairsDirectory, $"test.txt");
                File.AppendAllText(userFilePath, line);
                MessageBox.Show("Saved successfully!");

                this.Close(); // Optional
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file: " + ex.Message);
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void btnThemeToggle_Click(object sender, EventArgs e)
        {
            if (ThemeToggle.DarkMode)
            {
                ThemeToggle.DarkMode = false;
                ThemeToggle.ApplyTheme(this);
            }
            else
            {
                ThemeToggle.DarkMode = true;
                ThemeToggle.ApplyTheme(this);
            }

            ThemeToggle.SetThemeButtonText(btnThemeToggle);
        }
    }
}
