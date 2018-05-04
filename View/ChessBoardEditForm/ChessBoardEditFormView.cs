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
using CoCaro.Presenter.ChessBoardEditForm;

namespace CoCaro.View.ChessBoardEditForm
{
    public partial class ChessBoardEditFormView : Form, IChessBoardEditFormView
    {
        private CoTheGameLevel gameLevel = null;
        private int currentOperation = 1;
        private bool isAddingLevel = false;
        public ChessBoardEditFormPresenter Presenter { private get; set; }
        public ChessBoardEditFormView()
        {
            InitializeComponent();
            Presenter = new ChessBoardEditFormPresenter(this, Program.DataSource);
            
            if(gameLevel == null)
            {
                this.isAddingLevel = true;
                this.gameLevel = new CoTheGameLevel();
            }            
        }        

        public ChessBoardEditFormView(CoTheGameLevel gameLevel) : this()
        {
            this.isAddingLevel = false;
            this.gameLevel = gameLevel;
        }

        public void initChessBoard()
        {           
            int rightControlX = ChessBoard.BoardPaddingLeft +
                ChessBoard.BoardColumns * ChessBoard.ChessSize + ChessBoard.ChessSize;
            int buttonWidth = 150, buttonHeight = 50;

            Button btnSelectX = new Button();
            btnSelectX.Name = "btnSelectX";
            btnSelectX.Width = buttonWidth;
            btnSelectX.Height = buttonHeight;
            btnSelectX.Text = "Chọn X";
            btnSelectX.Font = new Font("Arial", 12, FontStyle.Bold);
            btnSelectX.ForeColor = Color.Blue;
            btnSelectX.Image = new Bitmap(Properties.Resources.blue_cross);
            btnSelectX.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectX.Location = new Point(rightControlX,
                ChessBoard.BoardPaddingTop);
            btnSelectX.Click += btnSelectXOperation_Click;
            Controls.Add(btnSelectX);

            Button btnSelectO = new Button();
            btnSelectO.Name = "btnSelectO";
            btnSelectO.Width = buttonWidth;
            btnSelectO.Height = buttonHeight;
            btnSelectO.Text = "Chọn Y";
            btnSelectO.Font = new Font("Arial", 12, FontStyle.Bold);
            btnSelectO.Image = new Bitmap(Properties.Resources.orange_circle);
            btnSelectO.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectO.Location = new Point(rightControlX,
                btnSelectX.Location.Y + btnSelectX.Height);
            btnSelectO.Click += btnSelectOOperation_Click;
            Controls.Add(btnSelectO);

            Button btnDelete = new Button();
            btnDelete.Name = "btnSelectDelete";
            btnDelete.Width = buttonWidth;
            btnDelete.Height = buttonHeight;
            btnDelete.Text = "Xóa";
            btnDelete.Font = new Font("Arial", 12, FontStyle.Bold);
            btnDelete.Image = new Bitmap(Properties.Resources.remove);
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(rightControlX,
                btnSelectO.Location.Y + btnSelectO.Height);
            btnDelete.Click += btnSelectDeleteOperation_Click;
            Controls.Add(btnDelete);

            Label lblLimitMoves = new Label();
            lblLimitMoves.Text = "Giới hạn số lượt đi";
            lblLimitMoves.Font = new Font("Arial", 12, FontStyle.Bold);
            lblLimitMoves.Width = buttonWidth;
            lblLimitMoves.Height = buttonHeight / 2;
            lblLimitMoves.Location = new Point(rightControlX,
                btnDelete.Location.Y + btnDelete.Height + ChessBoard.ChessSize);
            Controls.Add(lblLimitMoves);

            TextBox txtLimitMoves = new TextBox();
            txtLimitMoves.Name = "txtLimitedMoves";
            txtLimitMoves.Width = buttonWidth;
            txtLimitMoves.Height = buttonHeight;
            txtLimitMoves.Text = "0";
            txtLimitMoves.Font = new Font("Arial", 12, FontStyle.Bold);
            txtLimitMoves.Location = new Point(rightControlX,
                lblLimitMoves.Location.Y + lblLimitMoves.Height);
            Controls.Add(txtLimitMoves);

            this.Width = ChessBoard.BoardPaddingLeft +
                rightControlX + btnDelete.Width;
            this.Height = 2 * ChessBoard.BoardPaddingTop +
                ChessBoard.ChessSize * ChessBoard.BoardRows;

            Button btnDeleteLevel = new Button();
            btnDeleteLevel.Width = buttonWidth;
            btnDeleteLevel.Height = buttonHeight;
            btnDeleteLevel.Text = "Xóa Level";
            btnDeleteLevel.Font = new Font("Arial", 12, FontStyle.Bold);
            btnDeleteLevel.ForeColor = Color.Red;
            btnDeleteLevel.Image = new Bitmap(Properties.Resources.delete);
            btnDeleteLevel.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteLevel.Location = new Point(rightControlX,
                this.Height - ChessBoard.BoardPaddingTop - btnDeleteLevel.Height);
            btnDeleteLevel.Click += btnDeleteLevel_Click;
            Controls.Add(btnDeleteLevel);

            Button btnSaveChange = new Button();
            btnSaveChange.Width = buttonWidth;
            btnSaveChange.Height = buttonHeight;
            btnSaveChange.Text = "Lưu";
            btnSaveChange.Font = new Font("Arial", 12, FontStyle.Bold);
            btnSaveChange.Image = new Bitmap(Properties.Resources.save);
            btnSaveChange.ImageAlign = ContentAlignment.MiddleLeft;
            btnSaveChange.Location = new Point(rightControlX, 
                this.Height - ChessBoard.BoardPaddingTop - 
                btnSaveChange.Height - btnDeleteLevel.Height);
            btnSaveChange.Click += btnSaveChange_Click;
            Controls.Add(btnSaveChange);            

            Label title = new Label();
            title.Text = "Chỉnh sửa level ";
            title.Text = "Chỉnh sửa level " + gameLevel.Id.ToString();
            title.Font = new Font("Arial", 16, FontStyle.Bold);
            title.ForeColor = Color.Blue;
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Height = ChessBoard.ChessSize;
            title.Width = this.Width;
            title.Location = new Point(0, ChessBoard.BoardPaddingTop / 2 - ChessBoard.ChessSize);

            Controls.Add(title);

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
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Click += btnChess_Click;
                    Controls.Add(button);                    
                }
            }

