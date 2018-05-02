using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Model
{
    public class CoTheChessboard
    {
        public static int ChessSize { get; } = 30;
        public static int BoardRows { get; } = 20;
        public static int BoardColumns { get; } = 20;
        public static int BoardPaddingLeft { get; } = 80;
        public static int BoardPaddingTop { get; } = 110;

        public int Id { get; set; }
        public Chess[,] Chesses { get; set; }
        public List<string> Moves { get; set; }
        public int LimitedMoves { get; set; }

        public CoTheChessboard()
        {
            Chesses = initChesses();
            Moves = new List<string>();
        }

        public CoTheChessboard(int id) : this()
        {
            this.Id = id;
        }

        public CoTheChessboard(int id, Chess[,] initMoves, int limitedMoves) : this()
        {
            this.Id = id;
            this.Chesses = initMoves;
            this.LimitedMoves = limitedMoves;
        }

        public static Chess[,] initChesses()
        {
            Chess[,] chess = new Chess[BoardRows + 1, BoardColumns + 1];
            for (int i = 1; i <= BoardRows; i++)
            {
                for (int j = 1; j <= BoardColumns; j++)
                {
                    chess[i, j] = new Chess(j, i, 0);
                }
            }
            return chess;
        }
    }
}
