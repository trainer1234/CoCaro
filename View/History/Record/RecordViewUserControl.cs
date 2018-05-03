using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoCaro.Model;
using CoCaro.View.History.RecordReplay;

namespace CoCaro.View.History.Record
{
    public partial class RecordViewUserControl : UserControl
    {        
        private ChessBoard _ChessBoard;
        public RecordViewUserControl()
        {
            InitializeComponent();
        }

        public RecordViewUserControl(ChessBoard chessBoard)
        {            
            this._ChessBoard = chessBoard;
            InitializeComponent();
        }

        private void RecordViewUserControl_Load(object sender, EventArgs e)
        {
            lblId.Text = "#" + (this._ChessBoard.Id).ToString();
            lblDuration.Text = this._ChessBoard.GameDuration.ToString() + "s";
            lblStartTime.Text = this._ChessBoard.StartTime.ToLongTimeString();
            if(this._ChessBoard.Winner == 1)
            {
                lblResult.Text = "X thắng";
                lblResult.ForeColor = Color.Blue;
            }
            else if(this._ChessBoard.Winner == 2)
            {
                lblResult.Text = "O thắng";
                lblResult.ForeColor = Color.Orange;
            }
            else
            {
                lblResult.Text = "Hòa";
                lblResult.ForeColor = Color.Green;
            }
        }

        private void IRecordViewUserControl_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.AliceBlue;
        }

        private void IRecordViewUserControl_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void IRecordViewUserControl_MouseDown(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(255, 224, 240, 255);      
        }

        private void IRecordViewUserControl_MouseUp(object sender, MouseEventArgs e)
        {
            BackColor = Color.White;
        }

        private void RecordViewUserControl_Click(object sender, EventArgs e)
        {
            RecordReplayViewForm form = new RecordReplayViewForm(_ChessBoard.Id);
            form.Show();
        }
    }
}
