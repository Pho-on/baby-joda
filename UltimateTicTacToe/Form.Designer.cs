namespace UltimateTicTacToe
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
            this.pbxPlayingBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlayingBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxPlayingBoard
            // 
            this.pbxPlayingBoard.Image = global::UltimateTicTacToe.Properties.Resources.PlayingBoard;
            this.pbxPlayingBoard.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbxPlayingBoard.InitialImage")));
            this.pbxPlayingBoard.Location = new System.Drawing.Point(-1, -1);
            this.pbxPlayingBoard.Name = "pbxPlayingBoard";
            this.pbxPlayingBoard.Size = new System.Drawing.Size(472, 472);
            this.pbxPlayingBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPlayingBoard.TabIndex = 0;
            this.pbxPlayingBoard.TabStop = false;
            this.pbxPlayingBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxPlayingBoard_MouseClick);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 470);
            this.Controls.Add(this.pbxPlayingBoard);
            this.Name = "Form";
            this.Text = "UltimateTicTacToe";
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlayingBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxPlayingBoard;
    }
}

