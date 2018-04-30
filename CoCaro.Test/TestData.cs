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
        public static IEnumerable<IEnumerable<ChessBoard>> GetMockHistoryData
        {
            get
            {
                yield return new List<ChessBoard>()
                {
                    new ChessBoard
                    {
                        Id = 1,
                        Winner = 1,
                        NumberOfMove = 12,
                        IsEnd = true,
                        GameDuration = 50,
                        StartTime = DateTime.Now,
                        Moves = new List<string> { "A1", "B1", "A2", "B2", "A3", "B3", "A4", "B4", "A5" }
                    },
                    new ChessBoard
                    {
                        Id = 2,
                        Winner = 1,
                        NumberOfMove = 12,
                        IsEnd = true,
                        GameDuration = 50,
                        StartTime = DateTime.Now,
                        Moves = new List<string> { "A1", "B1", "A2", "B2", "A3", "B3", "A4", "B4", "A5" }
                    },
                    new ChessBoard
                    {
                        Id = 3,
                        Winner = 1,
                        NumberOfMove = 12,
                        IsEnd = true,
                        GameDuration = 50,
                        StartTime = DateTime.Now,
                        Moves = new List<string> { "A1", "B1", "A2", "B2", "A3", "B3", "A4", "B4", "A5" }
                    }
                };
            }
        }

        public static IEnumerable<ChessBoard> GetEmptyMockHistoryData
        {
            get
            {
                return new List<ChessBoard>();
            }
        }

    }
}
