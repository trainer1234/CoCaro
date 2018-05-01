using CoCaro.Model;
using CoTheManager.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoTheManager.View
{
    public interface IMainFormView
    {
        MainFormPresenter Presenter { set; }

        void ShowLevels(ChessBoard[] gameLevels);
    }
}
