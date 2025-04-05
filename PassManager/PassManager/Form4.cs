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

namespace PasswordChecker
{
    public partial class Form4 : Form
    {
       
        public Form4()
        {
            InitializeComponent();
            trackBarLength.Value = 8;
            lblLength.Text = "Password Length: " + trackBarLength.Value;
         
        }

        private DataGridView _dataGridView;
        
        public Form4(DataGridView dataGridView)
        {
            InitializeComponent();
            _dataGridView = dataGridView; // Store the passed reference
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
          
            
                DataGridViewRow selectedRow = _dataGridView.SelectedRows[0]; // Get the selected row

                // Update the password in the selected row
                selectedRow.Cells[1].Value = txtPassword.Text; // Column 1 is the password column

                // Optionally, update the timestamp (if required)
              
                // Optionally, clear the TextBox after updating
                txtPassword.Clear();

                // Show success message
                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
          
            

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
