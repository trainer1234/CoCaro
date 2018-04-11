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

            for (int i = 0; i < _ChessBoard.BoardRows; i++)
            {                
                for(int j = 0; j < _ChessBoard.BoardColumns; j++)
                {                    
                    Button button = new Button();
                    button.Name = "OCo_" + i.ToString() + "_" + j.ToString();                    
                    button.Width = _ChessBoard.ChessSize;
                    button.Height = _ChessBoard.ChessSize;
                    button.Location = new Point(_ChessBoard.BoardPaddingLeft + _ChessBoard.ChessSize * j,
                        _ChessBoard.BoardPaddingTop + _ChessBoard.ChessSize * i);
                    button.Click += btnOCo_Click;
                    button.BackgroundImageLayout = ImageLayout.Stretch;                    
                    Controls.Add(button);

                    _ChessBoard.Chesses[i, j] = new Chess(j + 1, i + 1, button.Location, 0);
                }
            }           
        }

        private void PlayWithPlayerViewForm_Load(object sender, EventArgs e)
        {
            initBoard();            
        }

        private void btnOCo_Click(object sender, EventArgs e)
        {            
            int row = (((Button)sender).Location.Y - _ChessBoard.BoardPaddingTop) / _ChessBoard.ChessSize;
            int column = (((Button)sender).Location.X - _ChessBoard.BoardPaddingLeft) / _ChessBoard.ChessSize;

            if (_ChessBoard.Chesses[row, column].Owner != 0)
            {
                return;
            }            
            
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

            int result = Presenter.CheckGame(_ChessBoard);
            if (result == 0)
            {
                MessageBox.Show("Hòa!");
            }
            
            _ChessBoard.TurnOwner = _ChessBoard.TurnOwner == 1 ? 2 : 1;                                   
        }        
    }
}
