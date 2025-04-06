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
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Configuration;

namespace PassManager
{
    public partial class Form2_Register: Form
    {

        public Form2_Register()
        {
            InitializeComponent();
            ThemeToggle.ApplyTheme(this);
            ThemeToggle.SetThemeButtonText(this.btnThemeToggle);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string filePath = "manager_credentials.txt";
            string loginPairsDirectory = "login_pairs";
            string username = txtUsername.Text.Trim().ToLower(); //trim spaces and make case-insensitive
            string password1 = txtPassword1.Text;
            string password2 = txtPassword2.Text;
            string hashedPassword, salt;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password1))
            {
                MessageBox.Show("Username and password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (username.Contains(" "))
            {
                MessageBox.Show("Username cannot contain spaces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password1 != password2)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //generate hashed password and salt
            hashedPassword = new Utils().HashPassword(password1, out salt);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            //read all existing usernames (case-insensitive check)
            var existingUsers = File.ReadAllLines(filePath)
                .Select(line => line.Split(' ')[0].Trim().ToLower())
                .ToHashSet();

            if (existingUsers.Contains(username))
            {
                MessageBox.Show("Username already exists. Please choose a different one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //store username, hashed password, and salt in the format "username hashedPassword salt"
            File.AppendAllText(filePath, $"{username} {hashedPassword} {salt}\n");

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //clear fields after successful registration
            txtUsername.Clear();
            txtPassword1.Clear();
            txtPassword2.Clear();


            //CREATE A `'username.txt' FOR THE USER THAT WILL HOLD THE LOGIN PAIRS
            //create the login_pairs directory if it doesn't exist
            if (!Directory.Exists(loginPairsDirectory))
            {
                Directory.CreateDirectory(loginPairsDirectory);
            }

            //create a file for the user inside login_pairs folder
            string userFilePath = Path.Combine(loginPairsDirectory, $"{username}.txt");
            File.Create(userFilePath).Close();


            // .::ONLY FOR TEST!!!::.
            string mockPlainText = "test";
            string encryptedTest = new Utils().EncryptPassword(mockPlainText, password1);
            string mockEntry = $"test_title test_username {encryptedTest},\n";
            File.AppendAllText(userFilePath, mockEntry);


            Hide();
            Form1_Login form1_login = new Form1_Login();
            form1_login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1_Login form1_login = new Form1_Login();
            form1_login.ShowDialog();
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
                btnRegister.BackColor = Color.LightGray;
                btnRegister.ForeColor = Color.Black;
            }
            ThemeToggle.SetThemeButtonText(btnThemeToggle);
        }

        private void txtPassword2_TextChanged(object sender, EventArgs e)
        {
            // Sets the password to read the txt in password textbox 1 
            string password = txtPassword1.Text;
            // This will be the indicator of what strength score you get 
            int score = 0;

            List<string> feedback = new List<string>();

            // Set for length of 5 set it to whatever you want i just didnt want to write long passwords when testing
            if (password.Length >= 5)
            {
                score++;
            }
            else
            {
               feedback.Add("Password must be atleast 5 characters");
            }

            if (Regex.IsMatch(password, @"[A-Z]"))
            {
                score++;
            }
            else
            {
                feedback.Add("Add Uppercase Letters");
            }

            if (Regex.IsMatch(password, @"\d"))
            {
                score++;
            }
            else
            {
                feedback.Add("Add a Number");
            }

            if (Regex.IsMatch(password, @"[\W]"))
            {
                score++;
            }
            else
            {
                feedback.Add("Add Special Characters");
            }

            switch (score)
            {
                case 0:
                case 1:
                    lbl_Password_Strength.Text = "Weak";
                    lbl_Password_Strength.ForeColor = Color.Red;
                    progressBar1.Value = 25;
                    break;

                case 2:
                    lbl_Password_Strength.Text = "Medium";
                    lbl_Password_Strength.ForeColor = Color.Orange;
                    progressBar1.Value = 50;
                    break;

                case 3:
                    lbl_Password_Strength.Text = "Strong";
                    lbl_Password_Strength.ForeColor = Color.LightGreen;
                    progressBar1.Value = 75;
                    break;

                case 4:
                    lbl_Password_Strength.Text = "Very Strong";
                    lbl_Password_Strength.ForeColor = Color.DarkGreen;
                    progressBar1.Value = 100;
                    break;

                default:
                    lbl_Password_Strength.Text = " ";
                    lbl_Password_Strength.ForeColor = Color.White;
                    progressBar1.Value = 0;
                    break;
            }

            if (score < 3)
            {
                btnRegister.Enabled = false;
                btnRegister.BackColor = Color.LightGray;
                btnRegister.ForeColor = Color.Black;
            }
            else
            {
                btnRegister.Enabled = true;
            }

            lbl_Password_Feedback.Text = string.Join(Environment.NewLine, feedback);
        }

    }
}
