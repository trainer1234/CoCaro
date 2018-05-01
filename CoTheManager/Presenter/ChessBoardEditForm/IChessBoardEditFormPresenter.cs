using CoCaro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTheManager.Presenter.ChessBoardEditForm
{
    interface IChessBoardEditFormPresenter
    {
        void SaveGameLevel(ChessBoard chessBoard);
        void DeleteGameLevel(int chessBoardId);
        void AddGameLevel(ChessBoard chessBoard);
    }
}
