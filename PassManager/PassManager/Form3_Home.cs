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

namespace PassManager
{
    public partial class Form3_Home : Form
    {

        string username, password;

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
            Utilities utils = new Utilities();

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
                    maskedPassword = maskedPassword
                });
            }

            dgvLoginPairs.DataSource = loginPairsList;

            // .:: Styling ::.
            dgvLoginPairs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoginPairs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvLoginPairs.Columns["title"].HeaderText = "Title";
            dgvLoginPairs.Columns["username"].HeaderText = "Username / Email";
            dgvLoginPairs.Columns["maskedPassword"].HeaderText = "Password";

            dgvLoginPairs.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvLoginPairs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLoginPairs.Refresh();
        }
    }
}
