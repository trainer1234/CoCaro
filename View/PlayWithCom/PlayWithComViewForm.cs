using CoCaro.DAL.Models;
using CoCaro.Model;
using CoCaro.Presenter.PlayWIthCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCaro.View.PlayWithCom
{
    public partial class PlayWithComViewForm : Form, IPlayWithComView
    {
        ChessBoard chessBoard;
        CoTheGameLevel coTheLevel;

        public PlayWithComPresenter Presenter { private get; set; }

        public PlayWithComViewForm()
        {
            InitializeComponent();
            Presenter = new PlayWithComPresenter(this, Program.DataSource);
        }

        public PlayWithComViewForm(CoTheGameLevel coTheLevel) : this()
        {
            this.coTheLevel = coTheLevel;
        }

        public void initGame()
        {
            if (this.coTheLevel == null)
            {
                initBoard();
                Presenter.ComputerMove(chessBoard);
            }
            else
            {
                //this.chessBoard = new ChessBoard(0, 
                //    this.coTheLevel.CoTheMoves);
                initBoardCoThe();
                if (this.coTheLevel.GetTurnOwner() == 1)
                {
                    Presenter.ComputerMove(chessBoard);
                }
            }
        }

        public void initBoard()
        {            
            this.Width = 2 * ChessBoard.BoardPaddingLeft +
                ChessBoard.ChessSize * ChessBoard.BoardColumns;

            this.Height = 2 * ChessBoard.BoardPaddingTop + 
                ChessBoard.ChessSize * ChessBoard.BoardRows;

            chessBoard = Presenter.CreateNewGame(false);

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

                    chessBoard.Chesses[i, j] = new Chess(j, i, 0);
                }
            }

            chessBoard.StartTime = DateTime.Now;
            timerTurn.Start();
            timerGameDuration.Start();
        }

        private void ChangeTurn()
        {
            Label lblTurn = this.Controls.Find("lblTurn", false)[0] as Label;
            ResetTimer();
            if (chessBoard.TurnOwner == 1)
            {
                chessBoard.TurnOwner = 2;
                lblTurn.Text = "Đến lượt bạn đi";
                lblTurn.ForeColor = Color.Orange;
            }
            else
            {
                chessBoard.TurnOwner = 1;
                lblTurn.Text = "Đến lượt Computer đi";
                lblTurn.ForeColor = Color.Blue;
            }
        }

        public void ComSetChess(int row, int column)
        {
            Button btnChess = Controls.Find("Chess_" +
                        row.ToString() + "_" + column.ToString(), false)[0] as Button;

            btnChess.BackgroundImage = new Bitmap(Properties.Resources.cross);

            Presenter.StoreMove(chessBoard.Id, row, column);
            int result = Presenter.CheckGame(chessBoard, row, column);
            if (result != -1)
            {
                EndGame(result, false);
            }
            else
            {
                ChangeTurn();
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
            chessBoard.IsEnd = true;

            timerTurn.Stop();
            timerGameDuration.Stop();

            Label lblTurn = this.Controls.Find("lblTurn", false)[0] as Label;
            lblTurn.Visible = false;

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
                if (chessBoard.TurnOwner == 1 || 
                    chessBoard.RemainMoves == 0)
                {
                    s = "Bạn đã thua! ";
                    if(chessBoard.RemainMoves == 0)
                    {
                        s += "(Hết lượt đi)";
                    }
                    label.ForeColor = Color.Blue;
                    label.Text = s;
                    chessBoard.Winner = 1;
                }
                else
                {
                    s = "Chúc mừng bạn đã chiến thắng!";
                    label.ForeColor = Color.Orange;
                    label.Text = s;
                    chessBoard.Winner = 2;
                }
            }

            Presenter.EndGame(chessBoard.Id, chessBoard.Winner, chessBoard.GameDuration);

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

        private void initBoardCoThe()
        {
            chessBoard = Presenter.CreateNewGame(true);
            chessBoard.RemainMoves = coTheLevel.LimitedMoves;

            this.Width = 2 * ChessBoard.BoardPaddingLeft +
                ChessBoard.ChessSize * ChessBoard.BoardColumns;

            this.Height = 2 * ChessBoard.BoardPaddingTop +
                ChessBoard.ChessSize * (ChessBoard.BoardRows + 2);            

            Label turnLabel = new Label();
            turnLabel.Name = "lblTurn";

            if(coTheLevel.GetTurnOwner() == 1)
            {
                turnLabel.Text = "Đến lượt máy đi";
            }
            else
            {
                turnLabel.Text = "Đến lượt bạn đi";
            }
            
            turnLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            turnLabel.ForeColor = Color.Blue;
            turnLabel.TextAlign = ContentAlignment.MiddleCenter;
            turnLabel.Width = this.Width;
            turnLabel.Height = 30;
            turnLabel.Location = new Point(0,
                ChessBoard.BoardPaddingTop - ChessBoard.ChessSize * 3);
            Controls.Add(turnLabel);

            Label remainMoves = new Label();
            remainMoves.Name = "lblRemainMoves";
            remainMoves.Text = "Số lượt đi còn lại: " + 
                (chessBoard.RemainMoves == -1 ? "Không giới hạn": 
                chessBoard.RemainMoves.ToString());
            remainMoves.Font = new Font("Arial", 16, FontStyle.Bold);
            remainMoves.ForeColor = Color.Blue;
            remainMoves.TextAlign = ContentAlignment.MiddleCenter;
            remainMoves.Width = this.Width;
            remainMoves.Height = 30;
            remainMoves.Location = new Point(0,
                ChessBoard.BoardPaddingTop - ChessBoard.ChessSize * 2);
            Controls.Add(remainMoves);

            Label timeLabel = new Label();
            timeLabel.Name = "lblTime";
            timeLabel.Text = ChessBoard.MoveTime.ToString();
            timeLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            timeLabel.ForeColor = Color.Green;
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            timeLabel.Width = 40;
            timeLabel.Height = 30;
            timeLabel.Location = new Point(ChessBoard.BoardPaddingLeft,
                ChessBoard.BoardPaddingTop - ChessBoard.ChessSize);
            Controls.Add(timeLabel);

            ProgressBar progressBar = new ProgressBar();
            progressBar.Name = "prgTime";
            progressBar.Location = new Point(ChessBoard.BoardPaddingLeft + timeLabel.Width,
                ChessBoard.BoardPaddingTop - ChessBoard.ChessSize);
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
                }
            }
            
            timerTurn.Start();
            timerGameDuration.Start();
            
            for(int i = 0; i < coTheLevel.Moves.Count; i++)
            {
                int turnOwner = int.Parse(coTheLevel.Moves[i].Split('_')[0]);
                string move = coTheLevel.Moves[i].Split('_')[1];
                int column = move[0] - 'A' + 1;
                int row = int.Parse(move.Substring(1));
                chessBoard.Chesses[row, column].Owner = turnOwner;
                Button chess = Controls.Find("Chess_" + row.ToString() + "_" + column.ToString(),
                            false)[0] as Button;                
                if (turnOwner == 1)
                {
                    chess.BackgroundImage = new Bitmap(Properties.Resources.cross);
                }
                else
                {
                    chess.BackgroundImage = new Bitmap(Properties.Resources.round);
                }
            }            
        }

        private void PlayWithComViewForm_Load(object sender, EventArgs e)
        {
            initGame();
        }

        private void btnChess_Click(object sender, EventArgs e)
        {
            //int row = (((Button)sender).Location.Y - ChessBoard.BoardPaddingTop) / ChessBoard.ChessSize + 1;
            //int column = (((Button)sender).Location.X - ChessBoard.BoardPaddingLeft) / ChessBoard.ChessSize + 1;

            Button clickedButton = sender as Button;
            int row = int.Parse(clickedButton.Name.Split('_')[1]);
            int column = int.Parse(clickedButton.Name.Split('_')[2]);

            if (chessBoard.Chesses[row, column].Owner != 0 || chessBoard.IsEnd)
            {
                return;
            }

            //MessageBox.Show(row.ToString() + " " + column.ToString());            

            clickedButton.BackgroundImage = new Bitmap(Properties.Resources.round);

            chessBoard.RemainMoves--;
            Label lblRemainMoves = Controls.Find("lblRemainMoves", false)[0] as Label;
            lblRemainMoves.Text = "Số lượt đi còn lại: " + chessBoard.RemainMoves;

            Presenter.StoreMove(this.chessBoard.Id, row, column);
            int result = Presenter.CheckGame(chessBoard, row, column);
            if (result != -1)
            {
                EndGame(result, false);
            }
            else
            {
                if(chessBoard.RemainMoves == 0)
                {
                    EndGame(1, false);
                    return;
                }
                ChangeTurn();
                Presenter.ComputerMove(chessBoard);                
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            initGame();
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
            chessBoard.GameDuration++;
        }
    }
}
