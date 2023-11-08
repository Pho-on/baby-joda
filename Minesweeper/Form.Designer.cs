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
            this.btnRestart = new System.Windows.Forms.Button();
            this.cbxDifficulty = new System.Windows.Forms.ComboBox();
            this.lblTimer = new System.Windows.Forms.Label();
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
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.BackColor = System.Drawing.Color.DimGray;
            this.btnRestart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRestart.BackgroundImage")));
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestart.ForeColor = System.Drawing.Color.Gray;
            this.btnRestart.Location = new System.Drawing.Point(272, 5);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(35, 35);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
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
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 450);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.cbxDifficulty);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.topDiv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label topDiv;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.ComboBox cbxDifficulty;
        private System.Windows.Forms.Label lblTimer;
    }
}

