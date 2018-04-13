using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCaro.Model;
using CoCaro.View.History;

namespace CoCaro.Presenter.History
{
    public class HistoryPresenter : IHistoryPresenter
    {
        private IHistoryView view;
        private IDataSource dataSource;

        public HistoryPresenter()
        {

        }
        public HistoryPresenter(IHistoryView view, IDataSource dataSource)
        {
            this.view = view;
            view.Presenter = this;
            this.dataSource = dataSource;
        }
        public void GetHistory()
        {
            view.ShowRecords(this.dataSource.GetHistory());            
        }
    }
}
