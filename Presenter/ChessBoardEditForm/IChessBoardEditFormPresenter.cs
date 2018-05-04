using CoCaro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Presenter.ChessBoardEditForm
{
    interface IChessBoardEditFormPresenter
    {
        void SaveGameLevel(CoTheGameLevel chessBoard);
        void DeleteGameLevel(int chessBoardId);
        void AddGameLevel(CoTheGameLevel chessBoard);
    }
}
