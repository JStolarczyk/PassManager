namespace PassManager
{
    partial class Form3_Home
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
            this.components = new System.ComponentModel.Container();
            this.btnToggleTheme = new System.Windows.Forms.Button();
            this.inactivityTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnToggleTheme
            // 
            this.btnToggleTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleTheme.Location = new System.Drawing.Point(677, 27);
            this.btnToggleTheme.Name = "btnToggleTheme";
            this.btnToggleTheme.Size = new System.Drawing.Size(87, 23);
            this.btnToggleTheme.TabIndex = 8;
            this.btnToggleTheme.Text = "Dark Mode";
            this.btnToggleTheme.UseVisualStyleBackColor = true;
            this.btnToggleTheme.Click += new System.EventHandler(this.btnToggleTheme_Click);
            // 
            // inactivityTimer
            // 
            this.inactivityTimer.Interval = 1000;
            // 
            // Form3_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnToggleTheme);
            this.Name = "Form3_Home";
            this.Text = "Form3_Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnToggleTheme;
        private System.Windows.Forms.Timer inactivityTimer;
    }
}