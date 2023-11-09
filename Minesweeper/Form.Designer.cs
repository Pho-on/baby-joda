namespace Minesweeper
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.topDiv = new System.Windows.Forms.Label();
            this.cbxDifficulty = new System.Windows.Forms.ComboBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.pbxRestart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRestart)).BeginInit();
            this.SuspendLayout();
            // 
            // topDiv
            // 
            this.topDiv.BackColor = System.Drawing.Color.Gray;
            this.topDiv.Dock = System.Windows.Forms.DockStyle.Top;
            this.topDiv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.topDiv.Location = new System.Drawing.Point(0, 0);
            this.topDiv.Name = "topDiv";
            this.topDiv.Size = new System.Drawing.Size(613, 45);
            this.topDiv.TabIndex = 1;
            // 
            // cbxDifficulty
            // 
            this.cbxDifficulty.BackColor = System.Drawing.Color.Gainsboro;
            this.cbxDifficulty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxDifficulty.DisplayMember = "(none)";
            this.cbxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDifficulty.FormattingEnabled = true;
            this.cbxDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard"});
            this.cbxDifficulty.Location = new System.Drawing.Point(12, 12);
            this.cbxDifficulty.Name = "cbxDifficulty";
            this.cbxDifficulty.Size = new System.Drawing.Size(82, 21);
            this.cbxDifficulty.TabIndex = 3;
            this.cbxDifficulty.SelectedIndexChanged += new System.EventHandler(this.cbxDifficulty_SelectedIndexChanged);
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.Color.LightGray;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimer.Location = new System.Drawing.Point(519, 12);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(82, 21);
            this.lblTimer.TabIndex = 5;
            this.lblTimer.Text = "000";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxRestart
            // 
            this.pbxRestart.BackColor = System.Drawing.Color.Gray;
            this.pbxRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxRestart.Image = ((System.Drawing.Image)(resources.GetObject("pbxRestart.Image")));
            this.pbxRestart.Location = new System.Drawing.Point(275, 5);
            this.pbxRestart.Name = "pbxRestart";
            this.pbxRestart.Size = new System.Drawing.Size(35, 35);
            this.pbxRestart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxRestart.TabIndex = 6;
            this.pbxRestart.TabStop = false;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 450);
            this.Controls.Add(this.pbxRestart);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.cbxDifficulty);
            this.Controls.Add(this.topDiv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.Text = "Minesweeper";
            ((System.ComponentModel.ISupportInitialize)(this.pbxRestart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label topDiv;
        private System.Windows.Forms.ComboBox cbxDifficulty;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.PictureBox pbxRestart;
    }
}

