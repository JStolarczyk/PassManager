namespace PasswordChecker
{
    partial class Form4
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
            this.lblLength = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbCapsNo = new System.Windows.Forms.RadioButton();
            this.rbCapsYes = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNumbersNo = new System.Windows.Forms.RadioButton();
            this.rbNumbersYes = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.trackBarLength = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btnThemeToggle = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLength)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(8, 62);
            this.lblLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(92, 13);
            this.lblLength.TabIndex = 0;
            this.lblLength.Text = "Password Lenght:";
            this.lblLength.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbCapsNo);
            this.groupBox2.Controls.Add(this.rbCapsYes);
            this.groupBox2.Location = new System.Drawing.Point(11, 184);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(133, 65);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Include Capitals:";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // rbCapsNo
            // 
            this.rbCapsNo.AutoSize = true;
            this.rbCapsNo.Location = new System.Drawing.Point(9, 37);
            this.rbCapsNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCapsNo.Name = "rbCapsNo";
            this.rbCapsNo.Size = new System.Drawing.Size(39, 17);
            this.rbCapsNo.TabIndex = 1;
            this.rbCapsNo.TabStop = true;
            this.rbCapsNo.Text = "No";
            this.rbCapsNo.UseVisualStyleBackColor = true;
            // 
            // rbCapsYes
            // 
            this.rbCapsYes.AutoSize = true;
            this.rbCapsYes.Location = new System.Drawing.Point(9, 17);
            this.rbCapsYes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCapsYes.Name = "rbCapsYes";
            this.rbCapsYes.Size = new System.Drawing.Size(43, 17);
            this.rbCapsYes.TabIndex = 0;
            this.rbCapsYes.TabStop = true;
            this.rbCapsYes.Text = "Yes";
            this.rbCapsYes.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNumbersNo);
            this.groupBox1.Controls.Add(this.rbNumbersYes);
            this.groupBox1.Location = new System.Drawing.Point(11, 105);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(133, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Include Numbers:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbNumbersNo
            // 
            this.rbNumbersNo.AutoSize = true;
            this.rbNumbersNo.Location = new System.Drawing.Point(12, 37);
            this.rbNumbersNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbNumbersNo.Name = "rbNumbersNo";
            this.rbNumbersNo.Size = new System.Drawing.Size(39, 17);
            this.rbNumbersNo.TabIndex = 1;
            this.rbNumbersNo.TabStop = true;
            this.rbNumbersNo.Text = "No";
            this.rbNumbersNo.UseVisualStyleBackColor = true;
            // 
            // rbNumbersYes
            // 
            this.rbNumbersYes.AutoSize = true;
            this.rbNumbersYes.Location = new System.Drawing.Point(12, 17);
            this.rbNumbersYes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbNumbersYes.Name = "rbNumbersYes";
            this.rbNumbersYes.Size = new System.Drawing.Size(43, 17);
            this.rbNumbersYes.TabIndex = 0;
            this.rbNumbersYes.TabStop = true;
            this.rbNumbersYes.Text = "Yes";
            this.rbNumbersYes.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Generate Random Password";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(44, 32);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(94, 34);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate Password";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(31, 124);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 25);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(9, 84);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(176, 23);
            this.txtPassword.TabIndex = 7;
            // 
            // trackBarLength
            // 
            this.trackBarLength.Location = new System.Drawing.Point(114, 51);
            this.trackBarLength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBarLength.Maximum = 25;
            this.trackBarLength.Name = "trackBarLength";
            this.trackBarLength.Size = new System.Drawing.Size(69, 45);
            this.trackBarLength.TabIndex = 8;
            this.trackBarLength.Scroll += new System.EventHandler(this.trackBarLength_Scroll);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(254, 51);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 207);
            this.panel1.TabIndex = 9;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(113, 122);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(50, 27);
            this.btn_Close.TabIndex = 10;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btnThemeToggle
            // 
            this.btnThemeToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnThemeToggle.Location = new System.Drawing.Point(424, 11);
            this.btnThemeToggle.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemeToggle.Name = "btnThemeToggle";
            this.btnThemeToggle.Size = new System.Drawing.Size(98, 23);
            this.btnThemeToggle.TabIndex = 11;
            this.btnThemeToggle.Text = "Dark Mode";
            this.btnThemeToggle.UseVisualStyleBackColor = true;
            this.btnThemeToggle.Click += new System.EventHandler(this.btnThemeToggle_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.btnThemeToggle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBarLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblLength);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLength)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbCapsNo;
        private System.Windows.Forms.RadioButton rbCapsYes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNumbersNo;
        private System.Windows.Forms.RadioButton rbNumbersYes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TrackBar trackBarLength;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btnThemeToggle;
    }
}