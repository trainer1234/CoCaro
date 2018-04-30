using CoCaro.DAL.Models;
using CoCaro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Test
{
    public class TestData
    {
        public static IEnumerable<IEnumerable<Game>> GetMockHistoryData
        {
            get
            {
                var moveData1 = new List<Move>()
                {
                    new Move { Id = 1, GameId = 1, Point = "A1" },
                    new Move { Id = 2, GameId = 1, Point = "B1" },
                    new Move { Id = 3, GameId = 1, Point = "A2" },
                    new Move { Id = 4, GameId = 1, Point = "B2" },
                    new Move { Id = 5, GameId = 1, Point = "A3" },
                    new Move { Id = 6, GameId = 1, Point = "B3" },
                    new Move { Id = 7, GameId = 1, Point = "A4" },
                    new Move { Id = 8, GameId = 1, Point = "B4" },
                    new Move { Id = 9, GameId = 1, Point = "A5" }
                };
                var moveData2 = new List<Move>()
                {
                    new Move { Id = 10, GameId = 2, Point = "A1" },
                    new Move { Id = 11, GameId = 2, Point = "B1" },
                    new Move { Id = 12, GameId = 2, Point = "A2" },
                    new Move { Id = 13, GameId = 2, Point = "B2" },
                    new Move { Id = 14, GameId = 2, Point = "A3" },
                    new Move { Id = 15, GameId = 2, Point = "B3" },
                    new Move { Id = 16, GameId = 2, Point = "A4" },
                    new Move { Id = 17, GameId = 2, Point = "B4" },
                    new Move { Id = 18, GameId = 2, Point = "A5" }
                };
                var moveData3 = new List<Move>()
                {
                    new Move { Id = 19, GameId = 3, Point = "A1" },
                    new Move { Id = 20, GameId = 3, Point = "B1" },
                    new Move { Id = 21, GameId = 3, Point = "A2" },
                    new Move { Id = 22, GameId = 3, Point = "B2" },
                    new Move { Id = 23, GameId = 3, Point = "A3" },
                    new Move { Id = 24, GameId = 3, Point = "B3" },
                    new Move { Id = 25, GameId = 3, Point = "A4" },
                    new Move { Id = 26, GameId = 3, Point = "B4" },
                    new Move { Id = 27, GameId = 3, Point = "A5" }
                };

                yield return new List<Game>
                {
                    new Game
                    {
                        Id = 1,
                        Winner = 1,
                        StartTime = DateTime.Now,
                        Duration = 12,
                        Moves = moveData1
                    },
                    new Game
                    {
                        Id = 2,
                        Winner = 1,
                        StartTime = DateTime.Now,
                        Duration = 12,
                        Moves = moveData2
                    },
                    new Game
                    {
                        Id = 3,
                        Winner = 1,
                        StartTime = DateTime.Now,
                        Duration = 12,
                        Moves = moveData3
                    }
                };

                yield return new List<Game>
                {
                    new Game
                    {
                        Id = 1,
                        Winner = 1,
                        StartTime = DateTime.Now,
                        Duration = 12,
                        Moves = moveData1
                    },
                    new Game
                    {
                        Id = 2,
                        Winner = 1,
                        StartTime = DateTime.Now,
                        Duration = 12,
                        Moves = moveData2
                    }
                };

                yield return new List<Game>
                {
                    new Game
                    {
                        Id = 1,
                        Winner = 1,
                        StartTime = DateTime.Now,
                        Duration = 12,
                        Moves = moveData1
                    }
                };

                //yield return new List<ChessBoard>()
                //{
                //    new ChessBoard
                //    {
                //        Id = 1,
                //        Winner = 1,
                //        NumberOfMove = 12,
                //        IsEnd = true,
                //        GameDuration = 50,
                //        StartTime = DateTime.Now,
                //        Moves = new List<string> { "A1", "B1", "A2", "B2", "A3", "B3", "A4", "B4", "A5" }
                //    },
                //    new ChessBoard
                //    {
                //        Id = 2,
                //        Winner = 1,
                //        NumberOfMove = 12,
                //        IsEnd = true,
                //        GameDuration = 50,
                //        StartTime = DateTime.Now,
                //        Moves = new List<string> { "A1", "B1", "A2", "B2", "A3", "B3", "A4", "B4", "A5" }
                //    },
                //    new ChessBoard
                //    {
                //        Id = 3,
                //        Winner = 1,
                //        NumberOfMove = 12,
                //        IsEnd = true,
                //        GameDuration = 50,
                //        StartTime = DateTime.Now,
                //        Moves = new List<string> { "A1", "B1", "A2", "B2", "A3", "B3", "A4", "B4", "A5" }
                //    }
                //};
            }
        }

        public static IEnumerable<IEnumerable<Game>> GetEmptyMockHistoryData
        {
            get
            {
                yield return new List<Game>();
            }
        }

        public static IEnumerable<IEnumerable<Game>> GetEmptyGameRecordData
        {
            get
            {
                yield return new List<Game>();
            }
        }

        public static IEnumerable<int> GetGameRecordData
        {
            get
            {
                yield return 1;
                yield return 2;
                yield return 3;
            }
        }
    }
}
