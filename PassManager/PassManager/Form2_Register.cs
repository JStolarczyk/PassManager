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

namespace PassManager
{
    public partial class Form2_Register: Form
    {

        public Form2_Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string filePath = "manager_credentials.txt";
            string username = txtUsername.Text.Trim().ToLower(); //trim spaces and make case-insensitive
            string password1 = txtPassword1.Text;
            string password2 = txtPassword2.Text;
            string hashedPassword;

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
            else
            {
                hashedPassword = new Utilities().HashPassword(password1);
            }

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

            //append the new credentials
            File.AppendAllText(filePath, $"{username} {hashedPassword},\n");

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //clear fields after successful registration
            txtUsername.Clear();
            txtPassword1.Clear();
            txtPassword2.Clear();

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
    }
}
