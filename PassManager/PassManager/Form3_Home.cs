using PasswordChecker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PassManager
{
    public partial class Form3_Home : Form
    {

        string username, password;
        public string DGV_Title ;

        public Form3_Home(string _username, string _password)
        {
            InitializeComponent();
            username = _username;
            password = _password;
            LoadLoginPairs(username, password);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new Form1_Login().Show();
        }
        
        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            //ensure at least one row is selected OR the password column is clicked
            if (dgvLoginPairs.SelectedRows.Count > 0 ||
                (dgvLoginPairs.CurrentCell != null && dgvLoginPairs.CurrentCell.ColumnIndex == dgvLoginPairs.Columns["maskedPassword"].Index))
            {
                DataGridViewRow selectedRow;

                //if a full row is selected, use that
                if (dgvLoginPairs.SelectedRows.Count > 0)
                {
                    selectedRow = dgvLoginPairs.SelectedRows[0];
                }
                //if the user clicked a password cell, use that row
                else if (dgvLoginPairs.CurrentCell != null)
                {
                    selectedRow = dgvLoginPairs.Rows[dgvLoginPairs.CurrentCell.RowIndex];
                }
                else
                {
                    MessageBox.Show("Please select an entry or click on a password field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //retrieve the encrypted password (assuming it's stored but not currently displayed in the DataGridView)
                string encryptedPassword = selectedRow.Cells["encryptedPassword"].Value.ToString();

                //decrypt the password
                Utils utils = new Utils();
                string decryptedPassword = utils.DecryptPassword(encryptedPassword, password);

                //show the decrypted password
                selectedRow.Cells["maskedPassword"].Value = decryptedPassword;

                //hide it again after 5 seconds for security
                Task.Delay(5000).ContinueWith(_ =>
                {
                    if (!dgvLoginPairs.IsDisposed)
                    {
                        Invoke(new Action(() =>
                        {
                            selectedRow.Cells["maskedPassword"].Value = new string('*', decryptedPassword.Length);
                        }));
                    }
                });
            }
            else
            {
                MessageBox.Show("Please select an entry or click on the password field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCopyPassword_Click(object sender, EventArgs e)
        {
            //ensure at least one row is selected OR the password column is clicked
            if (dgvLoginPairs.SelectedRows.Count > 0 ||
                (dgvLoginPairs.CurrentCell != null && dgvLoginPairs.CurrentCell.ColumnIndex == dgvLoginPairs.Columns["maskedPassword"].Index))
            {
                DataGridViewRow selectedRow;

                //if a full row is selected, use that
                if (dgvLoginPairs.SelectedRows.Count > 0)
                {
                    selectedRow = dgvLoginPairs.SelectedRows[0];
                }
                //if the user clicked a password cell, use that row
                else if (dgvLoginPairs.CurrentCell != null)
                {
                    selectedRow = dgvLoginPairs.Rows[dgvLoginPairs.CurrentCell.RowIndex];
                }
                else
                {
                    MessageBox.Show("Please select an entry or click on a password field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //retrieve the encrypted password
                string encryptedPassword = selectedRow.Cells["encryptedPassword"].Value.ToString();

                //decrypt the password
                Utils utils = new Utils();
                string decryptedPassword = utils.DecryptPassword(encryptedPassword, password);

                //copy to clipboard
                Clipboard.SetText(decryptedPassword);
                MessageBox.Show("Password copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select an entry or click on the password field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            Add addForm = new Add(this); // Pass current form as reference
            addForm.ShowDialog();
        }

        private void dgvLoginPairs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DeleteRowFromFile(string titleToDelete)
        {
            try
            {
                string filePath = Path.Combine("login_pairs", "test.txt");

                // Read all lines from the file
                var lines = File.ReadAllLines(filePath).ToList();

                // Find and remove the line that matches the title to delete
                var lineToRemove = lines.FirstOrDefault(line => line.StartsWith(titleToDelete + " "));

                if (lineToRemove != null)
                {
                    lines.Remove(lineToRemove);  // Remove the line
                    MessageBox.Show("Row deleted successfully!");
                }
                else
                {
                    MessageBox.Show("No matching row found.");
                    return;
                }

                // Write the updated list of lines back to the file
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting row: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dgvLoginPairs.SelectedRows.Count > 0)
            {
                // Get the first selected row
                DataGridViewRow selectedRow = dgvLoginPairs.SelectedRows[0];

                // Retrieve the value from a specific column (by column name or index)
                 DGV_Title = selectedRow.Cells[0].Value.ToString(); // or .Cells[0]

                // Optionally call delete logic
                // DeleteRowFromFile(value1);
                Form4 form4 = new Form4(this);
                form4.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a row to Edit.");
            }

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Make sure at least one row is selected
            if (dgvLoginPairs.SelectedRows.Count > 0)
            {
                // Get the first selected row
                DataGridViewRow selectedRow = dgvLoginPairs.SelectedRows[0];

                // Retrieve the value from a specific column (by column name or index)
                string value1 = selectedRow.Cells[0].Value.ToString(); // or .Cells[0]

                // Optionally call delete logic
                // DeleteRowFromFile(value1);
                DeleteRowFromFile(value1);
          
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }

        }

               
       /* private void SaveUpdatedData()
        {
            using (StreamWriter writer = new StreamWriter(Password_File))
            {
                foreach (DataGridViewRow row in dgvLoginPairs.Rows)
                {
                    if (!row.IsNewRow) // Ignore empty row
                    {
                        string title = row.Cells["Title"].Value?.ToString() ?? "";
                        string username = row.Cells["Username"].Value?.ToString() ?? "";
                        string password = row.Cells["maskedPassword"].Value?.ToString() ?? "";

                        writer.WriteLine($"{title},{username},{password}");
                    }
                }
            }

        }
       */
        public void AddLoginRow(string title, string username, string password)
        {
            DataTable dt = dgvLoginPairs.DataSource as DataTable;

            if (dt != null)
            {
                DataRow row = dt.NewRow();
                row["Title"] = title;
                row["Username"] = username;
                row["Password"] = password;
                dt.Rows.Add(row);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           LoadLoginPairs(username, password);
        }

        //function to load login pairs from file and bind them to dgvLoginPairs
        private void LoadLoginPairs(string username, string userPassword)
        {
            string loginPairsDirectory = "login_pairs";
            string userFilePath = Path.Combine(loginPairsDirectory, $"{username}.txt");

            if (!File.Exists(userFilePath))
            {
                MessageBox.Show("No login pairs file found for this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<LoginPairEntry> loginPairsList = new List<LoginPairEntry>();
            string[] lines = File.ReadAllLines(userFilePath);
            Utils utils = new Utils();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                //expected format: title username encryptedPassword,
                string trimmedLine = line.Trim().TrimEnd(',');
                string[] parts = trimmedLine.Split(new[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 3)
                    continue;

                string pairTitle = parts[0];
                string pairUsername = parts[1];
                string pairEncryptedPassword = parts[2];

                //decrypt the password using the user's password
                string decryptedPassword = utils.DecryptPassword(pairEncryptedPassword, userPassword);
                //mask the password with asterisks equal to the length of the decrypted password
                string maskedPassword = new string('*', decryptedPassword.Length);

                loginPairsList.Add(new LoginPairEntry
                {
                    title = pairTitle,
                    username = pairUsername,
                    maskedPassword = maskedPassword,
                    encryptedPassword = pairEncryptedPassword
                });
            }

            dgvLoginPairs.DataSource = loginPairsList;

            // .:: Styling ::.
            dgvLoginPairs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoginPairs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvLoginPairs.Columns["title"].HeaderText = "Title";
            dgvLoginPairs.Columns["username"].HeaderText = "Username / Email";
            dgvLoginPairs.Columns["maskedPassword"].HeaderText = "Password";
            dgvLoginPairs.Columns["encryptedPassword"].Visible = false;

            dgvLoginPairs.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvLoginPairs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLoginPairs.Refresh();
        }
    }
}
