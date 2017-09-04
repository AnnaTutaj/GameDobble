using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using TcpClientProgram.Controller;
using MetroFramework.Forms;
using MetroFramework;


namespace TcpClientProgram.View
{
    public partial class CreateAnAccount : MetroForm, ICreateAnAccountView
    {
        public CreateAnAccount()
        {
            InitializeComponent();
            InitializeMyControl();

        }
        private Random rand = new Random();
        CreateAnAccountController _controller;


        #region Events raised  back to controller
        // guzyiki

        #endregion

        #region ICatalogView implementation

        public string PortTextbox
        {
            get { return this.portTextbox.Text; }
            set { this.portTextbox.Text = value; }
        }

        public string ServeripTextbox
        {
            get { return this.serveripTextbox.Text; }
            set { this.serveripTextbox.Text = value; }
        }

        public string UserNameTextbox
        {
            get { return this.userNameTextbox.Text; }
            set { this.userNameTextbox.Text = value; }
        }

        public string PasswordTextbox
        {
            get { return this.passwordTextbox.Text; }
            set { this.passwordTextbox.Text = value; }

        }
        public void SetController(CreateAnAccountController controller)
        {
            _controller = controller;
        }

        public void Hide()
        {
            Console.WriteLine("Hide");
            pictureBox1.Image.Dispose();
            code = "";
            this.Visible = false;


        }

        public void Close()
        {
            Console.WriteLine("Close");

            pictureBox1.Image.Dispose();
            code = "";
            this.Close();
        }

        public void DisposeForm()
        {
            Console.WriteLine("DisposeForm");

            pictureBox1.Image.Dispose();
            code = "";
            this.Dispose();
        }





        public void AddItemYearComboBox(int i)
        {
            yearComboBox.Items.Add(i);

        }

        public void AddItemGenderComboBox(string gender)
        {
            genderComboBox.Items.Add(gender);

        }

        public void CreateImage()
        {
            string code = GetRandomText();

            Bitmap bitmap = new Bitmap(200, 50, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Yellow);
            Rectangle rect = new Rectangle(0, 0, 200, 50);

            SolidBrush b = new SolidBrush(Color.Black);
            SolidBrush White = new SolidBrush(Color.White);

            int counter = 0;

            g.DrawRectangle(pen, rect);
            g.FillRectangle(b, rect);

            for (int i = 0; i < code.Length; i++)
            {
                g.DrawString(code[i].ToString(), new Font("Georgia", 10 + rand.Next(14, 18)), White, new PointF(10 + counter, 10));
                counter += 20;
            }

            DrawRandomLines(g);
            Random rnd = new Random();
            string path = "d:/tempimage" + rnd.Next(1, 30000) + ".bmp";
            if (File.Exists(path))
            {

                try
                {
                    File.Delete(path);
                    bitmap.Save(path);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                bitmap.Save(path);

            }

            g.Dispose();
            bitmap.Dispose();
            pictureBox1.Image = Image.FromFile(path);


        }

        #endregion
        private void DrawRandomLines(Graphics g)
        {
            SolidBrush green = new SolidBrush(Color.Green);
            //For Creating Lines on The Captcha
            for (int i = 0; i < 20; i++)
            {
                g.DrawLines(new Pen(green, 2), GetRandomPoints());
            }

        }
        private Point[] GetRandomPoints()
        {
            Point[] points = { new Point(rand.Next(10, 150), rand.Next(10, 150)), new Point(rand.Next(10, 100), rand.Next(10, 100)) };
            return points;
        }

        string code;
        private string GetRandomText()
        {
            StringBuilder randomText = new StringBuilder();

            if (String.IsNullOrEmpty(code))
            {
                string alphabets = "abcdefghijklmnopqrstuvwxyz1234567890";

                Random r = new Random();
                for (int j = 0; j <= 5; j++)
                {

                    randomText.Append(alphabets[r.Next(alphabets.Length)]);
                }

                code = randomText.ToString();
            }

            return code;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            Close();
        }

        bool checkIfCaptchaIsOK()
        {
            if (captchaTextbox.Text == code.ToString())
            {
                MetroMessageBox.Show(this, "Please wait", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            else
            {
                MetroMessageBox.Show(this, "The characters didn't match the picture. Please try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;

            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            code = "";
            CreateImage();
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (checkIfCaptchaIsOK() == true)
            {
                pictureBox1.Image.Dispose();
                code = "";
                this.Hide();

                this._controller.AddNewAccount(serveripTextbox.Text, portTextbox.Text, userNameTextbox.Text, passwordTextbox.Text, emailTextbox.Text, yearComboBox.Text, genderComboBox.Text, captchaTextbox.Text);
            }
        }

        private void captchaTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void refreshBtn_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            code = "";
            CreateImage();

        }

        public void ShowInformation(string description, string message)
        {
            MetroMessageBox.Show(Owner, message, description, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void passwordTextbox_Click(object sender, EventArgs e)
        {

        }

        private void InitializeMyControl()
        {
            // Set to no text.
            passwordTextbox.Text = "";
            // The password character is an asterisk.
            passwordTextbox.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            passwordTextbox.MaxLength = 14;
        }


    }
}
