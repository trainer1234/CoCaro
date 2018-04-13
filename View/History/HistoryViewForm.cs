using CoCaro.Model;
using CoCaro.Presenter.History;
using CoCaro.View.History.Record;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCaro.View.History
{
    public partial class HistoryViewForm : Form, IHistoryView
    {
        public HistoryViewForm()
        {
            InitializeComponent();
            Presenter = new HistoryPresenter(this, Program.DataSource);
        }

        public HistoryPresenter Presenter { private get; set; }

        public void ShowRecords(List<ChessBoard> chessBoards)
        {
            if(chessBoards.Count == 0)
            {
                Label label = new Label();
                label.Width = Width - 20;
                label.Height = 50;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = "Không có lịch sử!";
                label.ForeColor = Color.Blue;
                label.Font = new Font(new FontFamily("Arial"), 20, FontStyle.Bold);
                label.Location = new Point(0, Height / 2 - 100);

                Controls.Add(label);
            }
            else
            {
                for (int i = 0; i < chessBoards.Count; i++)
                {
                    RecordViewUserControl record = new RecordViewUserControl(chessBoards[i]);
                    record.Location = new Point(100, 50 + (50 + record.Height) * i);
                    Controls.Add(record);
                }
            }            
        }

        private void HistoryViewForm_Load(object sender, EventArgs e)
        {
            Presenter.GetHistory();            
        }
    }
}
