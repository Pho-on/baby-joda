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
            this.cbxDifficulty = new System.Windows.Forms.ComboBox();
            this.topDiv = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxDifficulty
            // 
            this.cbxDifficulty.DisplayMember = "(none)";
            this.cbxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDifficulty.FormattingEnabled = true;
            this.cbxDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard"});
            this.cbxDifficulty.Location = new System.Drawing.Point(12, 12);
            this.cbxDifficulty.Name = "cbxDifficulty";
            this.cbxDifficulty.Size = new System.Drawing.Size(121, 21);
            this.cbxDifficulty.TabIndex = 0;
            this.cbxDifficulty.SelectedIndexChanged += new System.EventHandler(this.cbxDifficulty_SelectedIndexChanged);
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
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 450);
            this.Controls.Add(this.topDiv);
            this.Controls.Add(this.cbxDifficulty);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxDifficulty;
        private System.Windows.Forms.Label topDiv;
    }
}

