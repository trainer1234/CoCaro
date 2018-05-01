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
    public class DataSource : IDataSource
    {
        private CaroContext caroContext;
        private List<ChessBoard> ChessBoards;

        public DataSource(CaroContext caroContext)
        {
            ChessBoards = new List<ChessBoard>();
            this.caroContext = caroContext;
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
            Game newGame = new Game
            {
                StartTime = DateTime.Now
            };
            caroContext.Games.Add(newGame);
            caroContext.SaveChanges();

            ChessBoard chessBoard = new ChessBoard(newGame.Id);

            //ChessBoard chessBoard = new ChessBoard(this.ChessBoards.Count);
            //this.ChessBoards.Add(chessBoard);
            return chessBoard;
        }

        public ChessBoard GetGameRecord(int id)
        {
            var games = caroContext.Games.Include(game => game.Moves);

            ChessBoard chessboard = null;
            if (games != null)
            {
                var currentGame = games.SingleOrDefault(game => game.Id == id);
                chessboard = new ChessBoard
                {
                    Id = currentGame.Id,
                    GameDuration = currentGame.Duration,
                    Moves = currentGame.Moves.Select(move => move.Point).ToList(),                    
                    StartTime = currentGame.StartTime,
                    Winner = currentGame.Winner
                };

            }

            return chessboard;
            //return this.ChessBoards.SingleOrDefault(x => x.Id == id);
        }

        public List<ChessBoard> GetHistory()
        {
            var chessboards = new List<ChessBoard>();

            var games = caroContext.Games.Include(game => game.Moves);
            if (games != null)
            {
                games = games.OrderByDescending(game => game.StartTime);
                foreach (var match in games)
                {
                    var chessboard = new ChessBoard
                    {
                        Id = match.Id,
                        IsEnd = true,
                        GameDuration = match.Duration,
                        StartTime = match.StartTime,                        
                        Moves = match.Moves.Select(move => move.Point).ToList(),
                        Winner = match.Winner
                    };
                    chessboards.Add(chessboard);
                }
            }

            //List<ChessBoard> reverseList = this.ChessBoards;
            //reverseList.Reverse();
            return chessboards;
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
                Move newMove = new Move
                {
                    GameId = id,
                    Point = move
                };
                caroContext.Moves.Add(newMove);
                caroContext.SaveChanges();

                //this.ChessBoards.Single(x => x.Id == id).Moves.Add(move);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ChessBoard[] GetAllCoTheGameLevels()
        {
            ChessBoard[] chessBoards = new ChessBoard[20];

            Chess[,] chesses = ChessBoard.initChesses();
            chesses[10, 10] = new Chess(10, 10, 1, true);
            chesses[10, 11] = new Chess(10, 11, 2, true);
            chesses[11, 10] = new Chess(11, 10, 1, true);
            chesses[10, 12] = new Chess(10, 12, 2, true);
            chesses[12, 10] = new Chess(12, 10, 1, true);
            chesses[10, 13] = new Chess(10, 13, 2, true);

            chessBoards[0] = new ChessBoard(1, chesses, 5);
            chessBoards[0].Moves.AddRange(new string[] { "J10", "J10", "J10", "J10", "J10", "J10" });
            return chessBoards;
        }
    }
}
