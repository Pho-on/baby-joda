﻿namespace FlappyBird
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
            this.components = new System.ComponentModel.Container();
            this.pbxBird = new System.Windows.Forms.PictureBox();
            this.pbxGround = new System.Windows.Forms.PictureBox();
            this.pbxBottomPipe = new System.Windows.Forms.PictureBox();
            this.pbxTopPipe = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBottomPipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTopPipe)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxBird
            // 
            this.pbxBird.BackColor = System.Drawing.Color.Transparent;
            this.pbxBird.Image = global::FlappyBird.Properties.Resources.bird1;
            this.pbxBird.Location = new System.Drawing.Point(144, 165);
            this.pbxBird.Name = "pbxBird";
            this.pbxBird.Size = new System.Drawing.Size(75, 55);
            this.pbxBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBird.TabIndex = 1;
            this.pbxBird.TabStop = false;
            // 
            // pbxGround
            // 
            this.pbxGround.Image = global::FlappyBird.Properties.Resources.gound1;
            this.pbxGround.Location = new System.Drawing.Point(0, 449);
            this.pbxGround.Name = "pbxGround";
            this.pbxGround.Size = new System.Drawing.Size(1400, 190);
            this.pbxGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxGround.TabIndex = 2;
            this.pbxGround.TabStop = false;
            // 
            // pbxBottomPipe
            // 
            this.pbxBottomPipe.Image = global::FlappyBird.Properties.Resources.pipe;
            this.pbxBottomPipe.Location = new System.Drawing.Point(436, 315);
            this.pbxBottomPipe.Name = "pbxBottomPipe";
            this.pbxBottomPipe.Size = new System.Drawing.Size(97, 603);
            this.pbxBottomPipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBottomPipe.TabIndex = 3;
            this.pbxBottomPipe.TabStop = false;
            // 
            // pbxTopPipe
            // 
            this.pbxTopPipe.Image = global::FlappyBird.Properties.Resources.pipe;
            this.pbxTopPipe.Location = new System.Drawing.Point(436, -414);
            this.pbxTopPipe.Name = "pbxTopPipe";
            this.pbxTopPipe.Size = new System.Drawing.Size(97, 562);
            this.pbxTopPipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxTopPipe.TabIndex = 5;
            this.pbxTopPipe.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FlappyBird.Properties.Resources.background1;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.pbxTopPipe);
            this.Controls.Add(this.pbxBottomPipe);
            this.Controls.Add(this.pbxGround);
            this.Controls.Add(this.pbxBird);
            this.Name = "Form";
            this.Text = "Flappy Bird";
            ((System.ComponentModel.ISupportInitialize)(this.pbxBird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBottomPipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTopPipe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxBird;
        private System.Windows.Forms.PictureBox pbxGround;
        private System.Windows.Forms.PictureBox pbxBottomPipe;
        private System.Windows.Forms.PictureBox pbxTopPipe;
        private System.Windows.Forms.Timer gameTimer;
    }
}

