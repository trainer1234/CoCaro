using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Model
{
    class DataSource : IDataSource
    {
        private List<ChessBoard> ChessBoards;

        public DataSource()
        {
            this.ChessBoards = new List<ChessBoard>();
            //this.ChessBoards.Add(new ChessBoard {
            //    Id = 1,
            //    Moves = new List<string>
            //    {
            //        "A1", "B1","A2","B2","A3","B3","A4","B4","A5"
            //    }
            //});
            //this.ChessBoards.Add(new ChessBoard(2));
            //this.ChessBoards.Add(new ChessBoard(3));
            //this.ChessBoards.Add(new ChessBoard(4));
            //this.ChessBoards.Add(new ChessBoard(5));
            //this.ChessBoards.Add(new ChessBoard(6));
        }
        public ChessBoard CreateNewGame()
        {
            ChessBoard chessBoard = new ChessBoard(this.ChessBoards.Count);
            this.ChessBoards.Add(chessBoard);
            return chessBoard;
        }

        public ChessBoard GetGameRecord(int id)
        {
            return this.ChessBoards.SingleOrDefault(x => x.Id == id);
        }

        public List<ChessBoard> GetHistory()
        {
            List<ChessBoard> reverseList = this.ChessBoards;
            reverseList.Reverse();
            return reverseList;
        }

        public void StoreMove(int id, string move)
        {
            this.ChessBoards.Single(x => x.Id == id).Moves.Add(move);
        }
    }
}
