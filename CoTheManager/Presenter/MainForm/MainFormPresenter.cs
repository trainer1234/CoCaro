using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCaro.Model;
using CoTheManager.View;

namespace CoTheManager.Presenter
{
    public class MainFormPresenter : IMainFormPresenter
    {
        private IMainFormView view;
        private IDataSource dataSource;
        public MainFormPresenter(IMainFormView view, IDataSource dataSource)
        {
            this.view = view;
            this.dataSource = dataSource;
        }
        public void LoadLevels()
        {
            view.ShowLevels(this.dataSource.GetAllCoTheGameLevels());
        }
    }
}
