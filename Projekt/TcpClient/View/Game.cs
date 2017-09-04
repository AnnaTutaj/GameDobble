using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using TcpClientProgram.Controller;
using MetroFramework;
using MetroFramework.Forms;

namespace TcpClientProgram.View
{
    public partial class Game : MetroForm, IGameView
    {
        public Game()
        {
            InitializeComponent();

        }


        ConnectController _controller;

        #region Events raised  back to controller

        private void SendMsgButton_Click_1(object sender, EventArgs e)
        {
             this._controller.SendMessage(totextbox.Text, messagebodytextbox.Text);

        }

        private void ovalPictureBox1_Click(object sender, EventArgs e)
        {
            this._controller.ChosenPic(ovalPictureBox1.Tag);

        }
        private void ovalPictureBox2_Click(object sender, EventArgs e)
        {
            this._controller.ChosenPic(ovalPictureBox2.Tag);


        }
        private void ovalPictureBox3_Click(object sender, EventArgs e)
        {
            this._controller.ChosenPic(ovalPictureBox3.Tag);
        }


        private void ovalPictureBox4_Click(object sender, EventArgs e)
        {
            this._controller.ChosenPic(ovalPictureBox4.Tag);
        }

        private void ovalPictureBox5_Click(object sender, EventArgs e)
        {
            this._controller.ChosenPic(ovalPictureBox5.Tag);

        }


        private void ovalPictureBox6_Click(object sender, EventArgs e)
        {
            this._controller.ChosenPic(ovalPictureBox6.Tag);

        }

        private void ovalPictureBox7_Click(object sender, EventArgs e)
        {
            this._controller.ChosenPic(ovalPictureBox7.Tag);

        }

        private void ovalPictureBox8_Click(object sender, EventArgs e)
        {
            this._controller.ChosenPic(ovalPictureBox8.Tag);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._controller.PlayAgain();
        }

        #endregion

        #region ICatalogView implementation
        public void SetController(ConnectController controller)
        {
            _controller = controller;
        }
        public void NumCurrentCard(string text)
        {
            labelNumOfCardsInSet.Text = text;

        }

        public void LastNick(string message)
        {
            labelLastNick.Text = message;

        }


        public void ShowDialogs()
        {
            this.ShowDialog();
        }

        public void Hide()
        {
            this.Visible = false;
        }

        public void SetClientMessage(string msg)
        {

            if (!InvokeRequired)
            {
                listBox1.Items.Add(msg.ToString());

            }
            else
            {
                Invoke(new Action<string>(SetClientMessage), msg);
            }
        }



        public void Ban()
        {

            MainCard_GB.Enabled = false;

            //  float opacityvalue =150 / 100;
            //  ovalPictureBox1.Image = ImageUtils.ImageTransparency.ChangeOpacity(Image.FromFile(@"D:\3 sem\GameDobble\TcpClient\bin\Debug\Images\pyt.png"), 50);  //calling ChangeOpacity Function 


        }
        public void Unban()
        {
            MainCard_GB.Enabled = true;

        }
        public void Win()
        {
            MainCard_GB.Visible = false;
            YourCard_GB.Visible = false;
            //button2.Enabled = true;
        }

        public void StatusClear(string nick, string status, int a, int b)
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();

            listView1.Columns.Add(nick, a, HorizontalAlignment.Left);
            listView1.Columns.Add(status, b, HorizontalAlignment.Left);
        }
        public void StatusPlayers(string col1, string col2)
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Items.Add(new ListViewItem(new string[] { col1, col2 }));
        }

        public void AutoscrollingList()
        {
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1;
        }

        public void SetMainCard(string path, int[] tab)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ovalPictureBox1.Image = Image.FromFile(Path.Combine(dir, path + tab[0] + ".png"));
            ovalPictureBox2.Image = Image.FromFile(Path.Combine(dir, path + tab[1] + ".png"));
            ovalPictureBox3.Image = Image.FromFile(Path.Combine(dir, path + tab[2] + ".png"));
            ovalPictureBox4.Image = Image.FromFile(Path.Combine(dir, path + tab[3] + ".png"));
            ovalPictureBox5.Image = Image.FromFile(Path.Combine(dir, path + tab[4] + ".png"));
            ovalPictureBox6.Image = Image.FromFile(Path.Combine(dir, path + tab[5] + ".png"));
            ovalPictureBox7.Image = Image.FromFile(Path.Combine(dir, path + tab[6] + ".png"));
            ovalPictureBox8.Image = Image.FromFile(Path.Combine(dir, path + tab[7] + ".png"));
        }

        public void SetPlayerCard(string path, int[] tab)
        {
            ovalPictureBox9.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[0] + ".png"));
            ovalPictureBox10.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[1] + ".png"));
            ovalPictureBox11.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[2] + ".png"));
            ovalPictureBox12.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[3] + ".png"));
            ovalPictureBox13.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[4] + ".png"));
            ovalPictureBox14.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[5] + ".png"));
            ovalPictureBox15.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[6] + ".png"));
            ovalPictureBox16.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[7] + ".png"));
        }

        public void SetMainCard6(string path, int[] tab)
        {
            ovalPictureBox1.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[0] + ".png"));
            ovalPictureBox2.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[1] + ".png"));
            ovalPictureBox3.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[2] + ".png"));
            ovalPictureBox4.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[3] + ".png"));
            ovalPictureBox5.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[4] + ".png"));
            ovalPictureBox6.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[5] + ".png"));
            ovalPictureBox7.Hide();
            ovalPictureBox8.Hide();

        }

        public void SetPlayerCard6(string path, int[] tab)
        {
            ovalPictureBox9.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[0] + ".png"));
            ovalPictureBox10.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[1] + ".png"));
            ovalPictureBox11.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[2] + ".png"));
            ovalPictureBox12.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[3] + ".png"));
            ovalPictureBox13.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[4] + ".png"));
            ovalPictureBox14.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path + tab[5] + ".png"));
            ovalPictureBox15.Hide();
            ovalPictureBox16.Hide();
        }



        public void ShowInformation(string message, string title)
        {

            if (!InvokeRequired)
            {

                MetroMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Invoke(new Action<string, string>(ShowInformation), message, title);
            }


        }

        #endregion


        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void ovalPictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void labelNumOfCardsInSet_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }


}
