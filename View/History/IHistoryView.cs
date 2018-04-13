using CoCaro.Model;
using CoCaro.Presenter.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.View.History
{
    public interface IHistoryView
    {
        HistoryPresenter Presenter { set; }
        void ShowRecords(List<ChessBoard> chessBoards);
    }
}
