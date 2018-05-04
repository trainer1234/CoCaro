using CoCaro.Model;
using CoCaro.View.PlayWithPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Presenter.PlayWithPlayer
{
    public class PlayWithPlayerPresenter : IPlayWithPlayerPresenter
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

            if (chessBoard.Moves.Count == ChessBoard.BoardRows * ChessBoard.BoardColumns)
            {
                return 0;
            }
            if (CheckHorizontal() || CheckVertical(chessBoard) ||
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
                if (LastMove.Column + i > ChessBoard.BoardColumns)
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
                    if (LastMove.Column - i < 1)
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
                if (LastMove.Column + i > ChessBoard.BoardColumns ||
                    LastMove.Row + i > ChessBoard.BoardRows)
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
                    LastMove.Row + i > ChessBoard.BoardRows)
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
                    if (LastMove.Column + i > ChessBoard.BoardColumns ||
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

        public bool CheckVertical(ChessBoard chessBoard)
        {
            int count = 1;
            for (int i = 1; count < 5; i++, count++)
            {
                if (LastMove.Row + i > ChessBoard.BoardRows)
                {
                    break;
                }
                Chess chess = chessBoard.Chesses[LastMove.Row + i, LastMove.Column];
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
                    Chess chess = chessBoard.Chesses[LastMove.Row - i, LastMove.Column];
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

        public ChessBoard CreateNewGame()
        {
            _ChessBoard = dataSource.CreateNewGame(false);
            return _ChessBoard;
        }

        public void EndGame(int id, int winner, int duration)
        {
            dataSource.EndGame(id, winner, duration);
        }

        public void StoreMove(int id, int row, int column)
        {
            string move = "";
            move += _ChessBoard.TurnOwner + "_";
            move += ((char)(column - 1 + 'A')).ToString();
            move += (row).ToString();
            dataSource.StoreMove(id, move);
        }
    }
}
