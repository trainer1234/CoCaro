using CoCaro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Presenter.PlayWithPlayer
{
    interface IPlayWithPlayerPresenter
    {
        int CheckGame(ChessBoard chessBoard);
        bool CheckVertical(ChessBoard chessBoard);
        bool CheckHorizontal(ChessBoard chessBoard);
        bool CheckInclined(ChessBoard chessBoard);
        bool CheckReverseInclined(ChessBoard chessBoard);
    }
}
