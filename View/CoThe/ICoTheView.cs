using CoCaro.DAL.Models;
using CoCaro.Model;
using CoCaro.Presenter.CoThe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.View.CoThe
{
    public interface ICoTheView
    {
        CoThePresenter Presenter { set; }
        void ShowLevels(CoTheGameLevel[] gameLevels);
    }
}