            txtLimitMoves.Text = gameLevel.LimitedMoves.ToString();
            initMoves();
        }

        private void initMoves()
        {
            if(gameLevel.Moves != null)
            {
                foreach(var move in gameLevel.Moves)
                {                    
                    int owner = int.Parse(move.Split('_')[0]);

                    string sMove = move.Split('_')[1];
                    int column = sMove[0] - 'A' + 1;
                    int row = int.Parse(sMove.Substring(1));

                    Button btnChess = Controls.Find("Chess_" +
                        row.ToString() + "_" + column.ToString(), false)[0] as Button;
                    if (owner == 1)
                    {
                        btnChess.BackgroundImage = new Bitmap(Properties.Resources.cross);
                    }
                    else if(owner == 2)
                    {
                        btnChess.BackgroundImage = new Bitmap(Properties.Resources.round);
                    }
                }
            }
        }

        private void ChessBoardEditFormView_Load(object sender, EventArgs e)
        {
            initChessBoard();
        }

        private void btnChess_Click(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button;
            int row = int.Parse(selectedButton.Name.Split('_')[1]);
            int column = int.Parse(selectedButton.Name.Split('_')[2]);

            if(this.currentOperation == 1)
            {
                selectedButton.BackgroundImage = new Bitmap(Properties.Resources.cross);                
                String move = "";
                move += ((char)(column - 1 + 'A')).ToString();
                move += (row).ToString();
                if(!gameLevel.Moves.Contains("1_" + move))
                {
                    gameLevel.Moves.Add("1_" + move); 
                }                
                gameLevel.Moves.Remove("2_" + move);
            }
            else if (this.currentOperation == 2)
            {
                selectedButton.BackgroundImage = new Bitmap(Properties.Resources.round);                
                String move = "";
                move += ((char)(column - 1 + 'A')).ToString();
                move += (row).ToString();
                if (!gameLevel.Moves.Contains("2_" + move))
                {
                    gameLevel.Moves.Add("2_" + move);
                }
                gameLevel.Moves.Remove("1_" + move);                
            }
            else if (this.currentOperation == 0)
            {
                selectedButton.BackgroundImage = null;                
                String move = "";
                move += ((char)(column - 1 + 'A')).ToString();
                move += (row).ToString();
                gameLevel.Moves.Remove("1_" + move);
                gameLevel.Moves.Remove("2_" + move);
            }
        }

        private void btnSelectXOperation_Click(object sender, EventArgs e)
        {
            Button btnSelectX = Controls.Find("btnSelectX", false)[0] as Button;
            Button btnSelectO = Controls.Find("btnSelectO", false)[0] as Button;
            Button btnSelectDelete = Controls.Find("btnSelectDelete", false)[0] as Button;
            btnSelectX.ForeColor = Color.Blue;
            btnSelectO.ForeColor = Color.Black;
            btnSelectDelete.ForeColor = Color.Black;
            this.currentOperation = 1;            
        }

        private void btnSelectOOperation_Click(object sender, EventArgs e)
        {
            Button btnSelectX = Controls.Find("btnSelectX", false)[0] as Button;
            Button btnSelectO = Controls.Find("btnSelectO", false)[0] as Button;
            Button btnSelectDelete = Controls.Find("btnSelectDelete", false)[0] as Button;
            btnSelectX.ForeColor = Color.Black;
            btnSelectO.ForeColor = Color.Blue;
            btnSelectDelete.ForeColor = Color.Black;
            this.currentOperation = 2;
        }

        private void btnSelectDeleteOperation_Click(object sender, EventArgs e)
        {
            Button btnSelectX = Controls.Find("btnSelectX", false)[0] as Button;
            Button btnSelectO = Controls.Find("btnSelectO", false)[0] as Button;
            Button btnSelectDelete = Controls.Find("btnSelectDelete", false)[0] as Button;
            btnSelectX.ForeColor = Color.Black;
            btnSelectO.ForeColor = Color.Black;
            btnSelectDelete.ForeColor = Color.Blue;
            this.currentOperation = 0;
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            TextBox txtLimitedMoves = Controls.Find("txtLimitedMoves", false)[0] as TextBox;
            this.gameLevel.LimitedMoves = int.Parse(txtLimitedMoves.Text);

            if (this.isAddingLevel)
            {
                Presenter.AddGameLevel(this.gameLevel);
            }
            else
            {
                Presenter.SaveGameLevel(this.gameLevel);
            }            
        }

        private void btnDeleteLevel_Click(object sender, EventArgs e)
        {
            Presenter.DeleteGameLevel(this.gameLevel.Id);
        }
    }
}
