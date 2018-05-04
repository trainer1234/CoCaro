using CoCaro.Model;
using CoCaro.View;

namespace CoCaro.Presenter
{
    public class CoTheManagerPresenter : ICoTheManagerPresenter
    {
        private ICoTheManagerFormView view;
        private IDataSource dataSource;

        public CoTheManagerPresenter(ICoTheManagerFormView view, IDataSource dataSource)
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
