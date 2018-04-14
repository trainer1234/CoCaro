using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoCaro.Model;
using CoCaro.Presenter.History.RecordReplay;

namespace CoCaro.View.History.RecordReplay
{
    public partial class RecordReplayViewForm : Form, IRecordReplayView
    {
        private int RecordId;
        private ChessBoard _ChessBoard;

        public RecordReplayPresenter Presenter { private get; set; }
        public RecordReplayViewForm()
        {
            Presenter = new RecordReplayPresenter(this, Program.DataSource);
            InitializeComponent();            
        }

        public RecordReplayViewForm(int id) : this()
        {
            this.RecordId = id;            
        }        

        public void ShowRecord(ChessBoard chessBoard)
        {
            this._ChessBoard = chessBoard;
            initBoard(chessBoard);
        }

        public void initBoard(ChessBoard chessBoard)
        {           
            Label turnLabel = new Label();
            turnLabel.Name = "lblTurn";
            turnLabel.Text = "Replay Game #" + (chessBoard.Id + 1);
            turnLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            turnLabel.ForeColor = Color.Blue;
            turnLabel.TextAlign = ContentAlignment.MiddleCenter;
            turnLabel.Width = 200;
            turnLabel.Height = 30;
            turnLabel.Location = new Point(300,
                ChessBoard.BoardPaddingTop - ChessBoard.ChessSize * 2);
            Controls.Add(turnLabel);

            int rightControlX = ChessBoard.BoardPaddingLeft +
                ChessBoard.BoardColumns * ChessBoard.ChessSize + ChessBoard.ChessSize * 2;

            ListBox lbMoves = new ListBox();
            lbMoves.Name = "lbMoves";
            lbMoves.Width = 100;
            lbMoves.Height = 300;
            lbMoves.Location = new Point(rightControlX,
                ChessBoard.BoardColumns / 2 * ChessBoard.ChessSize);
            lbMoves.Font = new Font(new FontFamily("Arial"), 12, FontStyle.Regular);
            for(int i = 0; i < chessBoard.Moves.Count; i++) 
            {
                lbMoves.Items.Add((i + 1).ToString() + ".      " + chessBoard.Moves[i]);
            }
            lbMoves.SelectedIndexChanged += lbMoves_SelectedIndexChanged;
            Controls.Add(lbMoves);

            Button btnPreviousMove = new Button();
            btnPreviousMove.Width = 40;
            btnPreviousMove.Height = 40;
            btnPreviousMove.BackgroundImageLayout = ImageLayout.Stretch;
            btnPreviousMove.BackgroundImage = new Bitmap(Properties.Resources.up);
            btnPreviousMove.Font = new Font("Arial", 12, FontStyle.Regular);
            btnPreviousMove.Location = new Point(rightControlX,
                ChessBoard.BoardColumns / 2 * ChessBoard.ChessSize
                + lbMoves.Height + ChessBoard.ChessSize / 2);
            btnPreviousMove.Click += btnPreviousMove_Click;
            Controls.Add(btnPreviousMove);

            Button btnNextMove = new Button();
            btnNextMove.Width = 40;
            btnNextMove.Height = 40;
            btnNextMove.BackgroundImageLayout = ImageLayout.Stretch;
            btnNextMove.BackgroundImage = new Bitmap(Properties.Resources.down);
            btnNextMove.Font = new Font("Arial", 12, FontStyle.Regular);
            btnNextMove.Location = new Point(rightControlX + btnPreviousMove.Width + 20,
                ChessBoard.BoardColumns / 2 * ChessBoard.ChessSize
                + lbMoves.Height + ChessBoard.ChessSize / 2);
            btnNextMove.Click += btnNextMove_Click;
            Controls.Add(btnNextMove);

            Button btnAutoPlay = new Button();
            btnAutoPlay.Width = 100;
            btnAutoPlay.Height = 40;
            btnAutoPlay.Text = "Tự động";
            btnAutoPlay.Font = new Font("Arial", 12, FontStyle.Regular);
            btnAutoPlay.Location = new Point(rightControlX,
                ChessBoard.BoardColumns / 2 * ChessBoard.ChessSize
                + lbMoves.Height + (ChessBoard.ChessSize / 2) * 2 + 40);
            btnAutoPlay.Click += btnAutoPlay_Click;
            Controls.Add(btnAutoPlay);

            Button btnStopAutoPlay = new Button();
            btnStopAutoPlay.Name = "btnStop";
            btnStopAutoPlay.Width = 100;
            btnStopAutoPlay.Height = 40;
            btnStopAutoPlay.Text = "Dừng";
            btnStopAutoPlay.Font = new Font("Arial", 12, FontStyle.Regular);
            btnStopAutoPlay.Location = new Point(rightControlX,
                ChessBoard.BoardColumns / 2 * ChessBoard.ChessSize
                + lbMoves.Height + (ChessBoard.ChessSize / 2) * 3 + 40 * 2);
            btnStopAutoPlay.Enabled = false;
            btnStopAutoPlay.Click += btnStop_Click;
            Controls.Add(btnStopAutoPlay);            

            for (int i = 0; i < ChessBoard.BoardRows; i++)
            {
                Label label = new Label();
                label.Text = ((char)('A' + i)).ToString();
                label.Font = new Font("Arial", 14, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Height = ChessBoard.ChessSize;
                label.Width = ChessBoard.ChessSize;
                label.Location = new Point(ChessBoard.BoardPaddingLeft + ChessBoard.ChessSize * i,
                    ChessBoard.BoardPaddingTop - ChessBoard.ChessSize);
                Controls.Add(label);
            }

            for (int i = 0; i < ChessBoard.BoardColumns; i++)
            {
                Label label = new Label();
                label.Text = (i + 1).ToString();
                label.Font = new Font("Arial", 14, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Height = ChessBoard.ChessSize;
                label.Width = ChessBoard.ChessSize;
                label.Location = new Point(ChessBoard.BoardPaddingLeft - ChessBoard.ChessSize,
                    ChessBoard.BoardPaddingTop + ChessBoard.ChessSize * i);
                Controls.Add(label);
            }

            for (int i = 1; i <= ChessBoard.BoardRows; i++)
            {
                for (int j = 1; j <= ChessBoard.BoardColumns; j++)
                {
                    Button button = new Button();
                    button.Name = "Chess_" + i.ToString() + "_" + j.ToString();
                    button.Width = ChessBoard.ChessSize;
                    button.Height = ChessBoard.ChessSize;
                    button.Location = new Point(ChessBoard.BoardPaddingLeft + ChessBoard.ChessSize * (j - 1),
                        ChessBoard.BoardPaddingTop + ChessBoard.ChessSize * (i - 1));                    
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    Controls.Add(button);

                    chessBoard.Chesses[i, j] = new Chess(j, i, button.Location, 0);
                }
            }            
        }

        private void ClearBoard()
        {
            for(int i=1;i<=ChessBoard.BoardRows; i++)
            {
                for(int j = 1; j <= ChessBoard.BoardColumns; j++)
                {
                    Button btnChess = Controls.Find("Chess_" +
                        i.ToString() + "_" + j.ToString(), false)[0] as Button;
                    btnChess.BackgroundImage = null;
                }
            }
        }

        private void goToNextMove()
        {
            ListBox lbMoves = this.Controls.Find("lbMoves", false)[0] as ListBox;
            if (lbMoves.SelectedIndex < lbMoves.Items.Count - 1)
            {
                lbMoves.SelectedIndex++;
            }
            else
            {
                string s = "";
                if(_ChessBoard.Winner == 1)
                {
                    s = "X thắng!";
                }
                else if(_ChessBoard.Winner == 2)
                {
                    s = "O thắng!";
                }
                else
                {
                    s = "Hòa";
                }

                StopAutoPlay();
                MessageBox.Show(s);                
            }
        }

        private void StopAutoPlay()
        {
            timerAutoPlay.Stop();
            timerAutoPlay.Interval = 1;
            Button btnStop = Controls.Find("btnStop", false)[0] as Button;
            btnStop.Enabled = false;
        }    
        private void RecordReplayViewForm_Load(object sender, EventArgs e)
        {
            Presenter.GetRecord(this.RecordId);
            this.Text = "Xem lại Game #" + (this.RecordId + 1);
        }

        private void btnPreviousMove_Click(object sender, EventArgs e)
        {
            ListBox lbMoves = this.Controls.Find("lbMoves", false)[0] as ListBox;
            if(lbMoves.SelectedIndex > 0)
            {
                lbMoves.SelectedIndex--;
            }
        }

        private void btnNextMove_Click(object sender, EventArgs e)
        {
            goToNextMove();
        }

        private void btnAutoPlay_Click(object sender, EventArgs e)
        {
            timerAutoPlay.Start();
            Button btnStop = Controls.Find("btnStop", false)[0] as Button;
            btnStop.Enabled = true;            
        }
        private void lbMoves_SelectedIndexChanged(object sender, EventArgs e)
        {            
            ClearBoard();
            ListBox lbMoves = sender as ListBox;
            for(int i = 0; i <= lbMoves.SelectedIndex; i++)
            {
                string move = lbMoves.Items[i].ToString().Split('.')[1].Trim();
                string column = (move[0] - 'A' + 1).ToString();
                string row = (Int16.Parse((move[1]).ToString())).ToString();
                Button btnChess = Controls.Find("Chess_" +
                        row.ToString() + "_" + column.ToString(), false)[0] as Button;

                if (i % 2 == 0)
                {
                    btnChess.BackgroundImage = new Bitmap(Properties.Resources.cross);
                }                
                else
                {
                    btnChess.BackgroundImage = new Bitmap(Properties.Resources.round);
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopAutoPlay();
        }

        private void timerAutoPlay_Tick(object sender, EventArgs e)
        {
            timerAutoPlay.Interval = 1200;
            goToNextMove();
        }
    }
}
