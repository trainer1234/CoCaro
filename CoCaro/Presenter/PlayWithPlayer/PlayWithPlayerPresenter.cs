using CoCaro.Model;
using CoCaro.View.PlayWithPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Presenter.PlayWithPlayer
{
    class PlayWithPlayerPresenter : IPlayWithPlayerPresenter
    {
        private IPlayWithPlayerView view;
        private IDataSource dataSource;

        private ChessBoard _ChessBoard;
        private Chess LastMove;
        public PlayWithPlayerPresenter(IPlayWithPlayerView view, IDataSource dataSource)
        {
            this.view = view;
            this.view.Presenter = this;
            this.dataSource = dataSource;
        }
        public int CheckGame(ChessBoard chessBoard, int row, int column)
        {
            this._ChessBoard = chessBoard;
            this.LastMove = chessBoard.Chesses[row, column];

            if(chessBoard.NumberOfMove == chessBoard.BoardRows * chessBoard.BoardColumns)
            {
                return 0;
            }
            if (CheckHorizontal() || CheckVertical() ||
                CheckInclined() || CheckReverseInclined())
            {
                return 1;
            }
            return -1;
        }

        public bool CheckHorizontal()
        {
            int count = 1;
            for (int i = 1; count < 5; i++, count++)
            {
                if(LastMove.Column + i > _ChessBoard.BoardColumns)
                {
                    break;
                }
                Chess chess = _ChessBoard.Chesses[LastMove.Row, LastMove.Column + i];
                if (chess.Owner != LastMove.Owner)
                {
                    break;
                }
            }
            if (count == 5)
            {
                return true;
            }
            else
            {
                for (int i = 1; count < 5; i++, count++)
                {
                    if(LastMove.Column - i < 1)
                    {
                        break;
                    }
                    Chess chess = _ChessBoard.Chesses[LastMove.Row, LastMove.Column - i];
                    if (chess.Owner != LastMove.Owner)
                    {
                        break;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CheckInclined()
        {
            int count = 1;
            for (int i = 1; count < 5; i++, count++)
            {
                if (LastMove.Column + i > _ChessBoard.BoardColumns ||
                    LastMove.Row + i > _ChessBoard.BoardRows)
                {
                    break;
                }
                Chess chess = _ChessBoard.Chesses[LastMove.Row + i, LastMove.Column + i];
                if (chess.Owner != LastMove.Owner)
                {
                    break;
                }
            }
            if (count == 5)
            {
                return true;
            }
            else
            {
                for (int i = 1; count < 5; i++, count++)
                {
                    if (LastMove.Column - i < 1 ||
                        LastMove.Row - i < 1)
                    {
                        break;
                    }
                    Chess chess = _ChessBoard.Chesses[LastMove.Row - i, LastMove.Column - i];
                    if (chess.Owner != LastMove.Owner)
                    {
                        break;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }            
        }

        public bool CheckReverseInclined()
        {
            int count = 1;
            for (int i = 1; count < 5; i++, count++)
            {
                if (LastMove.Column - i < 1 ||
                    LastMove.Row + i > _ChessBoard.BoardRows)
                {
                    break;
                }
                Chess chess = _ChessBoard.Chesses[LastMove.Row + i, LastMove.Column - i];
                if (chess.Owner != LastMove.Owner)
                {
                    break;
                }
            }
            if (count == 5)
            {
                return true;
            }
            else
            {
                for (int i = 1; count < 5; i++, count++)
                {
                    if (LastMove.Column + i > _ChessBoard.BoardColumns ||
                        LastMove.Row - i < 1)
                    {
                        break;
                    }
                    Chess chess = _ChessBoard.Chesses[LastMove.Row - i, LastMove.Column + i];
                    if (chess.Owner != LastMove.Owner)
                    {
                        break;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }            
        }

        public bool CheckVertical()
        {
            int count = 1;
            for (int i = 1; count < 5; i++, count++)
            {
                if (LastMove.Row + i > _ChessBoard.BoardRows)
                {
                    break;
                }
                Chess chess = _ChessBoard.Chesses[LastMove.Row + i, LastMove.Column];
                if (chess.Owner != LastMove.Owner)
                {
                    break;
                }
            }
            if (count == 5)
            {
                return true;
            }
            else
            {
                for (int i = 1; count < 5; i++, count++)
                {
                    if (LastMove.Row - i < 1)
                    {
                        break;
                    }
                    Chess chess = _ChessBoard.Chesses[LastMove.Row - i, LastMove.Column];
                    if (chess.Owner != LastMove.Owner)
                    {
                        break;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }            
        }
    }
}
