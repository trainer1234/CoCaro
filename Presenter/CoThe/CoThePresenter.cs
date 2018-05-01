using CoCaro.Model;
using CoCaro.View.CoThe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Presenter.CoThe
{
    public class CoThePresenter : ICoThePresenter
    {
        private ICoTheView view;
        private IDataSource dataSource;

        public CoThePresenter(ICoTheView view, IDataSource dataSource)
        {
            this.view = view;
            this.dataSource = dataSource;
        }
        public void LoadLevels()
        {
            this.view.ShowLevels(this.dataSource.GetAllCoTheGameLevels());
        }
    }
}
