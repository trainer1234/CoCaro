using CoCaro.DAL.Context;
using CoCaro.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Model
{
    class DataSource : IDataSource
    {
        private List<ChessBoard> ChessBoards;
        private CaroContext caroContext = new CaroContext();

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
            //Game newGame = new Game
            //{
            //    StartTime = DateTime.Now
            //};
            //caroContext.Games.Add(newGame);
            //caroContext.SaveChanges();

            ChessBoard chessBoard = new ChessBoard(this.ChessBoards.Count);
            this.ChessBoards.Add(chessBoard);

            return chessBoard;
        }

        public ChessBoard GetGameRecord(int id)
        {
            //var currentGame = caroContext.Games.Include(game => game.Moves).SingleOrDefault(game => game.Id == id);

            //var chessboard = new ChessBoard
            //{
            //    Id = currentGame.Id,
            //    GameDuration = currentGame.Duration,
            //    Moves = currentGame.Moves.Select(move => move.Point).ToList(),
            //    NumberOfMove = currentGame.Moves.Count,
            //    StartTime = currentGame.StartTime,
            //    Winner = currentGame.Winner
            //};

            //return chessboard;
            return this.ChessBoards.SingleOrDefault(x => x.Id == id);
        }

        public List<ChessBoard> GetHistory()
        {
            List<ChessBoard> reverseList = this.ChessBoards;
            reverseList.Reverse();
            return reverseList;
        }

        public void EndGame(int id, int winner, int duration)
        {
            try
            {
                var currentGame = caroContext.Games.SingleOrDefault(game => game.Id == id);

                currentGame.Winner = winner;
                currentGame.Duration = duration;

                caroContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void StoreMove(int id, string move)
        {
            try
            {
                //Move newMove = new Move
                //{
                //    GameId = id,
                //    Point = move
                //};
                //caroContext.Moves.Add(newMove);
                //caroContext.SaveChanges();

                this.ChessBoards.Single(x => x.Id == id).Moves.Add(move);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
