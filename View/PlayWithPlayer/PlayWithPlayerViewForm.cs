using CoCaro.Model;
using CoCaro.Presenter.PlayWithPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCaro.View.PlayWithPlayer
{
    internal partial class PlayWithPlayerViewForm : Form, IPlayWithPlayerView
    {
        ChessBoard _ChessBoard;

        public PlayWithPlayerPresenter Presenter { private get; set; }

        public PlayWithPlayerViewForm()
        {
            InitializeComponent();
            Presenter = new PlayWithPlayerPresenter(this, Program.DataSource);
        }

        public void initBoard()
        {
            this.Width = 2 * ChessBoard.BoardPaddingLeft +
                ChessBoard.ChessSize * ChessBoard.BoardColumns;

            this.Height = 2 * ChessBoard.BoardPaddingTop +
                ChessBoard.ChessSize * ChessBoard.BoardRows;

            _ChessBoard = Presenter.CreateNewGame();

            Label turnLabel = new Label();
            turnLabel.Name = "lblTurn";
            turnLabel.Text = "Đến lượt X đi";
            turnLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            turnLabel.ForeColor = Color.Blue;
            turnLabel.TextAlign = ContentAlignment.MiddleCenter;
            turnLabel.Width = this.Width;
            turnLabel.Height = 30;
            turnLabel.Location = new Point(0,
                ChessBoard.BoardPaddingTop - ChessBoard.ChessSize * 3);
            Controls.Add(turnLabel);

            Label timeLabel = new Label();
            timeLabel.Name = "lblTime";
            timeLabel.Text = ChessBoard.MoveTime.ToString();
            timeLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            timeLabel.ForeColor = Color.Green;
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            timeLabel.Width = 40;
            timeLabel.Height = 30;
            timeLabel.Location = new Point(ChessBoard.BoardPaddingLeft,
                ChessBoard.BoardPaddingTop - ChessBoard.ChessSize * 2);
            Controls.Add(timeLabel);

            ProgressBar progressBar = new ProgressBar();
            progressBar.Name = "prgTime";
            progressBar.Location = new Point(ChessBoard.BoardPaddingLeft + timeLabel.Width,
                ChessBoard.BoardPaddingTop - ChessBoard.ChessSize * 2);
            progressBar.Width = ChessBoard.BoardColumns * ChessBoard.ChessSize - timeLabel.Width;
            progressBar.Value = 100;
            Controls.Add(progressBar);

            for (int i = 0; i < ChessBoard.BoardRows; i++)
            {
                Label label = new Label();
                label.Text = ((char)('A' + i)).ToString();
                label.Font = new Font("Arial", 12, FontStyle.Bold);
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
                label.Font = new Font("Arial", 12, FontStyle.Bold);
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
                    button.Click += btnChess_Click;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    Controls.Add(button);

                    _ChessBoard.Chesses[i, j] = new Chess(j, i, button.Location, 0);
                }
            }

            _ChessBoard.StartTime = DateTime.Now;
            timerTurn.Start();
            timerGameDuration.Start();
        }

        private void ChangeTurn()
        {
            Label lblTurn = this.Controls.Find("lblTurn", false)[0] as Label;
            ResetTimer();
            if (_ChessBoard.TurnOwner == 1)
            {
                _ChessBoard.TurnOwner = 2;
                lblTurn.Text = "Đến lượt O đi";
                lblTurn.ForeColor = Color.Orange;
            }
            else
            {
                _ChessBoard.TurnOwner = 1;
                lblTurn.Text = "Đến lượt X đi";
                lblTurn.ForeColor = Color.Blue;
            }
        }

        private void ResetTimer()
        {
            Label lblTime = this.Controls.Find("lblTime", false)[0] as Label;
            ProgressBar prgTime = this.Controls.Find("prgTime", false)[0] as ProgressBar;

            lblTime.Text = ChessBoard.MoveTime.ToString();
            prgTime.Value = 100;
        }

        private void EndGame(int result, bool isTimeUp)
        {
            _ChessBoard.IsEnd = true;

            Label lblTurn = this.Controls.Find("lblTurn", false)[0] as Label;
            lblTurn.Visible = false;

            timerTurn.Stop();
            timerGameDuration.Stop();

            Label label = new Label();
            label.Height = 30;
            label.Width = this.Width;
            label.Location = new Point(0,
                ChessBoard.BoardRows * ChessBoard.ChessSize + ChessBoard.BoardPaddingTop);
            label.Font = new Font(new FontFamily("Arial"), 16, FontStyle.Bold);
            label.TextAlign = ContentAlignment.MiddleCenter;
            string s = "";
            if (isTimeUp)
            {
                ChangeTurn();
            }

            if (result == 0)
            {
                s = "Hòa!";
                label.ForeColor = Color.Green;
                label.Text = s;
            }
            else
            {
                if (_ChessBoard.TurnOwner == 1)
                {
                    s = "Người chơi X thắng!";
                    label.ForeColor = Color.Blue;
                    label.Text = s;
                    _ChessBoard.Winner = 1;
                }
                else
                {
                    s = "Người chơi O thắng!";
                    label.ForeColor = Color.Orange;
                    label.Text = s;
                    _ChessBoard.Winner = 2;
                }
            }

            Presenter.EndGame(_ChessBoard.Id, _ChessBoard.Winner, _ChessBoard.GameDuration);

            Controls.Add(label);

            Button newGameButton = new Button();
            newGameButton.Height = 40;
            newGameButton.Width = 90;
            newGameButton.Location = new Point(this.Width / 2 - newGameButton.Width / 2,
                label.Location.Y + ChessBoard.ChessSize);
            newGameButton.Text = "Chơi lại";
            newGameButton.Font = new Font(new FontFamily("Arial"), 12, FontStyle.Bold);
            newGameButton.Click += btnNewGame_Click;

            Controls.Add(newGameButton);

            MessageBox.Show(s);
        }

        private void PlayWithPlayerViewForm_Load(object sender, EventArgs e)
        {
            initBoard();
        }

        private void btnChess_Click(object sender, EventArgs e)
        {
            int row = (((Button)sender).Location.Y - ChessBoard.BoardPaddingTop) / ChessBoard.ChessSize + 1;
            int column = (((Button)sender).Location.X - ChessBoard.BoardPaddingLeft) / ChessBoard.ChessSize + 1;

            if (_ChessBoard.Chesses[row, column].Owner != 0 || _ChessBoard.IsEnd)
            {
                return;
            }

            //MessageBox.Show(row.ToString() + " " + column.ToString());
            _ChessBoard.Chesses[row, column].Owner = _ChessBoard.TurnOwner;

            if (_ChessBoard.TurnOwner == 1)
            {
                ((Button)sender).BackgroundImage = new Bitmap(Properties.Resources.cross);
            }
            else
            {
                ((Button)sender).BackgroundImage = new Bitmap(Properties.Resources.round);
            }

            _ChessBoard.NumberOfMove++;

            Presenter.StoreMove(this._ChessBoard.Id, row, column);
            int result = Presenter.CheckGame(_ChessBoard, row, column);
            if (result != -1)
            {
                EndGame(result, false);
            }
            else
            {
                ChangeTurn();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            initBoard();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Label label = this.Controls.Find("lblTime", false)[0] as Label;
            int time = Int16.Parse(label.Text) - 1;

            label.Text = time.ToString();

            ProgressBar progressBar = this.Controls.Find("prgTime", false)[0] as ProgressBar;
            progressBar.Value = 100 * time / ChessBoard.MoveTime;

            if (time == 0)
            {
                timerTurn.Stop();
                EndGame(1, true);
            }
            else if (time < 10)
            {
                label.ForeColor = Color.Red;
            }
        }

        private void timerGameDuration_Tick(object sender, EventArgs e)
        {
            _ChessBoard.GameDuration++;
        }
    }
}
