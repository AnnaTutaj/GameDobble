namespace TcpClientProgram.View
{
    partial class Menu
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
            this.button2 = new MetroFramework.Controls.MetroButton();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.button2.Location = new System.Drawing.Point(539, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 100);
            this.button2.TabIndex = 3;
            this.button2.Text = "Create an account";
            this.button2.UseSelectable = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.button1.Location = new System.Drawing.Point(539, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 100);
            this.button1.TabIndex = 4;
            this.button1.Text = "Sign in";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TcpClientProgram.Properties.Resources.Dabble_logo;
            this.pictureBox1.InitialImage = global::TcpClientProgram.Properties.Resources.Dabble_logo;
            this.pictureBox1.Location = new System.Drawing.Point(539, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 582);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroButton button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}