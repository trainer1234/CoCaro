using CoCaro.Model;
using CoCaro.View.ChessBoardEditForm;

namespace CoCaro.Presenter.ChessBoardEditForm
{
    public class ChessBoardEditFormPresenter : IChessBoardEditFormPresenter
    {
        private IChessBoardEditFormView view;
        private IDataSource dataSource;

        public ChessBoardEditFormPresenter(IChessBoardEditFormView view, IDataSource dataSource)
        {
            this.view = view;
            this.dataSource = dataSource;
        }
        public void AddGameLevel(CoTheGameLevel gameLevel)
        {
            dataSource.AddCoTheLevel(gameLevel);
        }

        public void DeleteGameLevel(int gameLevelId)
        {
            dataSource.DeleteCoTheLevel(gameLevelId);
        }

        public void SaveGameLevel(CoTheGameLevel gameLevel)
        {
            dataSource.SaveCoTheLevel(gameLevel);
        }
    }
}
