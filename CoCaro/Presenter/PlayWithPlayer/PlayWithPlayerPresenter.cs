using CoCaro.Model;
using CoCaro.View.PlayWithPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Presenter.PlayWithPlayer
{
    class PlayWithPlayerPresenter : IPlayWithPlayerPresenter
    {
        private IPlayWithPlayerView view;
        private IDataSource dataSource;
        public PlayWithPlayerPresenter(PlayWithPlayerViewForm view, DataSource dataSource)
        {
            this.view = view;
            this.view.Presenter = this;
            this.dataSource = dataSource;
        }
        public int CheckGame(ChessBoard chessBoard)
        {            
            if(chessBoard.NumberOfMove == chessBoard.BoardRows * chessBoard.BoardColumns)
            {
                return 0;
            }
            //if(CheckHorizontal(chessBoard) || CheckVertical(chessBoard) ||
            //    CheckInclined(chessBoard) || CheckReverseInclined(chessBoard))
            //{
            //    return 1;
            //}
            return -1;
        }

        public bool CheckHorizontal(ChessBoard chessBoard)
        {
            throw new NotImplementedException();
        }

        public bool CheckInclined(ChessBoard chessBoard)
        {
            throw new NotImplementedException();
        }

        public bool CheckReverseInclined(ChessBoard chessBoard)
        {
            throw new NotImplementedException();
        }

        public bool CheckVertical(ChessBoard chessBoard)
        {
            throw new NotImplementedException();
        }
    }
}
