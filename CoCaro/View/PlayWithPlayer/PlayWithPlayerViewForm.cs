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
            _ChessBoard = new ChessBoard();

            Label turnLabel = new Label();
            turnLabel.Name = "lblTurn";
            turnLabel.Text = "Đến lượt X đi";
            turnLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            turnLabel.ForeColor = Color.Blue;
            turnLabel.TextAlign = ContentAlignment.MiddleCenter;
            turnLabel.Width = this.Width;
            turnLabel.Height = 30;
            turnLabel.Location = new Point(0,
                _ChessBoard.BoardPaddingTop - _ChessBoard.ChessSize * 3);
            Controls.Add(turnLabel);

            Label timeLabel = new Label();
            timeLabel.Name = "lblTime";
            timeLabel.Text = _ChessBoard.MoveTime.ToString();
            timeLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            timeLabel.ForeColor = Color.Green;
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            timeLabel.Width = 40;
            timeLabel.Height = 30;
            timeLabel.Location = new Point(_ChessBoard.BoardPaddingLeft,
                _ChessBoard.BoardPaddingTop - _ChessBoard.ChessSize * 2);
            Controls.Add(timeLabel);

            ProgressBar progressBar = new ProgressBar();
            progressBar.Name = "prgTime";
            progressBar.Location = new Point(_ChessBoard.BoardPaddingLeft + timeLabel.Width,
                _ChessBoard.BoardPaddingTop - _ChessBoard.ChessSize * 2);
            progressBar.Width = _ChessBoard.BoardColumns * _ChessBoard.ChessSize - timeLabel.Width;
            progressBar.Value = 100;
            Controls.Add(progressBar);

            for(int i = 0; i < _ChessBoard.BoardRows; i++)
            {
                Label label = new Label();
                label.Text = ((char)('A' + i)).ToString();
                label.Font = new Font("Arial", 14, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Height = _ChessBoard.ChessSize;
                label.Width = _ChessBoard.ChessSize;
                label.Location = new Point(_ChessBoard.BoardPaddingLeft + _ChessBoard.ChessSize * i,
                    _ChessBoard.BoardPaddingTop - _ChessBoard.ChessSize);
                Controls.Add(label);
            }

            for (int i = 0; i < _ChessBoard.BoardColumns; i++)
            {
                Label label = new Label();
                label.Text = (i + 1).ToString();
                label.Font = new Font("Arial", 14, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Height = _ChessBoard.ChessSize;
                label.Width = _ChessBoard.ChessSize;
                label.Location = new Point(_ChessBoard.BoardPaddingLeft - _ChessBoard.ChessSize,
                    _ChessBoard.BoardPaddingTop + _ChessBoard.ChessSize * i);
                Controls.Add(label);
            }

            for (int i = 1; i <= _ChessBoard.BoardRows; i++)
            {                
                for(int j = 1; j <= _ChessBoard.BoardColumns; j++)
                {                    
                    Button button = new Button();
                    button.Name = "OCo_" + i.ToString() + "_" + j.ToString();                    
                    button.Width = _ChessBoard.ChessSize;
                    button.Height = _ChessBoard.ChessSize;
                    button.Location = new Point(_ChessBoard.BoardPaddingLeft + _ChessBoard.ChessSize * (j - 1),
                        _ChessBoard.BoardPaddingTop + _ChessBoard.ChessSize * (i - 1));
                    button.Click += btnChess_Click;
                    button.BackgroundImageLayout = ImageLayout.Stretch;                    
                    Controls.Add(button);

                    _ChessBoard.Chesses[i, j] = new Chess(j, i, button.Location, 0);
                }
            }

            timer.Start();
        }

        private void ChangeTurn()
        {
            Label lblTurn = this.Controls.Find("lblTurn", false)[0] as Label;
            if (_ChessBoard.TurnOwner == 1)
            {
                _ChessBoard.TurnOwner = 2;
                lblTurn.Text = "Đến lượt O đi";
            }
            else
            {
                _ChessBoard.TurnOwner = 1;
                lblTurn.Text = "Đến lượt X đi";
            }
        }
        private void EndGame(bool isTimeUp)
        {
            _ChessBoard.IsEnd = true;

            Label label = new Label();
            label.Height = 30;
            label.Width = this.Width;
            label.Location = new Point(0,
                _ChessBoard.BoardRows * _ChessBoard.ChessSize + _ChessBoard.BoardPaddingTop);
            label.Font = new Font(new FontFamily("Arial"), 16, FontStyle.Bold);
            label.TextAlign = ContentAlignment.MiddleCenter;
            string s = "";
            if (isTimeUp)
            {
                ChangeTurn();
            }

            if (_ChessBoard.TurnOwner == 1)
            {
                s = "Người chơi X thắng!";
                label.ForeColor = Color.Blue;
                label.Text = s;
            }
            else
            {
                s = "Người chơi O thắng!";
                label.ForeColor = Color.Orange;
                label.Text = s;
            }
            Controls.Add(label);

            Button newGameButton = new Button();
            newGameButton.Height = 40;
            newGameButton.Width = 90;
            newGameButton.Location = new Point(this.Width / 2 - newGameButton.Width / 2,
                label.Location.Y + _ChessBoard.ChessSize);
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
            int row = (((Button)sender).Location.Y - _ChessBoard.BoardPaddingTop) / _ChessBoard.ChessSize + 1;
            int column = (((Button)sender).Location.X - _ChessBoard.BoardPaddingLeft) / _ChessBoard.ChessSize + 1;
            
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

            int result = Presenter.CheckGame(_ChessBoard, row, column);
            if (result == 0)
            {
                MessageBox.Show("Hòa!");
            }
            else if(result == 1)
            {                
                EndGame(false);
            }

            ChangeTurn();                                   
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
            progressBar.Value = 100 * time / _ChessBoard.MoveTime;

            if (time == 0)
            {
                timer.Stop();
                EndGame(true);
            }
            else if(time < 10)
            {
                label.ForeColor = Color.Red;
            }            
        }
    }    
}
