using CoCaro.Model;
using CoTheManager.Presenter.ChessBoardEditForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTheManager.View.ChessBoardEditForm
{
    public interface IChessBoardEditFormView
    {
        ChessBoardEditFormPresenter Presenter { set; }
        void initChessBoard();        
    }
}
