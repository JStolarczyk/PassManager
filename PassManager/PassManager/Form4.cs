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
using PassManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PasswordChecker
{
    public partial class Form4 : Form
    {
        public Form3_Home _parentForm;
        public Form4(Form3_Home parent)
        {
            InitializeComponent();
            trackBarLength.Value = 8;
            lblLength.Text = "Password Length: " + trackBarLength.Value;
            _parentForm = parent;

            // Access the public variable from Form1
            //string Title_value = _parentForm.DGV_Title;
            
        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void trackBarLength_Scroll(object sender, EventArgs e)
        {
            lblLength.Text = "Password Length: " + trackBarLength.Value;
        }

        private string GenerateRandomPassword(int length, bool includeNumbers, bool includeCaps)
        {
            string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string symbols = "";

            string charSet = lowerChars + symbols;
            if (includeNumbers) charSet += numbers;
            if (includeCaps) charSet += capitalLetters;

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                password.Append(charSet[random.Next(charSet.Length)]);
            }

            return password.ToString();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            int length = trackBarLength.Value;
            bool includeNumbers = rbNumbersYes.Checked;
            bool includeCaps = rbCapsYes.Checked;

            txtPassword.Text = GenerateRandomPassword(length, includeNumbers, includeCaps);
        }

        public void UpdatePasswordInFile(string filePath, string title, string username, string newPassword)
        {
            try
            {
                var lines = File.ReadAllLines(filePath).ToList();

                for (int i = 0; i < lines.Count; i++)
                {
                    string[] parts = lines[i].Trim().Split(' '); // or Split('|') if you use pipe as separator

                    // Check for valid line and match by title and username
                    if (parts.Length == 3 && parts[0] == title )
                    {
                        parts[2] = newPassword; // Update only the password
                        lines[i] = string.Join(" ", parts); // Reconstruct the line
                        break; // Remove this if you want to update all matching entries
                    }
                }

                File.WriteAllLines(filePath, lines);
                MessageBox.Show("Password updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating file: " + ex.Message);
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            // Get the selected 

            // Check if password is empty
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please generate a password first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if a row is selected
          
            
                //DataGridViewRow selectedRow = _dataGridView.SelectedRows[0]; // Get the selected row

                // Update the password in the selected row
             //   selectedRow.Cells[2].Value = txtPassword.Text; // Column 1 is the password column

                // Optionally, update the timestamp (if required)
              
                // Optionally, clear the TextBox after updating
            //    txtPassword.Clear();

                // Show success message
           string loginPairsDirectory = "login_pairs";
            string userFilePath = Path.Combine(loginPairsDirectory, $"test.txt");
            string password = txtPassword.Text;
            string strtitle = _parentForm.DGV_Title;
            string username = "username5";
            UpdatePasswordInFile(userFilePath, strtitle, username, password);
            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
