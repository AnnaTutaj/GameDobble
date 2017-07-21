namespace TcpClientProgram.View
{
    partial class CreateRoom
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
            this.numberOfPlayersBT = new MetroFramework.Controls.MetroButton();
            this.comboBox4 = new MetroFramework.Controls.MetroComboBox();
            this.comboBox3 = new MetroFramework.Controls.MetroComboBox();
            this.comboBox2 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // numberOfPlayersBT
            // 
            this.numberOfPlayersBT.Location = new System.Drawing.Point(546, 368);
            this.numberOfPlayersBT.Name = "numberOfPlayersBT";
            this.numberOfPlayersBT.Size = new System.Drawing.Size(121, 33);
            this.numberOfPlayersBT.TabIndex = 26;
            this.numberOfPlayersBT.Text = "Make a new game";
            this.numberOfPlayersBT.UseSelectable = true;
            this.numberOfPlayersBT.Click += new System.EventHandler(this.numberOfPlayersBT_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.ItemHeight = 23;
            this.comboBox4.Location = new System.Drawing.Point(546, 314);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 29);
            this.comboBox4.TabIndex = 23;
            this.comboBox4.UseSelectable = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.ItemHeight = 23;
            this.comboBox3.Location = new System.Drawing.Point(546, 262);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 29);
            this.comboBox3.TabIndex = 24;
            this.comboBox3.UseSelectable = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ItemHeight = 23;
            this.comboBox2.Location = new System.Drawing.Point(546, 212);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 29);
            this.comboBox2.TabIndex = 25;
            this.comboBox2.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(438, 324);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(83, 19);
            this.metroLabel4.TabIndex = 20;
            this.metroLabel4.Text = "Game mode";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(443, 272);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(78, 19);
            this.metroLabel3.TabIndex = 21;
            this.metroLabel3.Text = "Pictographs";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(402, 222);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(119, 19);
            this.metroLabel2.TabIndex = 22;
            this.metroLabel2.Text = "Number of players";
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
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(673, 222);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(433, 19);
            this.metroLabel1.TabIndex = 22;
            this.metroLabel1.Text = "Tip: Single-player mode isn\'t a ranked game. You won\'t gain any points. ";
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 590);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numberOfPlayersBT);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel2);
            this.Name = "CreateRoom";
            this.Text = "CreateRoom";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton numberOfPlayersBT;
        private MetroFramework.Controls.MetroComboBox comboBox4;
        private MetroFramework.Controls.MetroComboBox comboBox3;
        private MetroFramework.Controls.MetroComboBox comboBox2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}