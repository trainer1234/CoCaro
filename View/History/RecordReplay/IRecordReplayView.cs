using CoCaro.Model;
using CoCaro.Presenter.History.RecordReplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.View.History.RecordReplay
{
    public interface IRecordReplayView
    {
        RecordReplayPresenter Presenter { set; }
        void ShowRecord(ChessBoard chessBoard);
    }
}
