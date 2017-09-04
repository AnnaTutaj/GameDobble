namespace TcpClientProgram.View
{
    partial class MenuAfterLogin
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
            this.createRoomButton = new MetroFramework.Controls.MetroButton();
            this.joinGameButton = new MetroFramework.Controls.MetroButton();
            this.rakingButton = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // createRoomButton
            // 
            this.createRoomButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.createRoomButton.Location = new System.Drawing.Point(564, 159);
            this.createRoomButton.Name = "createRoomButton";
            this.createRoomButton.Size = new System.Drawing.Size(165, 100);
            this.createRoomButton.TabIndex = 0;
            this.createRoomButton.Text = "Create a room";
            this.createRoomButton.UseSelectable = true;
            this.createRoomButton.Click += new System.EventHandler(this.createGameButton_Click);
            // 
            // joinGameButton
            // 
            this.joinGameButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.joinGameButton.Location = new System.Drawing.Point(564, 265);
            this.joinGameButton.Name = "joinGameButton";
            this.joinGameButton.Size = new System.Drawing.Size(165, 100);
            this.joinGameButton.TabIndex = 0;
            this.joinGameButton.Text = "Join a game";
            this.joinGameButton.UseSelectable = true;
            this.joinGameButton.Click += new System.EventHandler(this.joinGameButton_Click);
            // 
            // rakingButton
            // 
            this.rakingButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.rakingButton.Location = new System.Drawing.Point(564, 371);
            this.rakingButton.Name = "rakingButton";
            this.rakingButton.Size = new System.Drawing.Size(165, 100);
            this.rakingButton.TabIndex = 0;
            this.rakingButton.Text = "Ranking";
            this.rakingButton.UseSelectable = true;
            this.rakingButton.Click += new System.EventHandler(this.rakingButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TcpClientProgram.Properties.Resources.Dabble_logo;
            this.pictureBox1.Location = new System.Drawing.Point(28, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // MenuAfterLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 590);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rakingButton);
            this.Controls.Add(this.joinGameButton);
            this.Controls.Add(this.createRoomButton);
            this.Name = "MenuAfterLogin";
            this.Text = "MenuAfterLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton createRoomButton;
        private MetroFramework.Controls.MetroButton joinGameButton;
        private MetroFramework.Controls.MetroButton rakingButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}