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

        public ChessBoard CreateNewGame(bool isCoThe)
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

        public List<CoTheGameLevel> GetAllCoTheGameLevels()
        {
            //CoTheGameLevel[] coTheLevels = new CoTheGameLevel[20];

            //List<string> initMoves = new List<string>();
            //initMoves.Add("1_J10");
            //initMoves.Add("2_H10");
            //initMoves.Add("1_J11");
            //initMoves.Add("2_H11");
            //initMoves.Add("1_J12");
            //initMoves.Add("2_H12");
            //coTheLevels[0] = new CoTheGameLevel(1, initMoves, 5);            
            var coTheLevels = caroContext.CoTheLevels.Include(level => level.CoTheMoves).ToList();
            List<CoTheGameLevel> coTheGameLevels = new List<CoTheGameLevel>();

            foreach (var level in coTheLevels)
            {
                List<string> moves = new List<string>();
               
                if(level.CoTheMoves != null)
                {
                    foreach (var move in level.CoTheMoves)
                    {
                        moves.Add(move.Point);
                    }
                }
                coTheGameLevels.Add(new CoTheGameLevel
                {
                    Id = level.Id,
                    Moves = moves,
                    LimitedMoves = level.LimitedMove
                });
            }

            return coTheGameLevels;
        }

        public void SaveCoTheLevel(CoTheGameLevel gameLevel)
        {
            try
            {
                var coTheLevels = caroContext.CoTheLevels.Include(level => level.CoTheMoves);
                if(coTheLevels != null)
                {
                    var levelToModify = coTheLevels.SingleOrDefault(level => level.Id == gameLevel.Id);
                    if(levelToModify != null)
                    {
                        var coTheMoves = caroContext.CoTheMoves.ToList();
                        var coTheMovesToModify = levelToModify.CoTheMoves.Select(move => move.Point).ToList();

                        // find differences between two lists
                        var movesToDelete = coTheMovesToModify.Except(gameLevel.Moves);
                        foreach (var move in movesToDelete)
                        {
                            var moveToDelete = coTheMoves.SingleOrDefault(m =>
                                m.CoTheLevelId == levelToModify.Id && m.Point == move);
                            caroContext.CoTheMoves.Remove(moveToDelete);
                        }

                        var movesToAdd = gameLevel.Moves.Except(coTheMovesToModify);
                        foreach (var move in movesToAdd)
                        {
                            var moveToAdd = new CoTheMove
                            {
                                CoTheLevelId = levelToModify.Id,
                                Point = move
                            };
                            caroContext.CoTheMoves.Add(moveToAdd);
                        }

                        caroContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddCoTheLevel(CoTheGameLevel gameLevel)
        {
            try
            {
                var coTheLevel = new CoTheLevel
                {
                    LimitedMove = gameLevel.LimitedMoves
                };
                caroContext.CoTheLevels.Add(coTheLevel);
                caroContext.SaveChanges();

                foreach (var move in gameLevel.Moves)
                {
                    var coTheMove = new CoTheMove
                    {                        
                        CoTheLevelId = coTheLevel.Id,
                        Point = move
                    };
                    caroContext.CoTheMoves.Add(coTheMove);
                }
                caroContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteCoTheLevel(int gameLevelId)
        {
            try
            {
                var gameLevel = caroContext.CoTheLevels.Include(level => level.CoTheMoves);
                if (gameLevel != null)
                {
                    var levelToDelete = gameLevel.SingleOrDefault(level => level.Id == gameLevelId);
                    if (levelToDelete != null)
                    {
                        for (int i = 0; i < levelToDelete.CoTheMoves.Count; i++)
                        {
                            caroContext.CoTheMoves.Remove(levelToDelete.CoTheMoves[i]);
                        }
                        //caroContext.SaveChanges();

                        caroContext.CoTheLevels.Remove(levelToDelete);
                        caroContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
