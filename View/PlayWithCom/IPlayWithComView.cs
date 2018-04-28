using CoCaro.Presenter.PlayWIthCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.View.PlayWithCom
{
    public interface IPlayWithComView
    {
        PlayWithComPresenter Presenter { set; }
        void initBoard();
        void ComSetChess(int row, int column);
    }
}
