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

namespace PassManager
{
    public partial class Form1_Login: Form
    {
        public Form1_Login()
        {
            InitializeComponent();
            ThemeToggle.ApplyTheme(this);
            ThemeToggle.SetThemeButtonText(this.btnThemeToggle);
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
            string loginPairsDirectory = "login_pairs";
            string userFilePath = Path.Combine(loginPairsDirectory, $"{username}.txt");

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
                .Select(line => line.Split(new[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries)) //split at first two spaces
                .Where(parts => parts.Length == 3) // hashed password and salt
                .ToDictionary(parts => parts[0].ToLower(), parts => new { HashedPassword = parts[1], Salt = parts[2] });

            if (credentials.TryGetValue(username, out var storedCredentials))
            {
                // Compare the entered password with the stored hash and salt
                if (new Utils().VerifyPassword(password, storedCredentials.HashedPassword, storedCredentials.Salt))
                {
                    // DECRYPT THE USERS PASSWORDS
                    if (!File.Exists(userFilePath))
                    {
                        MessageBox.Show("No saved login pairs found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    Form3_Home form3_home = new Form3_Home(username, password);
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
       
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThemeToggle_Click_1(object sender, EventArgs e)
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
