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
using System.Drawing.Drawing2D;

namespace PassManager
{
    public partial class Form1_Login: Form
    {
        private bool darkmode = false;
        public Form1_Login()
        {
            InitializeComponent();
            ThemeToggle.ApplyTheme(this);
        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hide();
            Form2_Register form2_register = new Form2_Register();
            form2_register.ShowDialog();
        }



            private void btnLogin_Click(object sender, EventArgs e)
        {
            string filePath = "manager_credentials.txt";
            string username = txtUsername.Text.Trim().ToLower(); //normalize input
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show("No registered users found. Please register first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //read credentials and check login
            var credentials = File.ReadAllLines(filePath)
                .Select(line => line.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries)) //split only at first space
                .Where(parts => parts.Length == 2)
                .ToDictionary(parts => parts[0].ToLower(), parts => parts[1].Trim(',')); //trim trailing comma

            if (credentials.TryGetValue(username, out string storedHashedPassword))
            {
                string enteredHashedPassword = new Utilities().HashPassword(password);
                if (enteredHashedPassword == storedHashedPassword)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    Form3_Home form3_home = new Form3_Home();
                    form3_home.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            // Light mode set as default 
            darkmode = !darkmode;

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

        private void btnToggleTheme_Click_1(object sender, EventArgs e)
        {

        }
    }
}
