using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpClientProgram.Controller;
using TcpClientProgram.View;
using MetroFramework.Forms;
using MetroFramework;


namespace TcpClientProgram.View
{
    public partial class Ranking : MetroForm, IRankingView
    {


        public Ranking()
        {
            InitializeComponent();
        }

        ConnectController _controller;

        #region Events raised  back to controller

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this._controller.BackToMenuFromRanking();
        }
        #endregion

        #region ICatalogView implementation
        public void SetController(ConnectController controller)
        {

            _controller = controller;
        }

        public void Hide()
        {
            this.Visible = false;

        }
        public void ShowDialogs()
        {
            this.ShowDialog();
        }


        public void RankingClear(string rank, string nick, string points, int a, int b, int c)
        {
            metroListView1.Columns.Clear();
            metroListView1.Items.Clear();

            metroListView1.Columns.Add(rank, a, HorizontalAlignment.Center);
            metroListView1.Columns.Add(nick, b, HorizontalAlignment.Center);
            metroListView1.Columns.Add(points, c, HorizontalAlignment.Center);

        }

        public void AddRowRanking(string col1, string col2, string col3)
        {

            metroListView1.View = System.Windows.Forms.View.Details;
            metroListView1.Items.Add(new ListViewItem(new string[] { col1, col2, col3 }));
        }

        public void RankingClearLower(string rank, string nick, string points, int a, int b, int c)
        {
            metroListView2.Columns.Clear();
            metroListView2.Items.Clear();

            metroListView2.Columns.Add(rank, a, HorizontalAlignment.Center);
            metroListView2.Columns.Add(nick, b, HorizontalAlignment.Center);
            metroListView2.Columns.Add(points, c, HorizontalAlignment.Center);

        }

        public void AddRowRankingLower(string col1, string col2, string col3)
        {

            metroListView2.View = System.Windows.Forms.View.Details;
            metroListView2.Items.Add(new ListViewItem(new string[] { col1, col2, col3 }));
        }



        #endregion

    }
}
