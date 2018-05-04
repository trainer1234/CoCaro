using CoCaro.Presenter.ChessBoardEditForm;

namespace CoCaro.View.ChessBoardEditForm
{
    public interface IChessBoardEditFormView
    {
        ChessBoardEditFormPresenter Presenter { set; }
        void initChessBoard();        
    }
}
