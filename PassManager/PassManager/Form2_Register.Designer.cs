namespace PassManager
{
    partial class Form2_Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThemeToggle = new System.Windows.Forms.Button();
            this.lbl_Password_Strength = new System.Windows.Forms.Label();
            this.lbl_Password_Feedback = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "repeat password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(126, 10);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(76, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(126, 43);
            this.txtPassword1.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(76, 20);
            this.txtPassword1.TabIndex = 4;
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(126, 76);
            this.txtPassword2.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(76, 20);
            this.txtPassword2.TabIndex = 5;
            this.txtPassword2.TextChanged += new System.EventHandler(this.txtPassword2_TextChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRegister.Location = new System.Drawing.Point(287, 109);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(65, 32);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(431, 178);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 7;
            this.button1.Text = "back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnThemeToggle
            // 
            this.btnThemeToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnThemeToggle.Location = new System.Drawing.Point(387, 11);
            this.btnThemeToggle.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemeToggle.Name = "btnThemeToggle";
            this.btnThemeToggle.Size = new System.Drawing.Size(98, 23);
            this.btnThemeToggle.TabIndex = 9;
            this.btnThemeToggle.Text = "Dark Mode";
            this.btnThemeToggle.UseVisualStyleBackColor = true;
            this.btnThemeToggle.Click += new System.EventHandler(this.btnThemeToggle_Click_1);
            // 
            // lbl_Password_Strength
            // 
            this.lbl_Password_Strength.AutoSize = true;
            this.lbl_Password_Strength.Location = new System.Drawing.Point(20, 114);
            this.lbl_Password_Strength.Name = "lbl_Password_Strength";
            this.lbl_Password_Strength.Size = new System.Drawing.Size(99, 13);
            this.lbl_Password_Strength.TabIndex = 10;
            this.lbl_Password_Strength.Text = "Password Strength:";
            // 
            // lbl_Password_Feedback
            // 
            this.lbl_Password_Feedback.AutoSize = true;
            this.lbl_Password_Feedback.Location = new System.Drawing.Point(12, 146);
            this.lbl_Password_Feedback.Name = "lbl_Password_Feedback";
            this.lbl_Password_Feedback.Size = new System.Drawing.Size(107, 13);
            this.lbl_Password_Feedback.TabIndex = 11;
            this.lbl_Password_Feedback.Text = "Password Feedback:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(126, 114);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(76, 22);
            this.progressBar1.TabIndex = 14;
            // 
            // Form2_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 199);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl_Password_Feedback);
            this.Controls.Add(this.lbl_Password_Strength);
            this.Controls.Add(this.btnThemeToggle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.txtPassword1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2_Register";
            this.Text = "Form2_Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnThemeToggle;
        private System.Windows.Forms.Label lbl_Password_Strength;
        private System.Windows.Forms.Label lbl_Password_Feedback;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}