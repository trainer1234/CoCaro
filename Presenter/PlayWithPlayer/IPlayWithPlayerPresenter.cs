using CoCaro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Presenter.PlayWithPlayer
{
    public interface IPlayWithPlayerPresenter
    {
        ChessBoard CreateNewGame();
        void EndGame(int id, int winner, int duration);
        void StoreMove(int id, int row, int column);
        int CheckGame(ChessBoard chessBoard, int row, int column);
        bool CheckVertical(ChessBoard chessBoard);
        bool CheckHorizontal();
        bool CheckInclined();
        bool CheckReverseInclined();
    }
}
