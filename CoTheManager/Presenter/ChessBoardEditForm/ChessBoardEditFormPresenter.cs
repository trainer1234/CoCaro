using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCaro.Model;
using CoTheManager.View.ChessBoardEditForm;

namespace CoTheManager.Presenter.ChessBoardEditForm
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
        public void AddGameLevel(ChessBoard gameLevel)
        {
            dataSource.AddCoTheLevel(gameLevel);
        }

        public void DeleteGameLevel(int gameLevelId)
        {
            dataSource.DeleteCoTheLevel(gameLevelId);
        }

        public void SaveGameLevel(ChessBoard gameLevel)
        {
            dataSource.SaveCoTheLevel(gameLevel);
        }
    }
}
