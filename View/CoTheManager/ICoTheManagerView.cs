using CoCaro.Model;
using CoCaro.Presenter;
using System.Collections.Generic;

namespace CoCaro.View
{
    public interface ICoTheManagerFormView
    {
        CoTheManagerPresenter Presenter { set; }

        void ShowLevels(List<CoTheGameLevel> gameLevels);
    }
}
