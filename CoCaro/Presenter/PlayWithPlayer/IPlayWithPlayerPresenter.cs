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
        int CheckGame(ChessBoard chessBoard, int row, int column);
        bool CheckVertical();
        bool CheckHorizontal();
        bool CheckInclined();
        bool CheckReverseInclined();
    }
}
