using CoCaro.Model;
using CoCaro.View.History.RecordReplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Presenter.History.RecordReplay
{
    public class RecordReplayPresenter : IRecordReplayPresenter
    {
        private IRecordReplayView view;
        private IDataSource dataSource;
        public RecordReplayPresenter()
        {

        }

        public RecordReplayPresenter(IRecordReplayView view, IDataSource dataSource)
        {
            this.view = view;
            view.Presenter = this;
            this.dataSource = dataSource;
        }
       
        public void GetRecord(int id)
        {
            this.view.ShowRecord(this.dataSource.GetGameRecord(id));
        }
    }
}
