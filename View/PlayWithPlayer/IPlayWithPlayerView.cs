using CoCaro.Presenter.PlayWithPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.View.PlayWithPlayer
{
    public interface IPlayWithPlayerView
    {
        PlayWithPlayerPresenter Presenter { set; }
        void initBoard();
    }
}
